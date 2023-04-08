using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyDatabaseImplement.Models
{
    public class Travel
    {
        public int Id { get; set; }

        [Required]
        public string TravelName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("TravelId")]
        public virtual List<TravelComponent> TravelComponents { get; set; }

        [ForeignKey("TravelId")]
        public virtual List<Order> Order { get; set; }
    }
}
