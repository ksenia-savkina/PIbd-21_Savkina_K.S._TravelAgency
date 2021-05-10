using System.Runtime.Serialization;
using TravelAgencyBusinessLogic.Attributes;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Логин", width: 120)]
        [DataMember]
        public string Email { get; set; }

        [Column(title: "Пароль", width: 100)]
        [DataMember]
        public string Password { get; set; }
    }
}
