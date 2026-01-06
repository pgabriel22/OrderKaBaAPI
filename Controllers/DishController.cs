using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderKaBA.DatabaseConnection;
using OrderKaBA.DTOs;
using OrderKaBA.Models;
using System.Threading.Tasks;

namespace OrderKaBA.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly OrderKaBaDbContext _context;
        private readonly IMapper _mapper;

        public DishController(OrderKaBaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get all dishes
        [HttpGet]
        public async Task<IActionResult> GetDishes()
        {
            var dishes = await _context.Dishes.ToListAsync();
            var dishDtos = _mapper.Map<List<DishReadDto>>(dishes);
            return Ok(dishDtos);
        }

        //Get dish by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDish(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DishReadDto>(dish));
        }

        //Create Dish
        [HttpPost]
        public async Task<IActionResult> CreateDish(DishCreateDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dish = _mapper.Map<Dish>(dto);

            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            var readDto = _mapper.Map<DishReadDto>(dish);

            return CreatedAtAction(nameof(GetDish), new { id = dish.Id }, readDto);
        }

        //Update Dish
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish(int id, DishUpdateDto dto)
        {
           if (!ModelState.IsValid)
           {
                return BadRequest(ModelState);
           }
           var dish = await _context.Dishes.FindAsync(id);
           if  (dish == null)
           {
                return NotFound();
            }
           _mapper.Map(dto, dish);

           await _context.SaveChangesAsync();

            return NoContent();
        }

        //Delete Dish
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            _context.Dishes.Remove(dish);
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
