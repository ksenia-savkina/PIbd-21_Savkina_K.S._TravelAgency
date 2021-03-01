using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyListImplement.Models;

namespace TravelAgencyListImplement.Implements
{
    public class StoreHouseStorage : IStoreHouseStorage
    {
        private readonly DataListSingleton source;

        public StoreHouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<StoreHouseViewModel> GetFullList()
        {
            List<StoreHouseViewModel> result = new List<StoreHouseViewModel>();
            foreach (var storeHouse in source.StoreHouses)
            {
                result.Add(CreateModel(storeHouse));
            }
            return result;
        }

        public List<StoreHouseViewModel> GetFilteredList(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<StoreHouseViewModel> result = new List<StoreHouseViewModel>();
            foreach (var storeHouse in source.StoreHouses)
            {
                if (storeHouse.StoreHouseName.Contains(model.StoreHouseName))
                {
                    result.Add(CreateModel(storeHouse));
                }
            }
            return result;
        }

        public StoreHouseViewModel GetElement(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var storeHouse in source.StoreHouses)
            {
                if (storeHouse.Id == model.Id || storeHouse.StoreHouseName == model.StoreHouseName)
                {
                    return CreateModel(storeHouse);
                }
            }
            return null;
        }

        public void Insert(StoreHouseBindingModel model)
        {
            StoreHouse tempStoreHouse = new StoreHouse
            {
                Id = 1,
                StoreHouseComponents = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };
            foreach (var storeHouse in source.StoreHouses)
            {
                if (storeHouse.Id >= tempStoreHouse.Id)
                {
                    tempStoreHouse.Id = storeHouse.Id + 1;
                }
            }
            source.StoreHouses.Add(CreateModel(model, tempStoreHouse));
        }

        public void Update(StoreHouseBindingModel model)
        {
            StoreHouse tempStoreHouse = null;
            foreach (var StoreHouse in source.StoreHouses)
            {
                if (StoreHouse.Id == model.Id)
                {
                    tempStoreHouse = StoreHouse;
                }
            }
            if (tempStoreHouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempStoreHouse);
        }

        public void Delete(StoreHouseBindingModel model)
        {
            for (int i = 0; i < source.StoreHouses.Count; ++i)
            {
                if (source.StoreHouses[i].Id == model.Id)
                {
                    source.StoreHouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
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
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> storeHouseComponents = new Dictionary<int, (string, int)>();
            foreach (var sc in storeHouse.StoreHouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (sc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                storeHouseComponents.Add(sc.Key, (componentName, sc.Value));
            }
            return new StoreHouseViewModel
            {
                Id = storeHouse.Id,
                StoreHouseName = storeHouse.StoreHouseName,
                ResponsiblePersonFullName = storeHouse.ResponsiblePersonFullName,
                DateCreate = storeHouse.DateCreate,
                StoreHouseComponents = storeHouseComponents
            };
        }

        public void Print()
        {
            foreach (StoreHouse storeHouse in source.StoreHouses)
            {
                Console.WriteLine(storeHouse.StoreHouseName + " " + storeHouse.ResponsiblePersonFullName + " " + storeHouse.DateCreate);
                foreach (KeyValuePair<int, int> keyValue in storeHouse.StoreHouseComponents)
                {
                    string componentName = source.Components.FirstOrDefault(component => component.Id == keyValue.Key).ComponentName;
                    Console.WriteLine(componentName + " " + keyValue.Value);
                }
            }
        }
    }
}