using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class OriginsController : ControllerBase
    {
        private readonly IAsyncRepository<Origin> _originRepository;

        public OriginsController(IAsyncRepository<Origin> originRepository)
        {
            _originRepository = originRepository;
        }

        // GET: api/Origins
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetOrigins()
        {
            var origins = await _originRepository.GetAllAsync();
            return Ok(origins);
        }

        // GET: api/Origins
        [HttpGet("{id}", Name = nameof(GetOriginById))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetOriginById(int id)
        {
            var origin = await _originRepository.GetByIdAsync(id);

            if (origin == null)
            {
                return NotFound();
            }

            return Ok(origin);
        }

        // POST: api/Origins
        [HttpPost(Name = nameof(CreateOrigin))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOrigin([FromBody]Origin origin)
        {
            if (origin == null)
            {
                return BadRequest();
            }

            await _originRepository.AddAsync(origin);

            return CreatedAtAction(nameof(GetOriginById), new { id = origin.Id }, origin);
        }

        [HttpPut("{id}", Name = nameof(UpdateOrigin))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrigin(int id, [FromBody]Origin origin)
        {
            var oldOrigin = _originRepository.GetByIdAsync(id);

            if (oldOrigin == null)
            {
                return NotFound();
            }

            await _originRepository.UpdateAsync(origin);

            return NoContent();
        }


    }
}