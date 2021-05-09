using System.Collections.Generic;

namespace TravelAgencyBusinessLogic.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<MessageInfoViewModel> Messages { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}