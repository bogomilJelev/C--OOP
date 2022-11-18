using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> driver;
        public DriverRepository()
        {
            driver = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
            driver.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => driver.ToArray();


        public IDriver GetByName(string name) =>this.driver.FirstOrDefault(x => x.Name == name);


        public bool Remove(IDriver model)
        {
            if (driver.Contains(model))
            {
                driver.Remove(model);
                return true;
            }
            return false;
        }
    }
}
