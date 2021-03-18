using System;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }

        public string TravelName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public String Status { get; set; }
    }
}
