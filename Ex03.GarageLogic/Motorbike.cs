using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private const eLicense k_License = eLicense.A;
        private const int k_EngineVolume = 1000;

        private readonly eLicense r_License;
        private readonly int r_EngineCapacity;

        /******** Properties ************/
        public eLicense Licence
        {
            get { return r_License; }
        }

        public int EngineCapacity
        {
            get { return r_EngineCapacity; }
        }

        /******** Constructor ************/
        private Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine, eLicense i_License, int i_EngineCapacity)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_Engine)
        {
            r_License = i_License;
            r_EngineCapacity = i_EngineCapacity;
        }

        // gas motorbike
        public Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, GasEngine i_Engine, eLicense i_License, int i_EngineCapacity)
            : this(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, (object)i_Engine, i_License, i_EngineCapacity)
        {
        }

        public Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, ElectricEngine i_Engine, eLicense i_License, int i_EngineCapacity)
            : this(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, (object)i_Engine, i_License, i_EngineCapacity)
        {
        }

        /******** Methods ************/

        // return electric motor model supported by the garage
        public static Motorbike MakeDefaultElectricMotorbike()
        {
            // wheels:
            List<Wheel> defaultElectricMotorbikeWheels = Wheel.GetDefaultListWheels(2, "default", 0, GarageManager.k_MotorbikeMaxAirPressure);

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, GarageManager.k_MotorbikeMaxBatteryTime);

            return new Motorbike("Manufacturer", "LicesePlate", 0, defaultElectricMotorbikeWheels, defaultElectricEngine, k_License, k_EngineVolume); // default engine capacity for bikes???
        }

        // return gas motorbike model supported by the garage
        public static Motorbike MakeDefaultGasMotorbike()
        {
            // wheels:
            List<Wheel> defaultGasMotorbikeWheels = Wheel.GetDefaultListWheels(2, "default", 0, GarageManager.k_MotorbikeMaxAirPressure);

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
            return string.Format(@"{0}License type: {1}     Engine Capacity: {2}", base.ToString(), Licence, EngineCapacity);
        }

        //protected static override List<string> GetParmsForNew(bool i_isElctiric, int i_NumOfWheel)
        //{
        //    Vehicle.GetParmsForNew()
        //    throw new NotImplementedException();
        //}

        internal static List<string> GetParmsForNew()
        {
            List<string> parms = new List<string>
            {
                "License type :  A = 1,AA = 2, B1 = 3, BB = 4,",
                "Engine Capacity",
            };

            return parms;
        }


        public override bool IsPropertiesEqual(Vehicle i_Other)
        {
            Console.WriteLine("in IsPropertiesEqual of Moto ");

            bool ans = false;
            bool isEqualMoto = isEqualMotorbike(i_Other);

            if (isEqualMoto)
            {
                ans = ((Vehicle)this).IsPropertiesEqual(i_Other);
            }

            return ans;
        }

        private bool isEqualMotorbike(Vehicle i_Other)
        {
            bool ans = false;
            Motorbike other = i_Other as Motorbike;

            if (other != null)
            {
                ans = Licence == other.Licence && EngineCapacity == other.EngineCapacity;
            }

            return ans;
        }

    }
}