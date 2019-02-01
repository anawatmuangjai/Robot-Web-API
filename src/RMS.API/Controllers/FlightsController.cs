using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.API.Dtos;
using RMS.Core.Entities;
using RMS.Core.Interfaces;

namespace RMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Flight> _flightRepository;

        public FlightsController(IMapper mapper, IAsyncRepository<Flight> flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _flightRepository.GetAllAsync();
            var flightDtos = _mapper.Map<List<FlightDTO>>(flights);
            return Ok(flightDtos);
        }

        [HttpGet("{id}", Name = nameof(GetFlightById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FlightDTO>(flight));
        }

        [HttpPost(Name = nameof(CreateFlight))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFlight([FromBody]FlightDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var flight = _mapper.Map<Flight>(dto);
            await _flightRepository.AddAsync(flight);

            return CreatedAtAction(nameof(GetFlightById), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}", Name = nameof(UpdateFlight))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody]FlightDTO dto)
        {
            var oldFlight = await _flightRepository.GetByIdAsync(id);

            if (oldFlight == null)
            {
                return BadRequest();
            }

            _mapper.Map(dto, oldFlight);

            await _flightRepository.UpdateAsync(oldFlight);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteFlightById))]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFlightById(int id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            await _flightRepository.DeleteAsync(flight);

            return NoContent();
        }
    }
}