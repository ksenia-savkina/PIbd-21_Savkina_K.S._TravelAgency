namespace TravelAgencyBusinessLogic.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        public int TravelId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}