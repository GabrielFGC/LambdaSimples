using SalarioFuncionario.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SalarioFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                Console.Write("Enter full file path: ");
                string path = Console.ReadLine();
                Console.Write("Enter salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                using (StreamReader em = File.OpenText(path)) 
                {
                    while (!em.EndOfStream)
                    {
                        string[] partition = em.ReadLine().Split(',');
                        string name = partition[0];
                        string email = partition[1];
                        double money = double.Parse(partition[2], CultureInfo.InvariantCulture);

                        employees.Add(new Employee(name, email, money));
                    }
                }

                Console.WriteLine($"Email of people whose salary is more than {salary}");

                var prinEmail = employees.Where(p => p.Salary > salary).Select(p => p.Email);

                foreach (string item in prinEmail)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nSum of salary of people whose name starts with:");
                char letter = char.Parse(Console.ReadLine());

                var sum = employees.Where(p => p.Name.Contains(letter)).Sum(p => p.Salary);

                Console.WriteLine($"\nSum ofsalary: {sum}");


            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
