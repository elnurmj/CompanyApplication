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
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
