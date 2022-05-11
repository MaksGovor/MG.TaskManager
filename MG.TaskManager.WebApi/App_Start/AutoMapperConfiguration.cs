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
                cfg.CreateMap<User, UserResponseDto>();
                cfg.CreateMap<UserRequestDto, User>();

                cfg.CreateMap<Project, ProjectResponceDto>()
                    .ForMember("OwnerId", opt => opt.MapFrom(p => p.UserId));
                cfg.CreateMap<ProjectRequestDto, Project>()
                    .ForMember("UserId", opt => opt.MapFrom(p => p.OwnerId));

                cfg.CreateMap<Task, TaskResponseDto>()
                    .ForMember("ExecutorId", opt => opt.MapFrom(p => p.UserId));
                cfg.CreateMap<TaskRequestDto, Task>()
                    .ForMember("UserId", opt => opt.MapFrom(p => p.ExecutorId));
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}