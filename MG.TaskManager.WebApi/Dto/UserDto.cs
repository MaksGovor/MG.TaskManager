using System.ComponentModel.DataAnnotations;

namespace MG.TaskManager.WebApi.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Login can not be empty")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "PasswordHash can not be empty")]
        public string PasswordHash { get; set; }
    }
}
