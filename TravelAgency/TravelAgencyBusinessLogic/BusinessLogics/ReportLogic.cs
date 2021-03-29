using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.Enums;
using TravelAgencyBusinessLogic.HelperModels;
using TravelAgencyBusinessLogic.Interfaces;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ITravelStorage _travelStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(ITravelStorage travelStorage, IComponentStorage componentStorage, IOrderStorage orderStorage)
        {
            _travelStorage = travelStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        /// <summary>
        /// Получение списка путёвок с указанием, какие компоненты в них используются
        /// </summary>
        /// <returns></returns>
        public List<ReportTravelComponentViewModel> GetComponentTravel()
        {
            var components = _componentStorage.GetFullList();
            var travels = _travelStorage.GetFullList();
            var list = new List<ReportTravelComponentViewModel>();
            foreach (var travel in travels)
                {
                var record = new ReportTravelComponentViewModel
                {
                    TravelName = travel.TravelName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (travel.TravelComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName, travel.TravelComponents[component.Id].Item2));
                        record.TotalCount += travel.TravelComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                TravelName = x.TravelName,
                Count = x.Count,
                Sum = x.Sum,
                Status = Convert.ToString((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString()))
            })
            .ToList();
        }
        /// <summary>
        /// Сохранение путёвок в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список путёвок",
                Travels = _travelStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение путёвок с указанием компонентов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentTravelToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список путёвок",
                TravelComponents = GetComponentTravel()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
