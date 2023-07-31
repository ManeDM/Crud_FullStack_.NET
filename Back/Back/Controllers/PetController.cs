using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase 
    {   
        private readonly AplicationDbContext _context;

        public PetController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            { 
                var PetList = await _context.Pets.ToListAsync();
                return Ok(PetList);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Pet = await _context.Pets.FindAsync(id);
                if (Pet == null)
                {
                    return NotFound(); 
                }

                return Ok(Pet);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                var Pet = await _context.Pets.FindAsync(id);
                if (Pet == null) 
                {
                    return NotFound();
                }
                _context.Pets.Remove(Pet);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]

        public async Task<IActionResult> Post(Pet pet)
        {
            try
            {
                pet.CreationDate = DateTime.Now;
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = pet.Id}, pet);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pet pet)
        {
            try
            {
                if(id != pet.Id) 
                {
                    return BadRequest();
                }

                var petValue = await _context.Pets.FindAsync(id);

                if(petValue == null)
                {
                    return NotFound();
                }
                 
                petValue.Name = pet.Name;
                petValue.Age = pet.Age;
                petValue.Breed = pet.Breed;
                petValue.Color = pet.Color;
                petValue.Weight = pet.Weight;

                await _context.SaveChangesAsync();

                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

      
}
