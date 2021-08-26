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
        private readonly char separator = Path.DirectorySeparatorChar;
        public List<Vaccination> SeedVaccinationData()
        {
            var vaccinations = new List<Vaccination>();
            using (StreamReader r = new StreamReader($"Data{separator}Initial{separator}vaccinations.json", Encoding.GetEncoding("iso-8859-1")))
            {
                string json = r.ReadToEnd();
                vaccinations = JsonConvert.DeserializeObject<List<Vaccination>>(json);
            }
            return vaccinations;
        }

        public List<Order> SeedOrderData()
        {
            string[] orderFiles = new string[] { $"Data{separator}Initial{separator}zerpfy.json", $"Data{separator}Initial{separator}solarBuddhica.json", $"Data{separator}Initial{separator}antiqua.json" };
            var orders = new List<Order>();
            var temp = new List<Order>();
            foreach (var file in orderFiles)
            {
                using (StreamReader r = new StreamReader(file, Encoding.GetEncoding("iso-8859-1")))
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
