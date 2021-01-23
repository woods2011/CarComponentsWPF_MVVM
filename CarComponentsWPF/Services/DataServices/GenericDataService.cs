using CarComponentsWPF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace CarComponentsWPF.Services.DataServices
{
    public class GenericDataService<T> : IDataService<T> where T : class, IEntity
    {
        public T Create(T entity)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
               var createdResult = context.Set<T>().Add(entity);
               context.SaveChanges();

               return createdResult;
            }
        }
        public T Update(T entity)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            }
        }

        public bool Delete(int id)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                T entity = context.Set<T>().Find(id);
                context.Set<T>().Remove(entity);
                context.SaveChanges();

                return true;
            }
        }

        public T Get(int id)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                T entity = context.Set<T>().Find(id);

                return entity;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                IEnumerable<T> entities = context.Set<T>().ToList();

                return entities;
            }
        }

    }
}
