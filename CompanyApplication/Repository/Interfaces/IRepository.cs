using Domain.Common;
using System;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Create(T entity);
        bool Delete(T entity);
        T GetById(Predicate<T> filter);

        
        

        

    }
}
