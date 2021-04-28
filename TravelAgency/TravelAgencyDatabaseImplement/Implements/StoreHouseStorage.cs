using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyDatabaseImplement.Models;

namespace TravelAgencyDatabaseImplement.Implements
{
    public class StoreHouseStorage : IStoreHouseStorage
    {
        public List<StoreHouseViewModel> GetFullList()
        {
            using (var context = new TravelAgencyDatabase())
            {
                return context.StoreHouses
                .Include(rec => rec.StoreHouseComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new StoreHouseViewModel
                {
                    Id = rec.Id,
                    StoreHouseName = rec.StoreHouseName,
                    ResponsiblePersonFullName = rec.ResponsiblePersonFullName,
                    DateCreate = rec.DateCreate,
                    StoreHouseComponents = rec.StoreHouseComponents
                    .ToDictionary(recSC => recSC.ComponentId, recSC => (recSC.Component?.ComponentName, recSC.Count))
                })
                .ToList();
            }
        }

        public List<StoreHouseViewModel> GetFilteredList(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TravelAgencyDatabase())
            {
                return context.StoreHouses
                .Include(rec => rec.StoreHouseComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.StoreHouseName.Contains(model.StoreHouseName))
                .ToList()
                .Select(rec => new StoreHouseViewModel
                {
                    Id = rec.Id,
                    StoreHouseName = rec.StoreHouseName,
                    ResponsiblePersonFullName = rec.ResponsiblePersonFullName,
                    DateCreate = rec.DateCreate,
                    StoreHouseComponents = rec.StoreHouseComponents
                    .ToDictionary(recSC => recSC.ComponentId, recSC => (recSC.Component?.ComponentName, recSC.Count))
                })
                .ToList();
            }
        }

        public StoreHouseViewModel GetElement(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TravelAgencyDatabase())
            {
                var storeHouse = context.StoreHouses
                .Include(rec => rec.StoreHouseComponents)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.StoreHouseName == model.StoreHouseName || rec.Id == model.Id);
                return storeHouse != null ?
                new StoreHouseViewModel
                {
                    Id = storeHouse.Id,
                    StoreHouseName = storeHouse.StoreHouseName,
                    ResponsiblePersonFullName = storeHouse.ResponsiblePersonFullName,
                    DateCreate = storeHouse.DateCreate,
                    StoreHouseComponents = storeHouse.StoreHouseComponents
                    .ToDictionary(recSC => recSC.ComponentId, recSC => (recSC.Component?.ComponentName, recSC.Count))
                } :
                null;
            }
        }

        public void Insert(StoreHouseBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        StoreHouse storeHouse = CreateModel(model, new StoreHouse(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(StoreHouseBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Склад не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(StoreHouseBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                StoreHouse element = context.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.StoreHouses.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public bool WriteOff(int count, Dictionary<int, (string, int)> travelComponents)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var travelComponent in travelComponents)
                        {
                            IEnumerable<StoreHouseComponent> storeHouseComponents = context.StoreHouseComponents.Where(storeComponent => storeComponent.ComponentId == travelComponent.Key);
                            int countAvailable = storeHouseComponents.Sum(storeComponent => storeComponent.Count);
                            int countRequired = travelComponent.Value.Item2 * count;
                            if (countAvailable < countRequired)
                            {
                                throw new Exception("На складе недостаточно материалов");
                            }
                            foreach (var component in storeHouseComponents)
                            {
                                if (component.Count <= countRequired)
                                {
                                    countRequired -= component.Count;
                                    context.StoreHouseComponents.Remove(component);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    component.Count -= countRequired;
                                    context.SaveChanges();
                                    countRequired = 0;
                                }

                                if (countRequired == 0)
                                {
                                    break;
                                }
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private StoreHouse CreateModel(StoreHouseBindingModel model, StoreHouse storeHouse, TravelAgencyDatabase context)
        {
            storeHouse.StoreHouseName = model.StoreHouseName;
            storeHouse.ResponsiblePersonFullName = model.ResponsiblePersonFullName;
            if (storeHouse.Id == 0)
            {
                storeHouse.DateCreate = DateTime.Now;
                context.StoreHouses.Add(storeHouse);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                var storeHouseComponents = context.StoreHouseComponents.Where(rec => rec.StoreHouseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.StoreHouseComponents.RemoveRange(storeHouseComponents.Where(rec => !model.StoreHouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in storeHouseComponents)
                {
                    updateComponent.Count = model.StoreHouseComponents[updateComponent.ComponentId].Item2;
                    model.StoreHouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var sc in model.StoreHouseComponents)
            {
                context.StoreHouseComponents.Add(new StoreHouseComponent
                {
                    StoreHouseId = storeHouse.Id,
                    ComponentId = sc.Key,
                    Count = sc.Value.Item2
                });
                context.SaveChanges();
            }
            return storeHouse;
        }
    }
}
