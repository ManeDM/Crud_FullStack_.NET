using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly AplicationDbContext _context;

        public PetRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> GetPetList()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPet(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task DeletePet(Pet pet)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task UpdatePet(Pet pet)
        {
            var petValue = await _context.Pets.FirstOrDefaultAsync(x => x.Id == pet.Id);

            if (petValue != null)
            {
                petValue.Name = pet.Name;
                petValue.Age = pet.Age;
                petValue.Breed = pet.Breed;
                petValue.Color = pet.Color;
                petValue.Weight = pet.Weight;

                await _context.SaveChangesAsync();
            }
            
        }
    }
}
