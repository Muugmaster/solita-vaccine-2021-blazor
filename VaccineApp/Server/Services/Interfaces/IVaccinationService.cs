using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Shared.Models;

namespace VaccineApp.Server.Services.Interfaces
{
    public interface IVaccinationService
    {
        Task<List<Vaccination>> GetVaccinations();
        Task<Vaccination> GetVaccination(string id);
    }
}
