using System.Collections.Generic;
using System.ComponentModel;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class TravelViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название путёвки")]
        public string TravelName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> TravelComponents { get; set; }
    }
}