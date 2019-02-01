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
    public class MovementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Movement> _movementRepository;

        public MovementController(IMapper mapper, IAsyncRepository<Movement> movementRepository)
        {
            _mapper = mapper;
            _movementRepository = movementRepository;
        }

        [HttpGet("{id}", Name = nameof(GetMovementById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMovementById(int id)
        {
            var movement = await _movementRepository.GetByIdAsync(id);

            if (movement == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MovementDTO>(movement));
        }

        // POST: api/Movement
        [HttpPost(Name = nameof(CreateMovement))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMovement([FromBody]MovementDTO movementDto)
        {
            if (movementDto == null)
            {
                return BadRequest();
            }

            var movement = _mapper.Map<Movement>(movementDto);
            await _movementRepository.AddAsync(movement);

            return CreatedAtAction(nameof(GetMovementById), new { id = movement.Id }, movement);
        }

    }
}
