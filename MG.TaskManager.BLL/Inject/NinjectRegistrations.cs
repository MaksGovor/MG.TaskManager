using MG.TaskManager.BLL.Interface;
using MG.TaskManager.BLL.Service;
using MG.TaskManager.DAL.Interface;
using MG.TaskManager.DAL.Repository;
using Ninject.Modules;

namespace MG.TaskManager.BLL.Inject
{
    class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<ITaskRepository>().To<TaskRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IUserService>().To<UserService>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<ITaskService>().To<TaskService>();
        }
    }
}
