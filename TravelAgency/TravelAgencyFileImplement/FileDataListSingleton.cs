using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TravelAgencyBusinessLogic.Enums;
using TravelAgencyFileImplement.Models;

namespace TravelAgencyFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string TravelFileName = "Travel.xml";

        private readonly string ClientFileName = "Client.xml";

        private readonly string StoreHouseFileName = "StoreHouse.xml";

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Travel> Travels { get; set; }

        public List<Client> Clients { get; set; }

        public List<StoreHouse> StoreHouses { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Travels = LoadTravels();
            Clients = LoadClients();
            StoreHouses = LoadStoreHouses();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveTravels();
            SaveClients();
            SaveStoreHouses();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TravelId = Convert.ToInt32(elem.Element("TravelId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Convert.ToInt32(elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = String.IsNullOrEmpty(elem.Element("DateImplement").Value) ? DateTime.MinValue : Convert.ToDateTime(elem.Element("DateImplement").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value)
                    });
                }
            }
            return list;
        }

        private List<Travel> LoadTravels()
        {
            var list = new List<Travel>();
            if (File.Exists(TravelFileName))
            {
                XDocument xDocument = XDocument.Load(TravelFileName);
                var xElements = xDocument.Root.Elements("Travel").ToList();
                foreach (var elem in xElements)
                {
                    var travComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("TravelComponents").Elements("TravelComponent").ToList())
                    {
                        travComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Travel
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TravelName = elem.Element("TravelName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        TravelComponents = travComp
                    });
                }
            }
            return list;
        }

        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }

        private List<StoreHouse> LoadStoreHouses()
        {
            var list = new List<StoreHouse>();
            if (File.Exists(StoreHouseFileName))
            {
                XDocument xDocument = XDocument.Load(StoreHouseFileName);
                var xElements = xDocument.Root.Elements("StoreHouse").ToList();
                foreach (var elem in xElements)
                {
                    var storComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("StoreHouseComponents").Elements("StoreHouseComponent").ToList())
                    {
                        storComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new StoreHouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StoreHouseName = elem.Element("StoreHouseName").Value,
                        ResponsiblePersonFullName = elem.Element("ResponsiblePersonFullName").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        StoreHouseComponents = storComp
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("TravelId", order.TravelId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", (int)order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement),
                    new XElement("ClientId", order.ClientId)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveTravels()
        {
            if (Travels != null)
            {
                var xElement = new XElement("Travels");
                foreach (var travel in Travels)
                {
                    var compElement = new XElement("TravelComponents");
                    foreach (var component in travel.TravelComponents)
                    {
                        compElement.Add(new XElement("TravelComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Travel",
                    new XAttribute("Id", travel.Id),
                    new XElement("TravelName", travel.TravelName),
                    new XElement("Price", travel.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(TravelFileName);
            }
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }

        private void SaveStoreHouses()
        {
            if (StoreHouses != null)
            {
                var xElement = new XElement("StoreHouses");
                foreach (var storeHouse in StoreHouses)
                {
                    var compElement = new XElement("StoreHouseComponents");
                    foreach (var component in storeHouse.StoreHouseComponents)
                    {
                        compElement.Add(new XElement("StoreHouseComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("StoreHouse",
                    new XAttribute("Id", storeHouse.Id),
                    new XElement("StoreHouseName", storeHouse.StoreHouseName),
                    new XElement("ResponsiblePersonFullName", storeHouse.ResponsiblePersonFullName),
                    new XElement("DateCreate", storeHouse.DateCreate),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StoreHouseFileName);
            }
        }
    }
}