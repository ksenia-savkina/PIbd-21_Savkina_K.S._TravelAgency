﻿using System;
using System.ComponentModel.DataAnnotations;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int TravelId { get; set; }

        public virtual Travel Travel { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int? ImplementerId { get; set; }

        public virtual Implementer Implementer { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
    }
}