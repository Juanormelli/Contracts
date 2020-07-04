using ExercicioCsharp.Entities;
using ExercicioCsharp.Entities.Enums;
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace ExercicioCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Departament´s Name:");
            string nameofdep = Console.ReadLine();
            Console.WriteLine("Enter Worker Data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior- MidLevel-Senior: ");
            WorkLevel level = Enum.Parse<WorkLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseslary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department dept = new Department(nameofdep);
            Worker worker = new Worker(name, level, baseslary, dept);

            Console.Write("How Many contracts to this worker: ");
            int contract = int.Parse(Console.ReadLine());

            for (int i = 1; i <= contract; i++)
            {
                Console.WriteLine($"Enter #{i} Contract Data");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value Per Hour ");
                double valueperhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours)");
                int hours = int.Parse(Console.ReadLine());
                HourContract w1 = new HourContract(date, valueperhour, hours);
                worker.AddContract(w1);
            }
            Console.WriteLine();

            Console.Write("Enter month and year to calculate income: (MM/YYYY) ");
            string MonthAndYear = Console.ReadLine();
            int month = int.Parse (MonthAndYear.Substring(0, 2));
            int year = int.Parse(MonthAndYear.Substring(3));

            Console.Write("Name: "+worker.Name);
            Console.WriteLine("Department: "+worker.Department.Name);


            Console.Write("Income for: " + worker.Income(year, month));




        }
    }
}
