using System;
using System.Runtime.Serialization;

namespace TravelAgencyBusinessLogic.BindingModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    [DataContract]
    public class MessageInfoBindingModel
    {
        [DataMember]
        public int? ClientId { get; set; }

        [DataMember]
        public string MessageId { get; set; }

        [DataMember]
        public string FromMailAddress { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public DateTime DateDelivery { get; set; }

        [DataMember]
        public int? SkippingMessages { get; set; }

        [DataMember]
        public int? TakingMessages { get; set; }
    }
}