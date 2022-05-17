using System.ComponentModel.DataAnnotations;

namespace MG.TaskManager.WebApi.Dto
{
    public class UserResponseDto
    {
        [Required(ErrorMessage = "UserId can not be empty")]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Login can not be empty")]
        public string Login { get; set; }
    }

    public class UserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login can not be empty")]
        public string Login { get; set; }

        [Required(ErrorMessage = "PasswordHash can not be empty")]
        public string PasswordHash { get; set; }
    }
}
