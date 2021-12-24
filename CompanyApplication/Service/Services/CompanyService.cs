using Domain.Models;
using Repository.Implementaions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {
        private CompanyRepository companyRepository;
        private int count { get; set; }
        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }
        public Company Create(Company model)
        {
            model.Id = count;
            companyRepository.Create(model);
            count++;
            return model;
        }

        public void Delete(Company company)
        {
            companyRepository.Delete(company);
        }

        public Company GetById(int id)
        {
            return companyRepository.GetById(m => m.Id == id);
           
        }

        public List<Company> GetAll()
        {
            return companyRepository.GetAll(null);
        }

        public Company Update(int id, Company model)
        {
            var company = GetById(id);
            model.Id = company.Id;
            companyRepository.Update(model);
            return model;
        }

        public List<Company> GetByName(string name)
        {
            return companyRepository.GetByName(m => m.Name == name);
        }
    }
}
