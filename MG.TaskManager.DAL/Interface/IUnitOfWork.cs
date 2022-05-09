namespace MG.TaskManager.DAL.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        IProjectRepository Projects { get; }
        void Save();
    }
}
