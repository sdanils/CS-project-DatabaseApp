using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Three_WinAdd
{
    [Serializable]
    public class VehicleCar : IVehicle
    {
        private string nameMultimedia;
        private int numberAirbags;

        public string NameMultimedia
        {
            get
            {
                return nameMultimedia;
            }
            set
            {
                nameMultimedia = value;
            }
        }

        public int NumberAirbags
        {
            get
            {
                return numberAirbags;
            }
            set
            {
                numberAirbags = value;
            }
        }

        public VehicleCar(string name, string multi, int airbags)
        {
            this.NumberVechicle = name;
            this.NameMultimedia = multi;
            this.NumberAirbags = airbags;
        }

        public VehicleCar()
        {
            this.NumberVechicle = null;
            this.NameMultimedia = null;
            this.NumberAirbags = 0;
        }

    }

}
