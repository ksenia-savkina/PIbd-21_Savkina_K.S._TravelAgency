using System;
using System.Collections.Generic;

namespace TravelAgencyBusinessLogic.BindingModels
{
    public class StoreHouseBindingModel
    {
        public int? Id { get; set; }

        public string StoreHouseName { get; set; }

        public string ResponsiblePersonFullName { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StoreHouseComponents { get; set; }
    }
}