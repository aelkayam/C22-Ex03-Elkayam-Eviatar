using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
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
        public Car(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, eCarState i_CarState, object i_Engine, eColor i_Color, eDoors i_Doors)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_CarState, i_Engine)
        {
            m_Color = i_Color;
            r_Doors = i_Doors;
        }

        /******** Methods ************/

        // return electric car model supported by the garage
        public static Car MakeDefaultElectricCar()
        {
            // wheels:
            List<Wheel> defaultElectricCarWheels = getDefaultCarWheels();

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, GarageManager.k_CarMaxBatteryTime);

            return new Car("Manufacturer", "LicesePlate", 0, defaultElectricCarWheels, eCarState.InRepair, defaultElectricEngine, eColor.Black, eDoors.FourDoors);
        }

        // return gas car model supported by the garage
        public static Car MakeDefaultGasCar()
        {
            // wheels:
            List<Wheel> defaultGasCarWheels = getDefaultCarWheels();

            // engine
            GasEngine defaultGasEngine = new GasEngine(GarageManager.k_CarGasType, 0, GarageManager.k_CarFuelTankCapacity);

            return new Car("Manufacturer", "LicesePlate", 0, defaultGasCarWheels, eCarState.InRepair, defaultGasEngine, eColor.Black, eDoors.FourDoors);
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
            return string.Format(@"{0}Color:{1} Doors: {2}", base.ToString(), Color, Doors);
        }
    }
}
