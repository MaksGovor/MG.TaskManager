using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG.TaskManager.DAL.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        [Required]
        public string Login { get; set; }
    
        [Required]
        public string PasswordHash { get; set; }
    
        public virtual IEnumerable<Project> Projects { get; set; }
        public virtual IEnumerable<Task> Tasks { get; set; }
    }
}
