using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Lab3
{
    [Serializable]
    public class VehicleTruck : IVehicle
    {
        private int numberWheels;
        private int voluemBody;

        public int NumberWheels
        {
            get
            {
                return numberWheels;
            }
            set
            {
                numberWheels = value;
            }
        }

        public int VoluemBody
        {
            get
            {
                return voluemBody;
            }
            set
            {
                voluemBody = value;
            }
        }

        public VehicleTruck(string name, int numWh, int vol)
        {
            this.NumberVechicle = name;
            this.NumberWheels = numWh;
            this.VoluemBody = vol;
        }

        public VehicleTruck()
        {
            this.NumberVechicle = null;
            this.NumberWheels = 0;
            this.VoluemBody = 0;
        }
    }
}
