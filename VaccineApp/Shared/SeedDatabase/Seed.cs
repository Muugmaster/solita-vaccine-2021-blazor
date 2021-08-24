﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineApp.Shared.Models;

namespace VaccineApp.Shared.SeedDatabase
{
    public class Seed
    {
        public List<Vaccination> SeedVaccinationData()
        {
            var vaccinations = new List<Vaccination>();
            using (StreamReader r = new StreamReader(@"Data\Initial\vaccinations.json", Encoding.UTF8))
            {
                string json = r.ReadToEnd();
                vaccinations = JsonConvert.DeserializeObject<List<Vaccination>>(json);
            }
            return vaccinations;
        }

        public List<Order> SeedOrderData()
        {
            string[] orderFiles = new string[] { "Data\\Initial\\zerpfy.json", "Data\\Initial\\solarBuddhica.json", "Data\\Initial\\antiqua.json" };
            var orders = new List<Order>();
            var temp = new List<Order>();
            foreach (var file in orderFiles)
            {
                using (StreamReader r = new StreamReader(file, Encoding.UTF8))
                {
                    string json = r.ReadToEnd();
                    temp = JsonConvert.DeserializeObject<List<Order>>(json);
                }
                orders.AddRange(temp);
            }

            return orders;
        }
    }
}
