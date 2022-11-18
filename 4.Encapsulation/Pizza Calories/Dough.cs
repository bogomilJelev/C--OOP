using System;
using System.Collections.Generic;
using System.Text;

namespace ask
{
    public class Dough
    {
        private string foluttype;
        private string bakingtechnique;
        private double weight;
        public string FolurTypr
        {
            get
            {
                return foluttype;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                foluttype = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingtechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingtechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if(value<0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }
                weight = value;
            }
        }





        public Dough(string f, string b, double w)
        {
            FolurTypr = f;
            BakingTechnique = b;
            Weight = w;
        }
        public double Calculate()
        {
            double askk=(2 * weight) * Flour() * BTechnique();
            return askk;
        }
        private double Flour()
        {
            if (foluttype.ToLower() == "white")
            {
                return 1.5;
            }
            else
            {
                return 1.0;
            }
        }
        private double BTechnique()
        {
            if (bakingtechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (bakingtechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            else
            {
                return 1.0;
            }
        }
    }
}
