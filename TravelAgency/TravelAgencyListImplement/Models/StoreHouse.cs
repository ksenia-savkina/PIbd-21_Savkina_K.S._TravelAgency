using System;
using System.Collections.Generic;

namespace TravelAgencyListImplement.Models
{
    public class StoreHouse
    {
        public int Id { get; set; }

        public string StoreHouseName { get; set; }

        public string ResponsiblePersonFullName { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, int> StoreHouseComponents { get; set; }
    }
}