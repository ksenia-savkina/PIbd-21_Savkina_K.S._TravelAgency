using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyFileImplement.Models;

namespace TravelAgencyFileImplement.Implements
{
    public class TravelStorage : ITravelStorage
    {
        private readonly FileDataListSingleton source;

        public TravelStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<TravelViewModel> GetFullList()
        {
            return source.Travels
            .Select(CreateModel)
            .ToList();
        }

        public List<TravelViewModel> GetFilteredList(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Travels
            .Where(rec => rec.TravelName.Contains(model.TravelName))
            .Select(CreateModel)
            .ToList();
        }

        public TravelViewModel GetElement(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var Travel = source.Travels
            .FirstOrDefault(rec => rec.TravelName == model.TravelName || rec.Id == model.Id);
            return Travel != null ? CreateModel(Travel) : null;
        }

        public void Insert(TravelBindingModel model)
        {
            int maxId = source.Travels.Count > 0 ? source.Travels.Max(rec => rec.Id) : 0;
            var element = new Travel { Id = maxId + 1, TravelComponents = new Dictionary<int, int>() };
            source.Travels.Add(CreateModel(model, element));
        }

        public void Update(TravelBindingModel model)
        {
            var element = source.Travels.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(TravelBindingModel model)
        {
            Travel element = source.Travels.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Travels.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Travel CreateModel(TravelBindingModel model, Travel Travel)
        {
            Travel.TravelName = model.TravelName;
            Travel.Price = model.Price;
            // удаляем убранные
            foreach (var key in Travel.TravelComponents.Keys.ToList())
            {
                if (!model.TravelComponents.ContainsKey(key))
                {
                    Travel.TravelComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.TravelComponents)
            {
                if (Travel.TravelComponents.ContainsKey(component.Key))
                {
                    Travel.TravelComponents[component.Key] = model.TravelComponents[component.Key].Item2;
                }
                else
                {
                    Travel.TravelComponents.Add(component.Key, model.TravelComponents[component.Key].Item2);
                }
            }
            return Travel;
        }

        private TravelViewModel CreateModel(Travel Travel)
        {
            return new TravelViewModel
            {
                Id = Travel.Id,
                TravelName = Travel.TravelName,
                Price = Travel.Price,
                TravelComponents = Travel.TravelComponents.ToDictionary(recPC => recPC.Key, recPC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}