using System;
using TCPData;
using TCPExtensions;
using System.Linq;

namespace ThePretendCompanyApplication // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            //Extension method and lambda function to filter
            //var filteredEmployees = employeeList.Filter(emp => emp.AnnualSalary < 50000);

            //After importing System.Linq We can use the 'Where' extended method
            var filteredEmployees = employeeList.Where(emp => emp.IsManager == true);

            //foreach (var employee in filteredEmployees)
            //{
            //Console.WriteLine($"First Name: {employee.FirstName}");
            //Console.WriteLine($"Last Name: {employee.LastName}");
            //Console.WriteLine($"Annual salary: {employee.AnnualSalary}");
            //Console.WriteLine($"Manager: {employee.IsManager}");
            //Console.WriteLine($" ");
            //}

            var resultList = from emp in employeeList
                             join dept in departmentList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = dept.LongName
                             };

            foreach (var employee in resultList)
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual salary: {employee.AnnualSalary}");
                Console.WriteLine($"Manager: {employee.Manager}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine($" ");
            }

            Console.ReadKey();
        }
    }
}