namespace Back.Models.Repository
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetPetList();
        Task<Pet> GetPet(int id);
        Task DeletePet(Pet pet);
        Task<Pet> AddPet(Pet pet);
        Task UpdatePet(Pet pet);
    }
}
