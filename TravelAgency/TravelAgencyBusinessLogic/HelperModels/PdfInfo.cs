﻿using System;
using System.Collections.Generic;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<ReportOrdersViewModel> Orders { get; set; }
    }
}