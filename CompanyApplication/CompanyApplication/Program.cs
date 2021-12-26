using CompanyApplication.Controller;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyController companyController = new CompanyController();

            EmployeeController employeeController = new EmployeeController();

            Helper.WritetoConsole(ConsoleColor.Blue, "Select option");

            while (true)
            {
                GetMenus();

                EnterOption: string selectOption = Console.ReadLine();

                int option;

                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        case (int) MyEnums.Menus.CreateCompany:
                            companyController.Create();

                            break;
                        case (int)MyEnums.Menus.UpdateCompany:
                            companyController.Update();

                            break;
                        case (int)MyEnums.Menus.DeleteCompany:
                            companyController.Delete();

                            break;
                        case (int)MyEnums.Menus.GetCompanyByID:
                            companyController.GetById();

                            break;
                        case (int)MyEnums.Menus.GetAllCompanyByname:
                            companyController.GetByName();

                            break;
                        case (int)MyEnums.Menus.GetAllCompany:
                            companyController.GetAll();

                            break;
                        case (int)MyEnums.Menus.CreateEmployee:
                            employeeController.Create();

                            break;
                        case (int)MyEnums.Menus.UpdateEmployee:
                            employeeController.Update();

                            break;
                        case (int)MyEnums.Menus.GetEmployeeByID:
                            employeeController.GetById();

                            break;
                        case (int)MyEnums.Menus.DeleteEmployee:
                            employeeController.Delete();

                            break;
                        case (int)MyEnums.Menus.GetEmployeeByAge:
                            employeeController.GetByAge();

                            break;
                        case (int)MyEnums.Menus.GetAllEmployeeByCompanyID:
                            employeeController.GetByCompanyId();

                            break;

                    }

                }
                else
                {
                    goto EnterOption;
                }



            }
            
        }

        private static void GetMenus()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "1 - Create Company, 2 - Update Company, 3 - Delete Company,\n" +
                                                     "4 - Get Company by ID, 5 - Get all Company by name\n" +
                                                     "6 - Get all Company, 7 - Create Employee\n" +
                                                     "8 - Update Employee, 9 - Get Employee by ID, 10 - Delete Employee\n" +
                                                     "11 - Get Employee by age, 12 - Get all Employee by Company ID");
        }
    }
}
