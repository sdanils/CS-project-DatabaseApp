using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_Three_WinAdd
{
    [Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(VehicleCar))]
    [XmlInclude(typeof(VehicleTruck))]
    public abstract class Model : IBrand
    {
        public List<IVehicle> vehicles;
        private string brand;
        private string model;
        private int powerEngine;
        private int maxSpeed;
        
        public Model()
        {
            vehicles = null;
            Brand = "brand";
            NameModel = "model";
            PowerEngine = 0;
            MaxSpeed = 0;
        }

        public Model(string brand, string model, int power, int speed)
        {
            vehicles = null;
            Brand = brand;
            NameModel = model;
            PowerEngine = power;
            MaxSpeed = speed;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                this.brand = value;
            }
        }

        public string NameModel
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public int PowerEngine
        {
            get
            {
                return this.powerEngine;
            }
            set
            {
                this.powerEngine = value;
            }
        }
        public int MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }
            set
            {
                this.maxSpeed = value;
            }
        }

    }
}

