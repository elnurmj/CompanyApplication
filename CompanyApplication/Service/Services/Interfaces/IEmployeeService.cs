using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee model,int companyid);
        Employee Update(int id, Employee model,Company company);
        void Delete(Employee employee);
        Employee GetById(int id);
        List<Employee> GetAllByCompanyId(int companyid);
        List<Employee> GetByAge(int age);
    }
}
