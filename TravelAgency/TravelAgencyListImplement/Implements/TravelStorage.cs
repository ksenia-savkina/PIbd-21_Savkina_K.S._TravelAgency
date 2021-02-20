using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyListImplement.Models;

namespace TravelAgencyListImplement.Implements
{
    public class TravelStorage : ITravelStorage
    {
        private readonly DataListSingleton source;

        public TravelStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<TravelViewModel> GetFullList()
        {
            List<TravelViewModel> result = new List<TravelViewModel>();
            foreach (var travel in source.Travels)
            {
                result.Add(CreateModel(travel));
            }
            return result;
        }

        public List<TravelViewModel> GetFilteredList(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<TravelViewModel> result = new List<TravelViewModel>();
            foreach (var travel in source.Travels)
            {
                if (travel.TravelName.Contains(model.TravelName))
                {
                    result.Add(CreateModel(travel));
                }
            }
            return result;
        }

        public TravelViewModel GetElement(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var travel in source.Travels)
            {
                if (travel.Id == model.Id || travel.TravelName == model.TravelName)
                {
                    return CreateModel(travel);
                }
            }
            return null;
        }

        public void Insert(TravelBindingModel model)
        {
            Travel tempTravel = new Travel { Id = 1, TravelComponents = new Dictionary<int, int>() };
            foreach (var travel in source.Travels)
            {
                if (travel.Id >= tempTravel.Id)
                {
                    tempTravel.Id = travel.Id + 1;
                }
            }
            source.Travels.Add(CreateModel(model, tempTravel));
        }

        public void Update(TravelBindingModel model)
        {
            Travel tempTravel = null;
            foreach (var travel in source.Travels)
            {
                if (travel.Id == model.Id)
                {
                    tempTravel = travel;
                }
            }
            if (tempTravel == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempTravel);
        }

        public void Delete(TravelBindingModel model)
        {
            for (int i = 0; i < source.Travels.Count; ++i)
            {
                if (source.Travels[i].Id == model.Id)
                {
                    source.Travels.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Travel CreateModel(TravelBindingModel model, Travel travel)
        {
            travel.TravelName = model.TravelName;
            travel.Price = model.Price;
            // удаляем убранные
            foreach (var key in travel.TravelComponents.Keys.ToList())
            {
                if (!model.TravelComponents.ContainsKey(key))
                {
                    travel.TravelComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.TravelComponents)
            {
                if (travel.TravelComponents.ContainsKey(component.Key))
                {
                    travel.TravelComponents[component.Key] = model.TravelComponents[component.Key].Item2;
                }
                else
                {
                    travel.TravelComponents.Add(component.Key, model.TravelComponents[component.Key].Item2);
                }
            }
            return travel;
        }

        private TravelViewModel CreateModel(Travel travel)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> travelComponents = new Dictionary<int, (string, int)>();
            foreach (var tc in travel.TravelComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (tc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                travelComponents.Add(tc.Key, (componentName, tc.Value));
            }
            return new TravelViewModel
            {
                Id = travel.Id,
                TravelName = travel.TravelName,
                Price = travel.Price,
                TravelComponents = travelComponents
            };
        }
    }
}