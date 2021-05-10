using System.Collections.Generic;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyBusinessLogic.HelperModels
{
    class ExcelInfoStoreHouse
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportStoreHouseComponentViewModel> StoreHouseComponents { get; set; }
    }
}