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
        private readonly ITravelStorage _travelStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStoreHouseStorage _storeHouseStorage;

        public ReportLogic(ITravelStorage travelStorage, IOrderStorage orderStorage, IStoreHouseStorage storeHouseStorage)
        {
            _travelStorage = travelStorage;
            _orderStorage = orderStorage;
            _storeHouseStorage = storeHouseStorage;
        }
        /// <summary>
        /// Получение списка путёвок с указанием, какие компоненты в них используются
        /// </summary>
        /// <returns></returns>
        public List<ReportTravelComponentViewModel> GetComponentTravel()
        {
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
                foreach (var component in travel.TravelComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
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
                ClientFIO = x.ClientFIO,
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
        public void SaveTravelsToWordFile(ReportBindingModel model)
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

        public void SaveStoreHousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocStoreHouse(new WordInfoStoreHouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                StoreHouses = _storeHouseStorage.GetFullList()
            });
        }

        public List<ReportStoreHouseComponentViewModel> GetComponentStoreHouse()
        {
            var storeHouses = _storeHouseStorage.GetFullList();
            var list = new List<ReportStoreHouseComponentViewModel>();
            foreach (var storeHouse in storeHouses)
            {
                var record = new ReportStoreHouseComponentViewModel
                {
                    StoreHouseName = storeHouse.StoreHouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in storeHouse.StoreHouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public void SaveComponentStoreHouseToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDocStoreHouse(new ExcelInfoStoreHouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                StoreHouseComponents = GetComponentStoreHouse()
            });
        }

        public List<ReportOrdersAllPeriodViewModel> GetOrdersAllPeriod()
        {
            return _orderStorage.GetFullList()
            .GroupBy(order => order.DateCreate.ToShortDateString())
            .Select(x => new ReportOrdersAllPeriodViewModel
            {
                DateCreate = Convert.ToDateTime(x.Key),
                Count = x.Count(),
                Sum = x.Sum(order => order.Sum)
            })
            .ToList();
        }

        public void SaveOrdersAllPeriodToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocOrdersAllPeriod(new PdfInfoOrdersAllPeriod
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersAllPeriod()
            });
        }
    }
}