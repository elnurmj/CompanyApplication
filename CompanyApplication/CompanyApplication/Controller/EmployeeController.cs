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
        private CompanyService companyService{ get; }

        public EmployeeController()
        {
            employeeService = new EmployeeService();
            companyService = new CompanyService();
        }

        public void Create()
        {
            EnterOption:
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company Id: ");
            string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Employee name: ");
            string employeeName = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Employee surname: ");
            string employeeSurname = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Employee age: ");
            string employeeAge = Console.ReadLine();
            int age;
            bool isTrueAge = int.TryParse(employeeAge, out age);
            
            if (isTrueAge && isTrueId)
            {
                if (string.IsNullOrWhiteSpace(employeeName) || string.IsNullOrWhiteSpace(employeeSurname))
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Try again");
                    goto EnterOption;
                }
                else
                {
                    Employee employee = new Employee
                    {
                        Name = employeeName,
                        Surname = employeeSurname,
                        Age = age,

                    };
                    var createResult = employeeService.Create(employee, id);
                    if (createResult != null)
                    {
                        Helper.WritetoConsole(ConsoleColor.Green, $"{employee.Id} - {employee.Name} - {employee.Surname} - {employee.Age} - employee in {employee.Company.Name} created");
                    }
                    else
                    {
                        Helper.WritetoConsole(ConsoleColor.Red, "Company not found");
                        goto EnterOption;
                    }
                }
            }
            else
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Try again");
                goto EnterOption;
            }

        }
        public void Update()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Employee Id: ");
            EnterId:
            string employeeId = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add new Employee name: ");
            EnterName:
            string newName = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add new Employee surname: ");
            string newSurname = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add new Employee age: ");
            string newAge = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company Id: ");
            string newCompanyId = Console.ReadLine();

            int companyId;
            int id;
            int age;

            bool isIdTrue = int.TryParse(employeeId, out id);
            bool isAgeTrue = int.TryParse(newAge, out age);
            bool isCompanyIdTrue = int.TryParse(newCompanyId, out companyId);


            if (isIdTrue && isAgeTrue && isCompanyIdTrue)
            {
                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newSurname))
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Try Name and Address again");
                    goto EnterName;
                }
                else
                {
                    var newCompany = companyService.GetById(companyId);

                    if (newCompany == null)
                    {
                        Helper.WritetoConsole(ConsoleColor.Red, "Company not found, try id again");
                        goto EnterId;
                    }
                    else
                    {
                        Employee employee = new Employee
                        {
                            Name = newName,
                            Surname = newSurname,
                            Age = age,
                            Company = newCompany,

                        };
                        var newEmployee = employeeService.Update(id, employee, newCompany);

                        Helper.WritetoConsole(ConsoleColor.Green, $"{newEmployee.Id} - {newEmployee.Name} - {newEmployee.Surname} works in {newEmployee.Company.Name} updated");
                    }
                }
            }
        }
        public void GetById()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Employee Id: ");
            EnterId: string employeeId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee1 = employeeService.GetById(id);

                if (employee1 == null)
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Employee not found, try id again");
                    goto EnterId;
                }
                else
                {
                    Helper.WritetoConsole(ConsoleColor.Green, $"{employee1.Id} - {employee1.Name} - {employee1.Surname} works in {employee1.Company.Name}");
                }
            }
            else
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Employee Id: ");
            EnterId: string employeeId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(employeeId, out id);
            if (isIdTrue)
            {
                var employee = employeeService.GetById(id);
                if (employee == null)
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Employee not found, try id again");
                    goto EnterId;
                }
                else
                {
                    employeeService.Delete(employee);
                    Helper.WritetoConsole(ConsoleColor.Green, "Employee is deleted");
                }
            }
            else
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }

        }
        public void GetByAge()
        {
            
        }
        public void GetByCompanyId()
        {
            EnterCompanyId:
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company Id: ");
            string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);

            if (isTrueId)
            {
                var companysId = employeeService.GetAllByCompanyId(id);

                foreach (var item in companysId)
                {
                    Helper.WritetoConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Surname}");
                }
            }
            else
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Employee not found, try id again");
                goto EnterCompanyId;
            }
        }
        

    }
}
