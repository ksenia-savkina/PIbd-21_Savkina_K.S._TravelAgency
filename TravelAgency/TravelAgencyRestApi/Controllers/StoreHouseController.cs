using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.BusinessLogics;
using TravelAgencyBusinessLogic.ViewModels;

namespace TravelAgencyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreHouseController : ControllerBase
    {
        private readonly StoreHouseLogic _logicS;

        private readonly ComponentLogic _logicC;

        public StoreHouseController(StoreHouseLogic storeHouseLogic, ComponentLogic componentLogic)
        {
            _logicS = storeHouseLogic;
            _logicC = componentLogic;
        }

        [HttpGet]
        public List<StoreHouseViewModel> Get() => _logicS.Read(null);

        [HttpGet]
        public List<ComponentViewModel> GetComponents() => _logicC.Read(null);

        [HttpPost]
        public void Create(StoreHouseBindingModel model) => _logicS.CreateOrUpdate(model);

        [HttpPost]
        public void Update(StoreHouseBindingModel model) => _logicS.CreateOrUpdate(model);

        [HttpPost]
        public void Delete(StoreHouseBindingModel model) => _logicS.Delete(model);

        [HttpPost]
        public void Refill(StoreHouseRefillBindingModel model) => _logicS.Refill(model);
    }
}