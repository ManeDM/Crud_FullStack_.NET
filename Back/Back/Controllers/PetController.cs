using AutoMapper;
using Back.Models;
using Back.Models.DTO;
using Back.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase 
    {   
        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository; 

        public PetController( IMapper mapper, IPetRepository petRepository)
        {
            _mapper = mapper;
            _petRepository = petRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            { 
                var PetList = await _petRepository.GetPetList(); 

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
                var Pet = await _petRepository.GetPet(id);
                if (Pet == null)
                {
                    return NotFound();
                }

                var petDTO = _mapper.Map<PetDTO>(Pet);

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
                var Pet = await _petRepository.GetPet(id);
                if (Pet == null)
                {
                    return NotFound();
                }

                await _petRepository.DeletePet(Pet);

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
                
                pet = await _petRepository.AddPet(pet);

                var petItemDto = _mapper.Map<PetDTO>(pet);

                return CreatedAtAction("Get", new { id = pet.Id }, petItemDto);
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

                var petValue = await _petRepository.GetPet(id);

                if (petValue == null)
                {
                    return NotFound();
                }

                await _petRepository.UpdatePet(pet);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
