using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> races;
        public void Add(IDriver model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => races.ToArray();


        public IDriver GetByName(string name) => races.FirstOrDefault(x => x.Name == name);


        public bool Remove(IDriver model)
        {
            if (races.Contains(model))
            {
                races.Remove(model);
                return true;
            }
            return false;
        }
    }
}
