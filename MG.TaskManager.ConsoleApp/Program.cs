using MG.TaskManager.BLL.Service;
using MG.TaskManager.DAL.Entity;
using MG.TaskManager.DAL.EntityFramework;
using MG.TaskManager.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MG.TaskManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            UserService userService = new UserService(unitOfWork);

            userService.SignUp(new User() { FirstName = "Oleg", LastName = "Konoval", Login = "okonoval", PasswordHash = "ABCDADAD" });
            Console.WriteLine("Hello");
            Console.ReadLine();
        }
    }
}
