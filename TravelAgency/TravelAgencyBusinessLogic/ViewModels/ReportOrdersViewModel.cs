using System;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public string ClientFIO { get; set; }

        public DateTime DateCreate { get; set; }

        public string TravelName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public String Status { get; set; }
    }
}
