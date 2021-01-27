using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using CarComponentsWPF.Models;

namespace CarComponentsWPF.Services.DataServices
{
    public class ProviderComponentDataService : GenericDataService<ProviderComponent>
    {
        public override IEnumerable<ProviderComponent> GetAll()
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                IEnumerable<ProviderComponent> entities = context.ProviderComponents
                    .Include(pc => pc.Component.Manufacter).Include(pc => pc.Component.ComponentType).Include(pc => pc.Component.CarModel)
                    .Include(pc => pc.Provider).ToList();

                return entities;
            }
        }

        public override ProviderComponent Get(int id)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                ProviderComponent entity = context.ProviderComponents
                    .Include(pc => pc.Component.Manufacter).Include(pc => pc.Component.ComponentType).Include(pc => pc.Component.CarModel)
                    .Include(pc => pc.Provider).FirstOrDefault(pc => pc.id == id);

                return entity;
            }
        }

        public override ProviderComponent Create(ProviderComponent entity)
        {
            ProviderComponent resEntity = base.Create(entity);
            if (resEntity == null)
                return resEntity;
            return Get(resEntity.id);
        }

        public override ProviderComponent Update(ProviderComponent entity)
        {
            ProviderComponent resEntity = base.Update(entity);
            if (resEntity == null)
                return resEntity;
            return Get(resEntity.id);
        }


        public override IEnumerable<ProviderComponent> GetWithFilter(Dictionary<string, int> filterDictionary)
        {
            using (CarCompDB8Entities context = new CarCompDB8Entities())
            {
                IQueryable<ProviderComponent> query = context.ProviderComponents.AsQueryable();


                if (filterDictionary.TryGetValue(nameof(Component), out int C_id))
                    query = query.Where(pc => pc.id_CarComp == C_id);

                if (filterDictionary.TryGetValue(nameof(Provider), out int P_id))
                    query = query.Where(c => c.id_Provider == P_id);


                IEnumerable<ProviderComponent> entities = query
                    .Include(pc => pc.Component.Manufacter).Include(pc => pc.Component.ComponentType).Include(pc => pc.Component.CarModel)
                    .Include(pc => pc.Provider).ToList();

                return entities;
            }
        }
    }
}
