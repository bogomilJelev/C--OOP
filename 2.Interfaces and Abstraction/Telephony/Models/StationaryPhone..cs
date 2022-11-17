using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Inderface;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string Phonenumber)
        {
          if (!Phonenumber.All(x => char.IsDigit(x)))
          {
              throw new ArgumentException("Invalid number!");
          }
          return $"Dialing... {Phonenumber}";
        }
    }

}
