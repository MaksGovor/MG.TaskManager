using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.DAL.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User FindById(int id);
        User FindByLogin(string login);
    }
}
