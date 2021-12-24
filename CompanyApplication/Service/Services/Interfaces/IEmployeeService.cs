using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee model,int companyid);
        Employee Update(int id, Employee model);
        void Delete(Employee employee);
        Employee GetById(int id);
        List<Employee> GetAll();
        List<Employee> GetByName(string name);
    }
}
