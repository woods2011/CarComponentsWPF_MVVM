using CarComponentsWPF.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace CarComponentsWPF.Services.DataServices
{
    public abstract class GenericDataService<T> : IDataService<T> where T : class, IEntity
    {
        public T Create(T entity)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                string exceptionMessage = String.Empty;

                T createdResult = context.Set<T>().Add(entity);
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

        public abstract IEnumerable<T> GetWithFilter(Dictionary<string, string> filterDictionary);
    }
}




//try
//{
       //context.SaveChanges();
//}
//catch (DbUpdateException ex)
//{
//    throw new Exception(ex.Message + "\nВнутренне исключение: "+ ex.InnerException.InnerException.Message);
//}
//catch (DbUpdateConcurrencyException ex)
//{
//    exceptionMessage += ex.Message;
//    Console.WriteLine(exceptionMessage.Length);
//}
//catch (DbUpdateException ex)
//{
//    exceptionMessage += ex.Message;
//    Console.WriteLine(exceptionMessage.Length);
//}
//catch (DbEntityValidationException ex)
//{
//    exceptionMessage += ex.Message;
//    Console.WriteLine(exceptionMessage.Length);
//}
//finally
//{
//    if (!String.IsNullOrEmpty(exceptionMessage))
//        throw new Exception(exceptionMessage);
//}