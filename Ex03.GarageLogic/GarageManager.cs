using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    // ======================================================
    // ****************** GarageManager ****************** //
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

        public static Random random = new Random();

        // ======================================================
        /** Member values of the object         **/
        // ======================================================

        private string m_Name;
        private List<string> EmployeeNames;

        // make "Owner" object instead of "string" as KEY in dictionary (?)
        private Dictionary<string, Vehicle> m_AllVehicles;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Employee
        {
            get
            {
                return EmployeeNames[random.Next(EmployeeNames.Count)];
            }
        }

        public string Owner
        {
            get { return EmployeeNames[0]; }
            set { EmployeeNames[0] = value; }
        }

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

        /******** Constructor ************/
        public GarageManager(string i_Name, List<string> i_EmployeeNames)
        {
            m_Name = i_Name;
            EmployeeNames = i_EmployeeNames;
            new List<string>();
            m_AllVehicles = new Dictionary<string, Vehicle>();
        }



        public void InsertNewVehicle(string i_SerialNum, string i_Wheel)
        {
            //// chack if v is ok
            //Truck t = new Truck();
            //bool result = false;

            //foreach(Vehicle v in sr_ValidVehicles)
            //{
            //    Truck demo = v as Truck;

            //    if (demo != null)
            //    {
            //        result = demo == t;
            //        if (result)
            //        {
            //            break;
            //        }
            //    }
            //}

        }

        private bool checkIfExist(string i_lookFor, out Vehicle v)
        {
            bool result = false;
            v = null;

            if (i_lookFor != null)
            {
                result = m_AllVehicles.TryGetValue(i_lookFor, out v);
            }

            return result;
        }

        private void createVehicle()
        {
        }

        public bool CheckIfValid()
        {
            return true;
        }

        public bool CheckIfVehicleExists()
        {
            return true;
        }

        public void FillAirInWheels() { }

        public void FillEnergy() { }

        public void Fix() { }

        internal static bool IsEngineElectric(object i_Engine)
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

/*
 * 
 *  
 * 
 * 
 * 
 *           {
            ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(item, ExceptionArgument.item);
            try
            {
                Add((T) item);
    }
            catch (InvalidCastException)
            {
                ThrowHelper.ThrowWrongValueTypeArgumentException(item, typeof(T));
            }

return Count - 1;
*/