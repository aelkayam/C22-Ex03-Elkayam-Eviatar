using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eDoors r_Doors;
        private eColor m_Color;

        private const string k_modle = "Car-Modle";
        private const float k_EnergyLeft = 20f;
        private const eColor k_Color = eColor.Blue;
        private const eDoors k_Doors = eDoors.FourDoors;


        private readonly bool r_IsRefrigerator;
        private readonly float r_MaxCapacity;

        private readonly static Truck sr_Model;
        
        static Car()
        {
            List<Wheel> modelWheels = new List<Wheel>();
            for(int i = 0; i<GarageManager.k_CarNumOfWhell; i++)
            {
                modelWheels.Add(new Wheel());
            }
            sr_Model = new Car(k_modle, k_modle, GarageManager.k_CarFuelTankContents, modelWheels, new GasEngine,  k_Color, k_Doors);
        }

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
        public Car(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine, eColor i_Color, eDoors i_Doors)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_Engine)
        {
            m_Color = i_Color;
            r_Doors = i_Doors;
        }

        //public Car()
        //{
        //}

        //public Car(GasEngine gasEngine)
        //{
        //}

        //public Car(ElectricEngine electricEngine)
        //{
        //    ElectricEngine = electricEngine;
        //}

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
