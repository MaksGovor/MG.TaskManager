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

                cfg.CreateMap<Project, ProjectResponseDto>()
                    .ForMember("Owner", opt => opt.MapFrom(p => p.User));
                cfg.CreateMap<ProjectRequestDto, Project>()
                    .ForMember("UserId", opt => opt.MapFrom(p => p.OwnerId));

                cfg.CreateMap<Task, TaskResponseDto>()
                    .ForMember("Executor", opt => opt.MapFrom(p => p.User))
                    .ForMember("Project", opt => opt.MapFrom(p => p.Project));
                cfg.CreateMap<TaskRequestDto, Task>()
                    .ForMember("UserId", opt => opt.MapFrom(p => p.ExecutorId));
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}