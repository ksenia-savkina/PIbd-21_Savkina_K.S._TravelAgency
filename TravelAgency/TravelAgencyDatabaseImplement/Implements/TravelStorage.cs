using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyDatabaseImplement.Models;

namespace TravelAgencyDatabaseImplement.Implements
{
    public class TravelStorage : ITravelStorage
    {
        public List<TravelViewModel> GetFullList()
        {
            using (var context = new TravelAgencyDatabase())
            {
                return context.Travels
                .Include(rec => rec.TravelComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new TravelViewModel
                {
                    Id = rec.Id,
                    TravelName = rec.TravelName,
                    Price = rec.Price,
                    TravelComponents = rec.TravelComponents
                    .ToDictionary(recTC => recTC.ComponentId, recTC => (recTC.Component?.ComponentName, recTC.Count))
                })
                .ToList();
            }
        }

        public List<TravelViewModel> GetFilteredList(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TravelAgencyDatabase())
            {
                return context.Travels
                .Include(rec => rec.TravelComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.TravelName.Contains(model.TravelName))
                .ToList()
                .Select(rec => new TravelViewModel
                {
                    Id = rec.Id,
                    TravelName = rec.TravelName,
                    Price = rec.Price,
                    TravelComponents = rec.TravelComponents
                    .ToDictionary(recTC => recTC.ComponentId, recTC => (recTC.Component?.ComponentName, recTC.Count))
                })
                .ToList();
            }
        }

        public TravelViewModel GetElement(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TravelAgencyDatabase())
            {
                var Travel = context.Travels
                .Include(rec => rec.TravelComponents)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.TravelName == model.TravelName || rec.Id == model.Id);
                return Travel != null ?
                new TravelViewModel
                {
                    Id = Travel.Id,
                    TravelName = Travel.TravelName,
                    Price = Travel.Price,
                    TravelComponents = Travel.TravelComponents
                    .ToDictionary(recTC => recTC.ComponentId, recTC => (recTC.Component?.ComponentName, recTC.Count))
                } :
                null;
            }
        }

        public void Insert(TravelBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Travel travel = CreateModel(model, new Travel());
                        context.Travels.Add(travel);
                        context.SaveChanges();
                        travel = CreateModel(model, travel, context);
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

        public void Update(TravelBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Travels.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
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

        public void Delete(TravelBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                Travel element = context.Travels.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Travels.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Travel CreateModel(TravelBindingModel model, Travel Travel)
        {
            Travel.TravelName = model.TravelName;
            Travel.Price = model.Price;
            return Travel;
        }

        private Travel CreateModel(TravelBindingModel model, Travel travel, TravelAgencyDatabase context)
        {
            travel.TravelName = model.TravelName;
            travel.Price = model.Price;
            if (model.Id.HasValue)
            {
                var travelComponents = context.TravelComponents.Where(rec => rec.TravelId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.TravelComponents.RemoveRange(travelComponents.Where(rec => !model.TravelComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in travelComponents)
                {
                    updateComponent.Count = model.TravelComponents[updateComponent.ComponentId].Item2;
                    model.TravelComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var tc in model.TravelComponents)
            {
                context.TravelComponents.Add(new TravelComponent
                {
                    TravelId = travel.Id,
                    ComponentId = tc.Key,
                    Count = tc.Value.Item2
                });
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    MessageBox.Show(e?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return travel;
        }
    }
}