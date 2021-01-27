using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class ComponentDataService : GenericDataService<Component>
    {
        public override IEnumerable<Component> GetAll()
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                IEnumerable<Component> entities = context.Components.Include(c => c.Manufacter).Include(c => c.ComponentType).Include(c => c.CarModel).ToList();

                return entities;
            }
        }

        public override Component Get(int id)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                Component entity = context.Components.Include(c => c.Manufacter).Include(c => c.ComponentType).Include(c => c.CarModel).FirstOrDefault(c => c.id == id);

                return entity;
            }
        }

        public override Component Create(Component entity)
        {
            Component resEntity = base.Create(entity);
            if (resEntity == null)
                return resEntity;
            return Get(resEntity.id);
        }

        public override Component Update(Component entity)
        {
            Component resEntity = base.Update(entity);
            if (resEntity == null)
                return resEntity;
            return Get(resEntity.id);
        }


        public override IEnumerable<Component> GetWithFilter(Dictionary<string, int> filterDictionary)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                //IQueryable<Component> query = context.Components.Where(x => true);
                IQueryable<Component> query = context.Components.AsQueryable();


                if (filterDictionary.TryGetValue(nameof(Manufacter), out int M_id))
                    query = query.Where(c => c.id_Manuf == M_id);

                if (filterDictionary.TryGetValue(nameof(ComponentType), out int CT_id))
                    query = query.Where(c => c.id_CompType == CT_id);

                if (filterDictionary.TryGetValue(nameof(CarModel), out int CM_id))
                    query = query.Where(c => c.id_CarModel == CM_id);


                IEnumerable<Component> entities = query.Include(c => c.Manufacter).Include(c => c.ComponentType).Include(c => c.CarModel).ToList();

                return entities;
            }
        }
    }
}
