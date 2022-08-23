using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        // default values:
        private const float k_EnergyLeft = 20f;
        private const eColor k_Color = eColor.Blue;
        private const eDoors k_Doors = eDoors.FourDoors;

        private readonly eDoors r_Doors;
        private eColor m_Color;

        /******** Properties ************/
        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eDoors Doors
        {
            get { return r_Doors; }
        }

        /******** Constructor ************/
        private Car(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine, eColor i_Color, eDoors i_Doors)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_Engine)
        {
            m_Color = i_Color;
            r_Doors = i_Doors;
        }

        // gas car
        public Car(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, GasEngine i_Engine, eColor i_Color, eDoors i_Doors)
            : this(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, (object)i_Engine, i_Color, i_Doors)
        {
        }

        // electric car
        public Car(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, ElectricEngine i_Engine, eColor i_Color, eDoors i_Doors)
            : this(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, (object)i_Engine, i_Color, i_Doors)
        {
        }

        /******** Methods ************/

        // return electric car model supported by the garage
        public static Car MakeDefaultElectricCar()
        {
            // wheels: GetDefaultListWheels(
            List<Wheel> defaultElectricCarWheels = Wheel.GetDefaultListWheels(4, "default", 0, GarageManager.k_CarMaxAirPressure);

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, GarageManager.k_CarMaxBatteryTime);

            return new Car("Manufacturer", "LicesePlate", k_EnergyLeft, defaultElectricCarWheels, defaultElectricEngine, k_Color, k_Doors);
        }

        // return gas car model supported by the garage
        public static Car MakeDefaultGasCar()
        {
            // wheels:
            List<Wheel> defaultGasCarWheels = Wheel.GetDefaultListWheels(4, "default", 0, GarageManager.k_CarMaxAirPressure);

            // engine
            GasEngine defaultGasEngine = new GasEngine(GarageManager.k_CarGasType, 0, GarageManager.k_CarFuelTankCapacity);

            return new Car("Manufacturer", "LicesePlate", k_EnergyLeft, defaultGasCarWheels, defaultGasEngine, k_Color, k_Doors);
        }

        // return list of default car wheels
        private static List<Wheel> getDefaultCarWheels()
        {
            // wheels:
            List<Wheel> defaultElectricCarWheels = new List<Wheel>(GarageManager.k_CarNumOfWheels)
            {
                new Wheel("default", 0, GarageManager.k_CarMaxAirPressure),
                new Wheel("default", 0, GarageManager.k_CarMaxAirPressure),
                new Wheel("default", 0, GarageManager.k_CarMaxAirPressure),
                new Wheel("default", 0, GarageManager.k_CarMaxAirPressure),
            };

            return defaultElectricCarWheels;
        }

        public override string ToString()
        {
            return string.Format(@"{0}Color:{1}     Doors: {2}", base.ToString(), Color, Doors);
        }


        internal static List<string> GetParmsForNew()
        {
            List<string> parms = new List<string>
            {
                "color:  Black - 1,  Blue - 2,  Gray - 3,  White - 4 ",
                "number of doors: Two-Doors - 2,  Three-Doors - 3, Four-Doors = 4, Five-Doors - 5,",
            };

            return parms;
        }

        public override bool IsPropertiesEqual(Vehicle i_Other)
        {
            Console.WriteLine("in IsPropertiesEqual of truck ");

            bool ans = false;
            bool isEqualCar = isEquaCar(i_Other);

            if (isEqualCar)
            {


                ans = ((Vehicle)this).IsPropertiesEqual(i_Other);
            }

            return ans;
        }

        private bool isEquaCar(Vehicle i_Other)
        {
            bool ans = false;
            Car other = i_Other as Car;

            if ((Object) other != null)
            {
                ans = this.Doors == other.Doors && Color == other.Color;
            }

            return ans;
        }
    }
}
