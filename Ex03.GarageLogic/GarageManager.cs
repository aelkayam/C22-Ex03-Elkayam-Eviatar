using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    // ======================================================
    //  ** GarageManager                   **/
    // ======================================================
    public class GarageManager
    {
        // ======================================================
        /** Default values vehicles that can enter the garage **/
        // ======================================================
        // Default number of wheels
        internal const byte k_MotorbikeNumOfWheels = 2;
        internal const byte k_CarNumOfWheels = 4;
        internal const byte k_TruckNumOfWheels = 16;

        // Default pressure values
        internal const byte k_MotorbikeMaxAirPressure = 31;
        internal const byte k_CarMaxAirPressure = 27;
        internal const byte k_TruckMaxAirPressure = 25;

        // Default fuel type
        internal const eGasType k_MotorbikeGasType = eGasType.Octan98;
        internal const eGasType k_CarGasType = eGasType.Octan95;
        internal const eGasType k_TruckGasType = eGasType.Soler;

        // Default Maximum battery time
        internal const float k_MotorbikeMaxBatteryTime = 2.8f;
        internal const float k_CarMaxBatteryTime = 4.5f;

        // Default Fuel tank contents
        internal const float k_MotorbikeFuelTankCapacity = 5.4f;
        internal const float k_CarFuelTankCapacity = 52f;
        internal const float k_TruckFuelTankCapacity = 135f;

        // Default Truck Refrigerated
        internal const bool v_TruckRefrigerated = true;

        // Default eLicence  string
        // 0 = class
        internal const string k_FormtLicenceDefult = "Default{0}{1}";

        private static readonly List<Vehicle> sr_ValidVehicles;

        // make "Owner" object instead of "string" as KEY in dictionary (?)
        private Dictionary<string, Vehicle> m_AllVehicles;

        static GarageManager()
        {
            sr_ValidVehicles = new List<Vehicle>
            {
                // add the regular Motorbike
                Motorbike.MakeDefaultGasMotorbike(),

                // add the electric Motorbike
                Motorbike.MakeDefaultElectricMotorbike(),
                    
                // add the regular Car
                Car.MakeDefaultGasCar(),

                // add the electric Car
                Car.MakeDefaultElectricCar(),

                // add the electric Truck
                Truck.MakeDefaultTruck(),
            };
        }

        public void InsertNewVehicle(string i_SerialNum, string i_Wheel)
        {
            /*
             *  private string m_Name;
                private string m_SerialNumber;
                private float m_EnergyLeft;
                private List<Wheel> m_Wheels;
                private eCarState m_CarState;
                private object m_Engine; // gas or electric
             */
        }

        private void createVehicle()
        {
        }

        private bool checkIfValid() { return true; }

        private bool checkIfVehicleExists() { return true; }

        private void fillAirInWheels() { }

        private void fillEnergy() { }

        private void fix() { }

        public static bool isEngineElectric(object i_Engine)
        {
            bool isEngineElectric = false;

            switch(i_Engine)
            {
                case GasEngine ge: /// typeof(GasEngine engine):
                    break;
                case ElectricEngine ee:
                    isEngineElectric = true;
                    break;
                case null:
                    throw new ArgumentNullException("NO ENGIN!");
                default:
                    throw new FormatException();
            }

            return isEngineElectric;
        }
    }
}
