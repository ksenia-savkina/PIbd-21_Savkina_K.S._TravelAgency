using System;
using System.Collections.Generic;
using TravelAgencyBusinessLogic.Attributes;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class StoreHouseViewModel
    {
        public int Id { get; set; }

        [Column(title: "Название склада", width: 120)]
        public string StoreHouseName { get; set; }

        [Column(title: "ФИО ответственного", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ResponsiblePersonFullName { get; set; }

        [Column(title: "Дата создания склада", dateFormat: "d", width: 130)]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StoreHouseComponents { get; set; }
    }
}