using System;
using System.Collections.Generic;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public interface IDataService<T>
    {
        T Get(int id);

        T Create(T entity);

        T Update(T entity);

        bool Delete(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetWithFilter(Dictionary<string, string> filterDictionary);
    }
}
