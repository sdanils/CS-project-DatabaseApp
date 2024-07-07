using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Three_WinAdd
{
    public class Truck : Model
    {
        public Truck() : base() 
        {
        }
        public Truck(string brand, string model, int power, int speed) : base(brand, model, power, speed)
        {
        }
    }
}
