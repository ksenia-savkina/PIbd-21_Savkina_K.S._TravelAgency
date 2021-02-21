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

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Travel> Travels { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Travels = LoadTravels();
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
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value, true),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = String.IsNullOrEmpty(elem.Element("DateImplement").Value) ? DateTime.MinValue : Convert.ToDateTime(elem.Element("DateImplement").Value),
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
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
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
                foreach (var Travel in Travels)
                {
                    var compElement = new XElement("TravelComponents");
                    foreach (var component in Travel.TravelComponents)
                    {
                        compElement.Add(new XElement("TravelComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Travel",
                    new XAttribute("Id", Travel.Id),
                    new XElement("TravelName", Travel.TravelName),
                    new XElement("Price", Travel.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(TravelFileName);
            }
        }
    }
}