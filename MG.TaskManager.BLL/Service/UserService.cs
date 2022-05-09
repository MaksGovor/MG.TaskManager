
using MG.TaskManager.BLL.Interface;
using MG.TaskManager.BLL.Validation;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.DAL.Interface;

namespace MG.TaskManager.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User defaultUser = default(User);

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SignUp(User user)
        {
            if (!UserValidation.checkValidInput(user))
            {
                throw new BusinessLogicException("User is not valid");
            }

            if (IsUserExistByLogin(user.Login))
            {
                throw new BusinessLogicException("User with this login is already exist");
            }

            _unitOfWork.Users.Create(user);
            _unitOfWork.Save();
        }

        public User FindByLogin(string login)
        {
            return _unitOfWork.Users.FindByLogin(login);
        }

        public bool IsUserExistByLogin(string login)
        {
            return FindByLogin(login) != defaultUser;
        }

        public User FindById(int id)
        {
            return _unitOfWork.Users.FindById(id);
        }

        public bool IsUserExist(int id)
        {
            return FindById(id) != null;
        }

        public void DeleteById(int id)
        {
            if (!IsUserExist(id))
            {
                throw new BusinessLogicException("User with such id does not exist. Id: " + id);
            }

            _unitOfWork.Users.Delete(id);
        }
    }
}
