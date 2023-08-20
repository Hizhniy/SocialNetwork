using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            while (true)
            {
                Console.Write("Для регистрации пользователя введите имя пользователя: ");
                string firstName = Console.ReadLine();

                Console.Write("Фамилия: ");
                string lastName = Console.ReadLine();

                Console.Write("Пароль: ");
                string password = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистрация произошла успешно!");
                }

                catch (ArgumentNullException)
                {
                    Console.WriteLine("Не все значения введены корректно... Попробуйте снова");
                }

                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка при регистрации...");
                }

                Console.ReadLine();
            }

        }
    }
}
