using Newtonsoft.Json;
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
            using (StreamReader r = new StreamReader(@"data\vaccinations.json"))
            {
                string json = r.ReadToEnd();
                vaccinations = JsonConvert.DeserializeObject<List<Vaccination>>(json);
            }
            return vaccinations;
        }

        public List<Order> SeedOrderData()
        {
            string[] orderFiles = new string[] { "data\\zerpfy.json", "data\\solarBuddhica.json", "data\\antiqua.json" };
            var orders = new List<Order>();
            var temp = new List<Order>();
            foreach (var file in orderFiles)
            {
                using (StreamReader r = new StreamReader(file))
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
