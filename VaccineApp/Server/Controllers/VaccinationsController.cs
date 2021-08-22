using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Server.Dtos;
using VaccineApp.Server.Services.Interfaces;

namespace VaccineApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationsController : ControllerBase
    {
        private readonly IVaccinationService _vaccinationService;
        private readonly IMapper _mapper;
        public VaccinationsController(IVaccinationService vaccinationService, IMapper mapper)
        {
            _vaccinationService = vaccinationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VaccinationDto>>> GetVaccinations()
        {
            try
            {
                var vaccinations = await _vaccinationService.GetVaccinations();
                var mappedVaccinations = _mapper.Map<List<VaccinationDto>>(vaccinations);
                return Ok(mappedVaccinations);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VaccinationDto>> GetVaccination(string id)
        {
            try
            {
                var vaccination = await _vaccinationService.GetVaccination(id);
                var mappedVaccination = _mapper.Map<VaccinationDto>(vaccination);
                if (vaccination == null)
                {
                    return NotFound("Could not find vaccination with given ID");
                }

                return Ok(mappedVaccination);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
