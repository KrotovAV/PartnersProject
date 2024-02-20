using ConsoleApp1.DB;
using System.Collections;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var admin = new User();
            admin.Id = Guid.NewGuid();
            admin.Name = "KrotovAV@tut.by";
            string password = "Admin";
            admin.RoleId = 0;
            admin.Salt = new byte[16];
            new Random().NextBytes(admin.Salt); //Заполняет элементы указанного диапазона байтов случайными числами.

            var data = Encoding.ASCII.GetBytes(password).Concat(admin.Salt).ToArray();
            SHA512 shaM = new SHA512Managed();
            admin.Password = shaM.ComputeHash(data);

            /*
            Например, если массив байтов был создан следующим образом:
            byte[] bytes = Encoding.ASCII.GetBytes(someString);

            Вам нужно будет превратить его обратно в такую ​​строку:
            string someString = Encoding.ASCII.GetString(bytes);
             */
            if (admin.Salt != null && admin.Salt.Length > 0)
            {
                Console.WriteLine("OK");
                Console.WriteLine(admin.Salt.Length);
                string result2 = Encoding.ASCII.GetString(admin.Salt);
                Console.WriteLine(result2);
            }

        }
    }
}