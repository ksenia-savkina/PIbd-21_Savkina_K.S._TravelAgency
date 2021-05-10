using TravelAgencyBusinessLogic.Attributes;
using TravelAgencyBusinessLogic.Enums;

namespace TravelAgencyBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления путёвки
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}