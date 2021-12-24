using Domain.Models;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class EmployeeController
    {
        private EmployeeService employeeService { get; }

        public EmployeeController()
        {
            employeeService = new EmployeeService();
        }

        public void Create()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add company id");
            EnterCompanyId: string id = Console.ReadLine();

            int companyid;

            bool isCompanyIdTrue = int.TryParse(id, out companyid);

            Helper.WritetoConsole(ConsoleColor.Cyan, "Employee name");
            string employeeName = Console.ReadLine();
            EnterAddress: Helper.WritetoConsole(ConsoleColor.Cyan, "Employee surname");
            string employeeSurname = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Company name");
            string companyName = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Employee age");
            string employeeAge = Console.ReadLine();


            int age;

            bool isAgeTrue = int.TryParse(employeeAge, out age);



            {
                if (isCompanyIdTrue)
                {
                    Employee employee = new Employee()
                    {
                        Name = employeeName,
                        Surname = employeeSurname,
                        Age = age
                    };
                    var result = employeeService.Create(employee, companyid);
                   
                    if (result != null)
                    {
                        Helper.WritetoConsole(ConsoleColor.Green, $"{employee.Id} - {employee.Name} - {employee.Surname} - {employee.Company.Name} - {employee.Age} - Employee created");
                    }
                    else
                    {
                        Helper.WritetoConsole(ConsoleColor.Red, "Something is wrong");
                        goto EnterCompanyId;
                    }

                }

            }

        }
        public void Update()
        {

        }
        public void GetById()
        {

        }
        public void Delete()
        {

        }
        public void GetByAge()
        {

        }
        public void GetByCompanyId()
        {

        }
        

    }
}
