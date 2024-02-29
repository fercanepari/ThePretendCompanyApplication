using System;
using TCPData;
using TCPExtensions;

namespace ThePretendCompanyApplication // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();

            var filteredEmployees = employeeList.Filter(emp => emp.AnnualSalary < 50000);

            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual salary: {employee.AnnualSalary}");
                Console.WriteLine($"Manager: {employee.IsManager}");
                Console.WriteLine($" ");
            }

            Console.ReadKey();
        }
    }
}