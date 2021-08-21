using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineApp.Shared.Models
{
    public class Order
    {
        [Key]
        [MaxLength(200)]
        public string Id { get; set; }
        public int OrderNumber { get; set; }
        [MaxLength(100)]
        public string ResponsiblePerson { get; set; }
        [MaxLength(20)]
        public string HealthCareDistrict { get; set; }
        [MaxLength(50)]
        public string Vaccine { get; set; }
        public int Injections { get; set; }
        public DateTime Arrived { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
    }
}
