using MG.TaskManager.DAL.Entity;

namespace MG.TaskManager.BLL.Validation
{
    class UserValidation
    {
        public static bool checkValidInput(User userDto)
        {
            return (
                userDto.Login != null && !userDto.Login.Equals(string.Empty) &&
                userDto.FirstName != null && !userDto.FirstName.Equals(string.Empty) &&
                userDto.LastName != null && !userDto.LastName.Equals(string.Empty) &&
                userDto.PasswordHash != null && !userDto.PasswordHash.Equals(string.Empty)
                );
        }
    }
}
