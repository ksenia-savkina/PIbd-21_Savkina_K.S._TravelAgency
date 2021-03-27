using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class StoreHouseViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название склада")]
        public string StoreHouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string ResponsiblePersonFullName { get; set; }

        [DisplayName("Дата создания склада")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StoreHouseComponents { get; set; }
    }
}