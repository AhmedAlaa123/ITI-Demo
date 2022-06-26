using AutoMapper;
using Day2.Models;
using Day2.Models.Instructors;

namespace Day2.Helper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Instructor,InstructorCreateDTO>().ReverseMap();
        }
    }
}
