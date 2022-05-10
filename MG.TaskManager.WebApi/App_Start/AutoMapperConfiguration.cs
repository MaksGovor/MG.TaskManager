using AutoMapper;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.WebApi.Dto;

namespace MG.TaskManager.WebApi.App_Start
{
    public class AutoMapperConfiguration
    {
        public static IMapper provideMaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();

                cfg.CreateMap<Project, ProjectDto>()
                    .ForMember("OwnerId", opt => opt.MapFrom(p => p.UserId));
                cfg.CreateMap<ProjectDto, Project>()
                    .ForMember("UserId", opt => opt.MapFrom(p => p.OwnerId));

                cfg.CreateMap<Task, TaskDto>()
                    .ForMember("ExecutorId", opt => opt.MapFrom(p => p.UserId));
                cfg.CreateMap<TaskDto, Task>()
                    .ForMember("UserId", opt => opt.MapFrom(p => p.ExecutorId));
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}