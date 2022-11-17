using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Inderface;

namespace Telephony.Models
{
    public class SmartPhone : IBrawsable, ICallable
    {
        public string Brows(string site)
        {
            if (site.Any(x =>char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {site}!";
        }

        public string Call(string Phonenumber)
        {
            if (!Phonenumber.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {Phonenumber}";
        }
    }
}
