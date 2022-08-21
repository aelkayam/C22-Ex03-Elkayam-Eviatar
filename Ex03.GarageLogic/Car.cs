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

        public ElectricEngine ElectricEngine { get; }

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
            // wheels:
            List<Wheel> defaultElectricCarWheels = getDefaultCarWheels();

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, GarageManager.k_CarMaxBatteryTime);

            return new Car("Manufacturer", "LicesePlate", k_EnergyLeft, defaultElectricCarWheels, defaultElectricEngine, k_Color, k_Doors);
        }

        // return gas car model supported by the garage
        public static Car MakeDefaultGasCar()
        {
            // wheels:
            List<Wheel> defaultGasCarWheels = getDefaultCarWheels();

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
            List<string> parms = new List<string>();
            parms.Add("color");
            parms.Add("number of doors ");

            return parms;
        }
    }
}
