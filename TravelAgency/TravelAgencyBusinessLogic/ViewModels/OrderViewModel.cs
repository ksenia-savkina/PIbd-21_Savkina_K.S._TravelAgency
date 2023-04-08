using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using TravelAgencyBusinessLogic.Attributes;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 50)]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int TravelId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [Column(title: "Клиент", width: 100)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Путёвка", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string TravelName { get; set; }

        [Column(title: "Исполнитель", width: 100)]
        [DataMember]
        public string ImplementerFIO { get; set; }

        [Column(title: "Количество", width: 70)]
        [DataMember]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 70)]
        [DataMember]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 70)]
        [DataMember]
        public OrderStatus Status { get; set; }

        [Column(title: "Дата создания", dateFormat: "d", width: 130)]
        [DataMember]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", dateFormat: "d", width: 130)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}