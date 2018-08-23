using AutoMapper;
using TaskProject.Dtos;
using TaskProject.Entities;

namespace TaskProject.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskEntity, TaskDto>().ReverseMap();
        }
    }
}
