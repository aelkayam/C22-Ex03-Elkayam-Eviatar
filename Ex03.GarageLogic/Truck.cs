using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const byte k_TruckNumOfWheels = 16;
        private const byte k_TruckMaxAirPressure = 25;
        private const float k_TruckFuelTankCapacity = 135f;
        private const float k_MaxCapacity = 2000;
        private const bool k_IsRefrigerated = false;
        private const eGasType k_TruckGasType = eGasType.Soler;

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
        private Truck(string i_Name, string i_LicensePlate, WheelArr i_Wheels, object i_Engine, bool i_isRefrigerator, float i_MaxCapacity)
            : base(i_Name, i_LicensePlate, i_Wheels, i_Engine)
        {
            r_IsRefrigerator = i_isRefrigerator;
            r_MaxCapacity = i_MaxCapacity;
        }

        public Truck(string i_Name, string i_LicensePlate, WheelArr i_Wheels, ElectricEngine i_Engine, bool i_isRefrigerator, float i_MaxCapacity)
            : this(i_Name, i_LicensePlate, i_Wheels, (object)i_Engine, i_isRefrigerator, i_MaxCapacity)
        {
        }

        public Truck(string i_Name, string i_LicensePlate, WheelArr i_Wheels, GasEngine i_Engine, bool i_isRefrigerator, float i_MaxCapacity)
            : this(i_Name, i_LicensePlate, i_Wheels, (object)i_Engine, i_isRefrigerator, i_MaxCapacity)
        {
        }

        /******** Methods ************/

        // return truck model supported by the garage
        public static Truck MakeDefaultTruck()
        {
            // wheels:
            WheelArr defaultTruckWheels = new WheelArr(k_TruckNumOfWheels, "default", 0, k_TruckMaxAirPressure);

            // engine:
            GasEngine defaultTruckEngine = new GasEngine(k_TruckGasType, 0, k_TruckFuelTankCapacity);

            Truck defaultTruck = new Truck("Manufacturer", "LicensePlate", defaultTruckWheels, defaultTruckEngine, k_IsRefrigerated, k_MaxCapacity);

            return defaultTruck;
        }

        public override bool IsPropertiesEqual(Vehicle i_Other)
        {
            bool ans = false;

            bool isEqualType = i_Other is Truck;

            if (isEqualType)
            {
                ans = ((Vehicle)this).IsPropertiesEqual(i_Other);
            }

            return ans;
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
    }
}
