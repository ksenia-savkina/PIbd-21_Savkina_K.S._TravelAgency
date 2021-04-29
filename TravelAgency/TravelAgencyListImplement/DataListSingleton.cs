﻿using System.Collections.Generic;
using TravelAgencyListImplement.Models;

namespace TravelAgencyListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Travel> Travels { get; set; }

        public List<Client> Clients { get; set; }

        public List<Implementer> Implementers { get; set; }

        public List<MessageInfo> MessagesInfo { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Travels = new List<Travel>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessagesInfo = new List<MessageInfo>();
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