﻿using Domain.Models;
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

        public void Delete(Company model)
        {
            throw new NotImplementedException();
        }

        public Company Get(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public Company Update(int id, Company model)
        {
            throw new NotImplementedException();
        }
    }
}
