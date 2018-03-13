using System;

using System.Linq;
using System.Collections.Generic;
using Homework02.Models;


namespace Homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>();

            users.Add(new User { Name = "Dave", Password = "hello" });
            users.Add(new User { Name = "Steve", Password = "steve" });
            users.Add(new User { Name = "Lisa", Password = "hello" });

            var passwordQuery =
                from user in users
                where user.Password == "hello"
                select user;
            Console.WriteLine("// printing out the list of users with password \"hello\": ");

            foreach (User user in passwordQuery)
            {
                Console.WriteLine($"Username: {user.Name} - Password: {user.Password}");
            }
            Console.WriteLine();

            users.RemoveAll(user => user.Password == user.Name.ToLower());
            Console.WriteLine("// removed users with password equal to their name in losercase");

            users.Remove(users.FirstOrDefault(user => user.Password == "hello"));
            Console.WriteLine("// removed first user with password \"hello\"");
            
            Console.WriteLine();
            Console.WriteLine("// printing out the list of remaining users: ");
            foreach (User user in users)
            {
                Console.WriteLine($"Username: {user.Name} - Password: {user.Password}");
            }

            Console.ReadLine();
        }
    }
}
