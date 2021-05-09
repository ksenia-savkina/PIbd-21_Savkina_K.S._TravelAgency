using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyDatabaseImplement.Models
{
    public class StoreHouse
    {
        public int Id { get; set; }

        [Required]
        public string StoreHouseName { get; set; }

        [Required]
        public string ResponsiblePersonFullName { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("StoreHouseId")]
        public virtual List<StoreHouseComponent> StoreHouseComponents { get; set; }
    }
}