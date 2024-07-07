using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Server_Lab3
{
    [Serializable]
    [XmlInclude(typeof(VehicleCar))]
    [XmlInclude(typeof(VehicleTruck))]
    public abstract class IVehicle
    {
        protected string numberVechicle;

        public string NumberVechicle
        {
            get
            {
                return numberVechicle;
            }
            set
            {
                numberVechicle = value;
            }
        }
    }
}
