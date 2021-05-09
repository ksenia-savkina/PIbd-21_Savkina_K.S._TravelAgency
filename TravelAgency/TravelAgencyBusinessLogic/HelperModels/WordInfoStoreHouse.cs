using System.Collections.Generic;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyBusinessLogic.HelperModels
{
    class WordInfoStoreHouse
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<StoreHouseViewModel> StoreHouses { get; set; }
    }
}