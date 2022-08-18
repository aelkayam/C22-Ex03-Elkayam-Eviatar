using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private const eLicence k_License = eLicence.A;
        private const int k_EngineVolume = 1000;

        private readonly eLicence r_License;
        private readonly int r_EngineCapacity;

        /******** Properties ************/
        public eLicence Licence
        {
            get { return r_License; }
        }

        public int EngineCapacity
        {
            get { return r_EngineCapacity; }
        }

        /******** Constructor ************/
        private Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine, eLicence i_License, int i_EngineCapacity)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_Engine)
        {
            r_License = i_License;
            r_EngineCapacity = i_EngineCapacity;
        }

        // gas motorbike
        public Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, GasEngine i_Engine, eLicence i_License, int i_EngineCapacity)
            : this(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, (object)i_Engine, i_License, i_EngineCapacity)
        {
        }

        // electric motorbike
        public Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, ElectricEngine i_Engine, eLicence i_License, int i_EngineCapacity)
            : this(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, (object)i_Engine, i_License, i_EngineCapacity)
        {
        }

        /******** Methods ************/

        // return electric motor model supported by the garage
        public static Motorbike MakeDefaultElectricMotorbike()
        {
            // wheels:
            List<Wheel> defaultElectricMotorbikeWheels = getDefaultMotorbikeWheels();

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, GarageManager.k_MotorbikeMaxBatteryTime);

            return new Motorbike("Manufacturer", "LicesePlate", 0, defaultElectricMotorbikeWheels, defaultElectricEngine, k_License, k_EngineVolume); // default engine capacity for bikes???
        }

        // return gas motorbike model supported by the garage
        public static Motorbike MakeDefaultGasMotorbike()
        {
            // wheels:
            List<Wheel> defaultGasMotorbikeWheels = getDefaultMotorbikeWheels();

            // engine:
            ElectricEngine defaultGasEngine = new ElectricEngine(0, GarageManager.k_MotorbikeFuelTankCapacity);

            return new Motorbike("Manufacturer", "LicesePlate", 0, defaultGasMotorbikeWheels, defaultGasEngine, k_License, k_EngineVolume); // default engine capacity for bikes???
        }

        // return list of default bike wheels
        private static List<Wheel> getDefaultMotorbikeWheels()
        {
            // wheels:
            List<Wheel> defaultElectricMotorbikeWheels = new List<Wheel>(GarageManager.k_MotorbikeNumOfWheels)
            {
                new Wheel("default", 0, GarageManager.k_MotorbikeMaxAirPressure),
                new Wheel("default", 0, GarageManager.k_MotorbikeMaxAirPressure),
            };

            return defaultElectricMotorbikeWheels;
        }

        public override string ToString()
        {
            return string.Format(@"{0}License type: {1} Engine Capacity: {2}", base.ToString(), Licence, EngineCapacity);
        }

        //protected static override List<string> GetParmsForNew(bool i_isElctiric, int i_NumOfWheel)
        //{
        //    Vehicle.GetParmsForNew()
        //    throw new NotImplementedException();
        //}

        internal static List<string> GetParmsForNew(bool i_isElctiric, int i_NumOfWheel)
        {
            List<string> parms = Vehicle.GetParmsForNew(i_isElctiric, i_NumOfWheel);

            parms.Add("Licence type :  A = 1,AA = 2, B1 = 3, BB = 4,");
            parms.Add("Engine Capacity");

            return parms;
        }
    }
}