using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const bool k_IsRefrigerated = false;
        private const float k_MaxCapacity = 2000;

        private readonly bool r_IsRefrigerator;
        private readonly float r_MaxCapacity;

        /******** Properties ************/
        public bool IsRefrigerator
        {
            get { return r_IsRefrigerator; }
        }

        public float MaxCapacity
        {
            get { return r_MaxCapacity; }
        }

        /******** Constructor ************/
        public Truck(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine, bool i_isRefrigerator, float i_MaxCapacity)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_Engine)
        {
            r_IsRefrigerator = i_isRefrigerator;
            r_MaxCapacity = i_MaxCapacity;
        }

        /******** Methods ************/

        // return truck model supported by the garage
        public static Truck MakeDefaultTruck()
        {
            // wheels:
            List<Wheel> defaultTruckWheels = Wheel.GetDefaultListWheels(GarageManager.k_TruckNumOfWheels, "default", 0, GarageManager.k_TruckMaxAirPressure);

            // engine:
            GasEngine defaultTruckEngine = new GasEngine(GarageManager.k_TruckGasType, 0, GarageManager.k_TruckFuelTankCapacity);

            Truck defaultTruck = new Truck("Manufacturer", "LicesePlate", 0, defaultTruckWheels, defaultTruckEngine, k_IsRefrigerated, k_MaxCapacity);

            return defaultTruck;
        }

        // return list of default truck wheels
        private static List<Wheel> getDefaultTruckWheels()
        {
            List<Wheel> defaultTruckWheels = new List<Wheel>(GarageManager.k_TruckNumOfWheels);
            for (int i = 0; i < GarageManager.k_TruckNumOfWheels; i++)
            {
                defaultTruckWheels.Add(new Wheel("default", 0, GarageManager.k_TruckMaxAirPressure));
            }

            return defaultTruckWheels;
        }

        public override string ToString()
        {
            return string.Format(@"{0}Has refrigerator: {1}     Capacity: {2}L", base.ToString(), IsRefrigerator, MaxCapacity);
        }

        internal static List<string> GetParmsForNew()
        {
            List<string> parms = new List<string>
            {
                "Is Refrigerated",
                "Max Capacity",
            };

            return parms;
        }

        public override bool IsPropertiesEqual(Vehicle i_Other)
        {
            Console.WriteLine("in IsPropertiesEqual of truck ");
            bool ans = false;
            bool isEqualMoto = isEquaTruck(i_Other);

            if (isEqualMoto)
            {


                ans = ((Vehicle)this).IsPropertiesEqual(i_Other);
            }

            return ans;
        }

        private bool isEquaTruck(Vehicle i_Other)
        {
            bool ans = false;
            Truck other = i_Other as Truck;

            if (other != null)
            {
                ans = this.IsRefrigerator == other.IsRefrigerator && MaxCapacity == other.MaxCapacity;
            }

            return ans;
        }
    }
}
