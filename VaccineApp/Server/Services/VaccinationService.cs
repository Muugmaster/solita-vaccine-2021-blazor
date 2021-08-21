using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Server.Data;
using VaccineApp.Server.Services.Interfaces;
using VaccineApp.Shared.Models;

namespace VaccineApp.Server.Services
{
    public class VaccinationService : IVaccinationService
    {
        private readonly DataContext _context;
        public VaccinationService(DataContext context)
        {
            _context = context;
        }
        public async Task<Vaccination> GetVaccination(string id)
        {
            return await _context.Vaccinations.FirstOrDefaultAsync(v => v.Vaccination_id == id);
        }

        public async Task<List<Vaccination>> GetVaccinations()
        {
            return await _context.Vaccinations.ToListAsync();
        }
    }
}
