using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Capacity { get; }

        public int Comfort => decolist.Sum(x => x.Comfort);

        private List<IDecoration> decolist;
        public ICollection<IDecoration> Decorations => decolist;

        private List<IFish> fishlist;
        public ICollection<IFish> Fish => fishlist;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decolist = new List<IDecoration>();
            fishlist = new List<IFish>();
        }
        public void AddDecoration(IDecoration decoration)
        {
            decolist.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishlist.Count + 1 <= Capacity)
            {
                fishlist.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public void Feed()
        {
            foreach (var item in fishlist)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({GetType().Name}): ");
            sb.AppendLine(string.Join(", ", this.fishlist));
            sb.AppendLine($"Decorations: {decolist.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            if (fishlist.Contains(fish))
            {
                fishlist.Remove(fish);
                return true;
            }
            return false;
        }
    }
}
