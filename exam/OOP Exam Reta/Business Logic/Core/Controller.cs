using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aqua = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aqua = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aqua = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            aquariums.Add(aqua);
            return $"Successfully added { aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration dec = null;
            if (decorationType == "Ornament")
            {
                dec = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                dec = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            decorations.Add(dec);
            return $"Successfully added { decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aqua = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            IFish fish;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (aqua.GetType().Name == "SaltwaterAquarium")
                {
                    return "Water not suitable.";
                }
                aqua.AddFish(fish);


            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (aqua.GetType().Name == "FreshwaterAquarium")
                {
                    return "Water not suitable.";
                }
                aqua.AddFish(fish);

            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            return $"Successfully added {fishType} to {aquariumName}.";

        }

        public string CalculateValue(string aquariumName)
        {
            var aqua = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sum = 0;
            foreach (var item in aqua.Fish)
            {
                sum += item.Price;
            }
            foreach (var item in aqua.Decorations)
            {
                sum += item.Price;
            }
            return $"The value of Aquarium { aquariumName} is {sum:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aqua = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aqua.Feed();
            return $"Fish fed:{aqua.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aqua = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            IDecoration decor = null;
            if (decorationType == "Plant")
            {
                decor = decorations.FindByType(decorationType);
                if (decor != null)
                {
                  
                    aqua.AddDecoration(decor);
                    decorations.Remove(decor);
                }
            }
            if (decorationType == "Ornament")
            {
                decor = decorations.FindByType(decorationType);
                if (decor != null)
                {
                    aqua.AddDecoration(new Ornament());
                    decorations.Remove(decor);
                }
            }
            if(decor==null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
