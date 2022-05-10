using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.BLL.Interface
{
    public interface IUserService
    {
        void SignUp(User user);
        User FindById(int id);
        User FindByLogin(string login);

        bool IsUserExist(int id);
        bool IsUserExistByLogin(string login);
    }
}
