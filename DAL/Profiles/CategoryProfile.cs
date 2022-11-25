using AutoMapper;
using DTO;

namespace DAL.Profiles
{
    class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<category, CategoryDTO>().ReverseMap();
        }
    }
}
