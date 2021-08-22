using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VaccineApp.Shared.Models;

namespace VaccineApp.Server.Dtos
{
    public class VaccinationDto
    {
        [MaxLength(200)]
        public string Vaccination_id { get; set; }
        [MaxLength(200)]
        public string SourceBottle { get; set; }
        [MaxLength(20)]
        public string Gender { get; set; }
        public DateTime VaccinationDate { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
    }
}
