using AutoMapper;
using Back.Models;
using Back.Models.DTO;
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
        private readonly IMapper _mapper;

        public PetController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            { 
                var PetList = await _context.Pets.ToListAsync();

                var PetListDTO = _mapper.Map<IEnumerable<PetDTO>>(PetList);

                return Ok(PetListDTO);

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

                var petDTO =   _mapper.Map<PetDTO>(Pet);

                return Ok(petDTO);
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

        public async Task<IActionResult> Post(PetDTO petDto)
        {
            try
            {
                var pet = _mapper.Map<Pet>(petDto);

                pet.CreationDate = DateTime.Now;
                _context.Add(pet);
                await _context.SaveChangesAsync();

                var petItemDto = _mapper.Map<PetDTO>(pet);

                return CreatedAtAction("Get", new { id = pet.Id}, petItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PetDTO petDto)
        {
            try
            {
                var pet = _mapper.Map<Pet>(petDto);

                if (id != pet.Id) 
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

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

      
}
