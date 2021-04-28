using System;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class ReportOrdersAllPeriodViewModel
    {
        public DateTime DateCreate { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}