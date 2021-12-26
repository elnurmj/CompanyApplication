using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class CompanyController
    {
        private CompanyService companyService { get; }

        public CompanyController()
        {
            companyService = new CompanyService();
        }
        public void Create()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company name");
            string companyName = Console.ReadLine();
        EnterAddress: Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company address");
            string address = Console.ReadLine();


            {
                if (companyName == null || companyName == "" || address == null || address == "")
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Try again");
                    
                }
                else
                {
                    Company company = new Company()
                    {
                        Name = companyName,
                        Address = address
                    };
                    var result = companyService.Create(company);

                    if (result != null)
                    {
                        Helper.WritetoConsole(ConsoleColor.Green, $"{company.Id} - {company.Name} - {company.Address} - Company created");
                    }
                    else
                    {
                        Helper.WritetoConsole(ConsoleColor.Red, "Something is wrong");
                        goto EnterAddress;
                    }

                }
                
            }
        }
        public void Update()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company ID");
            EnterId: string companyid = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add new Company name");
            EnterName:  string newName = Console.ReadLine();
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add new address");
            string newAddress = Console.ReadLine();

            int id;

            bool isIdTrue = int.TryParse(companyid, out id);



            if (isIdTrue)
            {

                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newAddress))
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Try Name and Address again");
                    goto EnterName;
                }
                else
                {
                    Company company = new Company
                    {
                        Name = newName,
                        Address = newAddress,
                    };
                    var newCompany = companyService.Update(id, company);
                    Helper.WritetoConsole(ConsoleColor.Green, $"{newCompany.Id} - {newCompany.Name} - {newCompany.Address}");
                }

            }
            else
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Try again id");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company ID");
            EnterId: string companyid = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyid, out id);

            if (isIdTrue)
            {
                var company = companyService.GetById(id);
                if (company == null)
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Company not found");
                    goto EnterId;
                }
                else
                {
                    companyService.Delete(company);
                    Helper.WritetoConsole(ConsoleColor.Green, "Company is deleted");                 
                }
            }
            else
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Try again id");
                goto EnterId;
            }

        }
        public void GetById()
        {
        Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company ID");
        EnterId: string companyId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var company = companyService.GetById(id);
                if (company == null)
                {
                    Helper.WritetoConsole(ConsoleColor.Red, "Company not found");
                    goto EnterId;
                }
                else
                {
                    Helper.WritetoConsole(ConsoleColor.Green, $"{company.Id} - {company.Name} - {company.Address}");
                    
                }
            }
            else
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Try again id");
                goto EnterId;
            }
        }
        public void GetByName()
        {
            Helper.WritetoConsole(ConsoleColor.Cyan, "Add Company name: ");
        EnterCompanyName:
            string companyName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(companyName))
            {
                Helper.WritetoConsole(ConsoleColor.Red, "Try Company name again");
                goto EnterCompanyName;
            }
            else
            {
                var companyNames = companyService.GetByName(companyName);
                foreach (var item in companyNames)
                {
                    if (item.Name != companyName)
                    {
                        Helper.WritetoConsole(ConsoleColor.Red, "Company not found, please try again");
                        goto EnterCompanyName;
                    }
                    else
                    {
                        Helper.WritetoConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Address}");

                    }
                }
            }
        }
        public void GetAll()
        {
            var companies = companyService.GetAll();

            foreach (var item in companies)
            {
                Helper.WritetoConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Address}");
            }
        }
        

        
    }
}
