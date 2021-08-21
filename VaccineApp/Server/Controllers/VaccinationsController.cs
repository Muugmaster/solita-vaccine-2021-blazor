using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Server.Services.Interfaces;

namespace VaccineApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationsController : ControllerBase
    {
        private readonly IVaccinationService _vaccinationService;
        public VaccinationsController(IVaccinationService vaccinationService)
        {
            _vaccinationService = vaccinationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVaccinations()
        {
            var vaccinations = await _vaccinationService.GetVaccinations();
            return Ok(vaccinations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVaccination(string id)
        {
            var vaccination = await _vaccinationService.GetVaccination(id);
            if (vaccination == null)
            {
                return NotFound("Could not find vaccination with given ID");
            }

            return Ok(vaccination);
        }
    }
}
