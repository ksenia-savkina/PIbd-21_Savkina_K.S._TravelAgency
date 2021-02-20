using System.Collections.Generic;

namespace TravelAgencyBusinessLogic.BindingModels
{
    public class TravelBindingModel
    {
        public int? Id { get; set; }

        public string TravelName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> TravelComponents { get; set; }
    }
}