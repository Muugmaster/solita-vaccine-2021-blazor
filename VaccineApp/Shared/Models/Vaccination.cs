using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineApp.Shared.Models
{
    public class Vaccination
    {
        [Key]
        [MaxLength(200)]
        public string Vaccination_id { get; set; }
        [MaxLength(200)]
        public string SourceBottle { get; set; }
        [MaxLength(20)]
        public string Gender { get; set; }
        public DateTime VaccinationDate { get; set; }

        [ForeignKey("SourceBottle")]
        public Order Order { get; set; }
    }
}
