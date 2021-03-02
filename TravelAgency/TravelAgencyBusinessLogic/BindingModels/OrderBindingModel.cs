﻿using System;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyBusinessLogic.BindingModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderBindingModel
    {
        public int? Id { get; set; }

        public int TravelId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
    }
}