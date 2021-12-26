using Domain.Models;
using Repository.Exceptions;
using Repository.Implementaions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository employeeRepository { get; }
        private int count { get; set; }
        private CompanyRepository companyRepository { get; }

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
            companyRepository = new CompanyRepository();
        }
        public Employee Create(Employee model,int companyid)
        {
            try
            {
                var company = companyRepository.GetById(m => m.Id == companyid);
                if (company == null) throw new CustomException("Company not found");

                model.Id = count;
                model.Company = company;
                employeeRepository.Create(model);
                count++;
                return model;
                

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public void Delete(Employee employee)
        {
            employeeRepository.Delete(employee);
        }

        public List<Employee> GetAllByCompanyId(int companyid)
        {
            return employeeRepository.GetAllByCompanyId(m => m.Company.Id == companyid);
        }

        public Employee GetById(int id)
        {
            return employeeRepository.GetById(m => m.Id == id);
        }

        public List<Employee> GetByAge(int age)
        {
            return employeeRepository.GetByAge(m => m.Age == age);
        }

        public Employee Update(int id, Employee model,Company company)
        {
            var employee = GetById(id);
            model.Company = company;
            model.Id = employee.Id;
            employeeRepository.Update(model, company);
            return model;
        }
    }
}
