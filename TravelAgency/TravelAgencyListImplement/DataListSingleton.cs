using System.Collections.Generic;
using TravelAgencyListImplement.Models;

namespace TravelAgencyListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Travel> Travels { get; set; }

        public List<StoreHouse> StoreHouses { get; set; }

        public List<Client> Clients { get; set; }

        public List<Implementer> Implementers { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Travels = new List<Travel>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            StoreHouses = new List<StoreHouse>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}