using System.Collections.Generic;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyBusinessLogic.Interfaces
{
    public interface IStoreHouseStorage
    {
        List<StoreHouseViewModel> GetFullList();

        List<StoreHouseViewModel> GetFilteredList(StoreHouseBindingModel model);

        StoreHouseViewModel GetElement(StoreHouseBindingModel model);

        void Insert(StoreHouseBindingModel model);

        void Update(StoreHouseBindingModel model);

        void Delete(StoreHouseBindingModel model);

        bool WriteOff(int count, Dictionary<int, (string, int)> travelComponents);
    }
}