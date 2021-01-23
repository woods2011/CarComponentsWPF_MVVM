using System;
using System.Collections.Generic;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public interface IDataService<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Create(T entity);

        T Update(T entity);

        bool Delete(int id);
    }
}
