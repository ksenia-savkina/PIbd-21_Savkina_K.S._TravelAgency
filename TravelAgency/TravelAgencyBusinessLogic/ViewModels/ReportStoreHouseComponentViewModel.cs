using System;
using System.Collections.Generic;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class ReportStoreHouseComponentViewModel
    {
        public string StoreHouseName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; }
    }
}