using AutoMapper;
using Back.Models.DTO;

namespace Back.Models.Profiles
{
    public class PetProfile: Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetDTO>();
            CreateMap<PetDTO, Pet>();
        }
    }
}
