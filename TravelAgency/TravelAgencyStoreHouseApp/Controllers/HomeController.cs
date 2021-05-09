using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TravelAgencyBusinessLogic.BindingModels;
using TravelAgencyBusinessLogic.ViewModels;
using TravelAgencyStoreHouseApp.Models;

namespace TravelAgencyStoreHouseApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            if (!Program.Authorized)
            {
                return Redirect("~/Home/Privacy");
            }
            return View(APIStoreHouse.GetRequest<List<StoreHouseViewModel>>($"api/storehouse/get"));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public void Privacy(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                Program.Authorized = password == configuration["Password"];

                if (!Program.Authorized)
                {
                    throw new Exception("Неверный пароль");
                }

                Response.Redirect("Index");
                return;
            }

            throw new Exception("Введите пароль");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!Program.Authorized)
            {
                return Redirect("~/Home/Privacy");
            }
            return View();
        }

        [HttpPost]
        public void Create(string name, string responsibleFIO)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsibleFIO))
            {
                APIStoreHouse.PostRequest("api/storehouse/create", new StoreHouseBindingModel
                {
                    StoreHouseName = name,
                    ResponsiblePersonFullName = responsibleFIO,
                    DateCreate = DateTime.Now,
                    StoreHouseComponents = new Dictionary<int, (string, int)>()
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите название и ФИО ответственного");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouse = APIStoreHouse.GetRequest<List<StoreHouseViewModel>>($"api/storehouse/get")
            .FirstOrDefault(rec => rec.Id == id);

            if (storehouse == null)
            {
                return NotFound();
            }

            ViewBag.StoreHouseComponents = storehouse.StoreHouseComponents.Values;
            ViewBag.Name = storehouse.StoreHouseName;
            ViewBag.ResponsibleFIO = storehouse.ResponsiblePersonFullName;
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, string name, string responsibleFIO)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsibleFIO))
            {
                var storehouse = APIStoreHouse.GetRequest<List<StoreHouseViewModel>>($"api/storehouse/get")
                .FirstOrDefault(rec => rec.Id == id);
                if (storehouse == null)
                {
                    return NotFound();
                }
                APIStoreHouse.PostRequest($"api/storehouse/update", new StoreHouseBindingModel
                {
                    Id = storehouse.Id,
                    StoreHouseName = name,
                    ResponsiblePersonFullName = responsibleFIO,
                    DateCreate = storehouse.DateCreate,
                    StoreHouseComponents = storehouse.StoreHouseComponents
                });
                return Redirect("~/Home/Index");
            }
            throw new Exception("Введите название и ФИО ответственного");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storehouse = APIStoreHouse.GetRequest<List<StoreHouseViewModel>>($"api/storehouse/get")
            .FirstOrDefault(rec => rec.Id == id);
            if (storehouse == null)
            {
                return NotFound();
            }

            ViewBag.Id = id;
            ViewBag.StoreHouseComponents = storehouse.StoreHouseComponents.Values;
            ViewBag.Name = storehouse.StoreHouseName;
            ViewBag.ResponsibleFIO = storehouse.ResponsiblePersonFullName;

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            APIStoreHouse.PostRequest($"api/storehouse/delete", new StoreHouseBindingModel { Id = id });
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Refill()
        {
            if (!Program.Authorized)
            {
                return Redirect("~/Home/Privacy");
            }
            ViewBag.StoreHouses = APIStoreHouse.GetRequest<List<StoreHouseViewModel>>($"api/storehouse/get");
            ViewBag.Components = APIStoreHouse.GetRequest<List<ComponentViewModel>>($"api/storehouse/getComponents");

            return View();
        }

        [HttpPost]
        public void Refill(int storehouse, int component, int count)
        {
            APIStoreHouse.PostRequest("api/storehouse/refill", new StoreHouseRefillBindingModel
            {
                StoreHouseId = storehouse,
                ComponentId = component,
                Count = count
            });
            Response.Redirect("Index");
        }
    }
}
