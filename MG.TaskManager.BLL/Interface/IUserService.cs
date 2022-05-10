using MG.TaskManager.DAL.Entity;
using System.Collections.Generic;

namespace MG.TaskManager.BLL.Interface
{
    public interface IUserService
    {
        void SignUp(User user);
        User FindById(int id);
        User FindByLogin(string login);
        IEnumerable<User> GetAll();
        bool IsUserExist(int id);
        bool IsUserExistByLogin(string login);
    }
}
