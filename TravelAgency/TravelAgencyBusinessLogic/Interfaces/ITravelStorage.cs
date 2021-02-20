using System.Collections.Generic;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyBusinessLogic.Interfaces
{
    public interface ITravelStorage
    {
        List<TravelViewModel> GetFullList();

        List<TravelViewModel> GetFilteredList(TravelBindingModel model);

        TravelViewModel GetElement(TravelBindingModel model);

        void Insert(TravelBindingModel model);

        void Update(TravelBindingModel model);

        void Delete(TravelBindingModel model);
    }
}