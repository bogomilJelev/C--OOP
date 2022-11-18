using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;
        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll() => races.ToArray();


        public IRace GetByName(string name) => races.FirstOrDefault(x => x.Name == name);


        public bool Remove(IRace model)
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
