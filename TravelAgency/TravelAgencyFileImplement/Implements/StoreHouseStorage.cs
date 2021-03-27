﻿using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyFileImplement.Models;

namespace TravelAgencyFileImplement.Implements
{
    public class StoreHouseStorage : IStoreHouseStorage
    {
        private readonly FileDataListSingleton source;

        public StoreHouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<StoreHouseViewModel> GetFullList()
        {
            return source.StoreHouses
            .Select(CreateModel)
            .ToList();
        }

        public List<StoreHouseViewModel> GetFilteredList(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.StoreHouses
            .Where(rec => rec.StoreHouseName.Contains(model.StoreHouseName))
            .Select(CreateModel)
            .ToList();
        }

        public StoreHouseViewModel GetElement(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var storeHouse = source.StoreHouses
            .FirstOrDefault(rec => rec.StoreHouseName == model.StoreHouseName || rec.Id == model.Id);
            return storeHouse != null ? CreateModel(storeHouse) : null;
        }

        public void Insert(StoreHouseBindingModel model)
        {
            int maxId = source.StoreHouses.Count > 0 ? source.StoreHouses.Max(rec => rec.Id) : 0;
            var element = new StoreHouse { Id = maxId + 1, StoreHouseComponents = new Dictionary<int, int>(), DateCreate = DateTime.Now };
            source.StoreHouses.Add(CreateModel(model, element));
        }

        public void Update(StoreHouseBindingModel model)
        {
            var element = source.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(StoreHouseBindingModel model)
        {
            StoreHouse element = source.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.StoreHouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public bool WriteOff(int count, Dictionary<int, (string, int)> shComponents)
        {
            foreach (var storeHouseComponent in shComponents)
            {
                int countAvailable = source.StoreHouses.Where(store => store.StoreHouseComponents.ContainsKey(storeHouseComponent.Key))
                    .Sum(store => store.StoreHouseComponents[storeHouseComponent.Key]);

                if (countAvailable < storeHouseComponent.Value.Item2 * count)
                {
                    return false;
                }
            }

            foreach (var storeHouseComponent in shComponents)
            {
                int countAvailable = storeHouseComponent.Value.Item2 * count;
                IEnumerable<StoreHouse> storeHouses = source.StoreHouses.Where(store => store.StoreHouseComponents.ContainsKey(storeHouseComponent.Key));

                foreach (StoreHouse storeHouse in storeHouses)
                {
                    if (storeHouse.StoreHouseComponents[storeHouseComponent.Key] <= countAvailable)
                    {
                        countAvailable -= storeHouse.StoreHouseComponents[storeHouseComponent.Key];
                        storeHouse.StoreHouseComponents.Remove(storeHouseComponent.Key);
                    }
                    else
                    {
                        storeHouse.StoreHouseComponents[storeHouseComponent.Key] -= countAvailable;
                        countAvailable = 0;
                    }

                    if (countAvailable == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }

        private StoreHouse CreateModel(StoreHouseBindingModel model, StoreHouse storeHouse)
        {
            storeHouse.StoreHouseName = model.StoreHouseName;
            storeHouse.ResponsiblePersonFullName = model.ResponsiblePersonFullName;
            // удаляем убранные
            foreach (var key in storeHouse.StoreHouseComponents.Keys.ToList())
            {
                if (!model.StoreHouseComponents.ContainsKey(key))
                {
                    storeHouse.StoreHouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.StoreHouseComponents)
            {
                if (storeHouse.StoreHouseComponents.ContainsKey(component.Key))
                {
                    storeHouse.StoreHouseComponents[component.Key] = model.StoreHouseComponents[component.Key].Item2;
                }
                else
                {
                    storeHouse.StoreHouseComponents.Add(component.Key, model.StoreHouseComponents[component.Key].Item2);
                }
            }
            return storeHouse;
        }

        private StoreHouseViewModel CreateModel(StoreHouse storeHouse)
        {
            return new StoreHouseViewModel
            {
                Id = storeHouse.Id,
                StoreHouseName = storeHouse.StoreHouseName,
                ResponsiblePersonFullName = storeHouse.ResponsiblePersonFullName,
                DateCreate = storeHouse.DateCreate,
                StoreHouseComponents = storeHouse.StoreHouseComponents.ToDictionary(recSC => recSC.Key, recSC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recSC.Key)?.ComponentName, recSC.Value))
            };
        }
    }
}