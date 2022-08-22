using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Euri_backend.Data;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Repository.Interfaces;

namespace Euri_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketsController(IBasketRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Baskets
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BasketDto>))]
        public async Task<ActionResult<IEnumerable<BasketDto>>> GetBaskets()
        {
            var baskets = await _repository.GetAllBaskets();
            var basketsDtos = baskets.Select(b => new BasketDto(b));

            return Ok(basketsDtos);
        }

        // GET: api/Baskets/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BasketDto>> GetBasketModel(int id)
        {
            var basketModel = await _repository.GetBasket(id);

            if (basketModel == null)
            {
                return NotFound();
            }

            return Ok(new BasketDto(basketModel));
        }

        // PUT: api/Baskets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBasketModel(int id, UpdateBasketDto basketDto)
        {
            if (id != basketDto.Id)
            {
                return BadRequest();
            }

            var newBasket = await _repository.UpdateBasket(basketDto.ToBasketModel());

            if (newBasket == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Baskets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BasketDto))]
        public async Task<ActionResult<BasketModel>> PostBasketModel(CreateBasketDto basketDto)
        {
            var basketEntity = await _repository.CreateBasket(basketDto.ToBasketModel());

            return CreatedAtAction("GetBasketModel", new { id = basketEntity.Id }, new BasketDto(basketEntity));
        }

        // DELETE: api/Baskets/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBasketModel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var basketModel = await _repository.DeleteBasket(id);
            if (basketModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
