using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private const byte k_MotorbikeNumOfWheels = 2;
        private const byte k_MotorbikeMaxAirPressure = 31;
        private const float k_MotorbikeMaxBatteryTime = 2.8f;
        private const float k_MotorbikeFuelTankCapacity = 5.4f;

        private const eGasType k_MotorbikeGasType = eGasType.Octan98;
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
        private Motorbike(string i_Name, string i_LicensePlate, WheelArr i_Wheels, object i_Engine, eLicense i_License, int i_EngineCapacity)
            : base(i_Name, i_LicensePlate, i_Wheels, i_Engine)
        {
            r_License = i_License;
            r_EngineCapacity = i_EngineCapacity;
        }

        // gas motorbike
        public Motorbike(string i_Name, string i_LicensePlate, WheelArr i_Wheels, GasEngine i_Engine, eLicense i_License, int i_EngineCapacity)
            : this(i_Name, i_LicensePlate, i_Wheels, (object)i_Engine, i_License, i_EngineCapacity)
        {
        }

        public Motorbike(string i_Name, string i_LicensePlate, WheelArr i_Wheels, ElectricEngine i_Engine, eLicense i_License, int i_EngineCapacity)
            : this(i_Name, i_LicensePlate, i_Wheels, (object)i_Engine, i_License, i_EngineCapacity)
        {
        }

        /******** Methods ************/

        // return electric motor model supported by the garage
        public static Motorbike MakeDefaultElectricMotorbike()
        {
            // wheels:
            WheelArr defaultElectricMotorbikeWheels = new WheelArr(k_MotorbikeNumOfWheels, "default", 0, k_MotorbikeMaxAirPressure);

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, k_MotorbikeMaxBatteryTime);

            return new Motorbike("Manufacturer", "LicensePlate", defaultElectricMotorbikeWheels, defaultElectricEngine, k_License, k_EngineVolume);
        }

        // return gas motorbike model supported by the garage
        public static Motorbike MakeDefaultGasMotorbike()
        {
            // wheels:
            WheelArr defaultGasMotorbikeWheels = new WheelArr(2, "default", 0, k_MotorbikeMaxAirPressure);

            // engine:
            GasEngine defaultGasEngine = new GasEngine(k_MotorbikeGasType, 0, k_MotorbikeFuelTankCapacity);

            return new Motorbike("Manufacturer", "LicensePlate", defaultGasMotorbikeWheels, defaultGasEngine, k_License, k_EngineVolume);
        }

        public override bool IsPropertiesEqual(Vehicle i_Other)
        {
            bool ans = false;
            bool isEqualType = i_Other is Motorbike;

            if (isEqualType)
            {
                ans = ((Vehicle)this).IsPropertiesEqual(i_Other);
            }

            return ans;
        }

        public override string ToString()
        {
            return string.Format(@"{0}License type: {1}     Engine Capacity: {2}", base.ToString(), Licence, EngineCapacity);
        }

        internal static List<string> GetParmsForNew()
        {
            List<string> parms = new List<string>
            {
                "License type :  A = 1,AA = 2, B1 = 3, BB = 4,",
                "Engine Capacity",
            };

            return parms;
        }
    }
}