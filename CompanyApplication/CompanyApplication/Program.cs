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
            CompanyService companyService = new CompanyService();

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
                            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company name");
                            string companyName = Console.ReadLine();
                            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company room count");
                            EnterCount:  string roomCount = Console.ReadLine();
                            int count;
                            bool isTrueCount = int.TryParse(roomCount, out count);

                            if (isTrueCount)
                            {
                                Company company = new Company()
                                {
                                    Name = companyName,
                                    RoomCount = count
                                };
                                var result = companyService.Create(company);

                                if (result != null)
                                {
                                    Helper.WritetoConsole(ConsoleColor.Green, $"{company.Name} Company created");
                                }
                                else
                                {
                                    Helper.WritetoConsole(ConsoleColor.Red, "Something is wrong");
                                    goto EnterCount;
                                }
                            }
                            else
                            {
                                Helper.WritetoConsole(ConsoleColor.Red, "Try again");
                                goto EnterCount;
                            }
                            break;
                        case (int)MyEnums.Menus.UpdateCompany:
                            break;
                        case (int)MyEnums.Menus.DeleteCompany:
                            break;
                        case (int)MyEnums.Menus.GetCompanyByID:
                            break;
                        case (int)MyEnums.Menus.GetAllCompanyByname:
                            break;
                        case (int)MyEnums.Menus.GetAllCompany:
                            break;
                        case (int)MyEnums.Menus.CreateEmployee:
                            break;
                        case (int)MyEnums.Menus.UpdateEmployee:
                            break;
                        case (int)MyEnums.Menus.GetEmployeeByID:
                            break;
                        case (int)MyEnums.Menus.DeleteEmployee:
                            break;
                        case (int)MyEnums.Menus.GetEmployeeByAge:
                            break;
                        case (int)MyEnums.Menus.GetAllEmployeeByCompanyID:
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
            Helper.WritetoConsole(ConsoleColor.Cyan, "1 - Create Company, 2 - Update Company, 3 - Delete Company, 4 - Get Company by ID, 5 - Get all Company by name, 6 - Get all Company, 7 - Create Employee" +
                "8 - Update Employee, 9 - Get Employee by ID, 10 - Delete Employee, 11 - Get Employee by age, 12 - Get all Employee by Company ID");
        }
    }
}
