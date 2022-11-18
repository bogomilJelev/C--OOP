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

        public void Add(IDecoration decoration)
        {
            list.Add(decoration);
            
        }

        public IDecoration FindByType(string type)
        {
            var deco = list.FirstOrDefault(x => x.GetType().Name == type);
            if (deco == null)
            {
                return null;
            }
            return deco;
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
