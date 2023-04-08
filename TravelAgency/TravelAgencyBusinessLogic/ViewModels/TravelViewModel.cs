using System.Collections.Generic;
using System.Runtime.Serialization;
using TravelAgencyBusinessLogic.Attributes;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyBusinessLogic.ViewModels
{
    [DataContract]
    public class TravelViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Название путёвки", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string TravelName { get; set; }

        [Column(title: "Цена", width: 100)]
        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> TravelComponents { get; set; }
    }
}