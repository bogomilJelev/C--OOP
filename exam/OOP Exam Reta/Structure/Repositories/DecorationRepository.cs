using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> list;
        public DecorationRepository()
        {
            list = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => list;

        public void Add(IDecoration model)
        {
            list.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decoration = list.FirstOrDefault(i => i.GetType().Name == type);
            if (decoration == null)
            {
                return null;
            }
            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            if (list.Contains(model))
            {
                list.Remove(model);
                return true;
            }
            return false;
        }
    }
}
