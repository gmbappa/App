using APP.DTO;
using APP.Model;
using AutoMapper;

namespace APP.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
           
            CreateMap<Company, CompanyDTO>()
               .ReverseMap();

            CreateMap<PersonalInfo, PersonalInfoDTO>()
              .ReverseMap();

            CreateMap<Experience, ExperienceDTO>()
              .ReverseMap();

            CreateMap<Project, ProjectDTO>()
             .ReverseMap();

            CreateMap<Education, EducationDTO>()
             .ReverseMap();
        }
    }
}
