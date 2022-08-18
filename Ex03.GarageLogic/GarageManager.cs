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
        private Dictionary<string, VehicleOwner> m_AllOwners;

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

        /******** Methods ************/

        /**** Methods  for a new car Vehicles ****/
        public List<string> GetParams(string i_VehicleType, bool i_isElctiric ,int i_NumOfWheel)
        {
            List<string> list = new List<string>();

            switch(i_VehicleType)
            {
                case "Car":
                    list = Car.GetParmsForNew(i_isElctiric, i_NumOfWheel);
                    break;
                case "Truck":
                    list = Truck.GetParmsForNew(i_isElctiric, i_NumOfWheel);
                    break;
                case "Motorbike":
                    list = Motorbike.GetParmsForNew(i_isElctiric, i_NumOfWheel);
                    break;
            }

            list.Add("The name of the owner of the vehicle");
            list.Add("The phone number of the owner of the vehicle");

            return list;
        }

        public List<string> GetVehicleTypes()
        {
            List<string> result = new List<string>();
            foreach(Vehicle vehicle in sr_ValidVehicles)
            {
                string nameVehicle = vehicle.GetType().Name;

                if (!result.Contains(nameVehicle))
                {
                    result.Add(nameVehicle);
                }
            }

            return result;
        }

        // 1. receive all the data from the user in the new car
        // 2. check that LP is new (use IsExist from dictionary)
        // 3. if it is possible:        otherwise: throw EXCEPTION
        // 3.1. make new vehicle
        // 3.2. validate the vehicle (with m_AllValidVehicles)
        // 3.3. if valid: insert to Dictionary (with name and telephone)    otherwise: throw EXCEPTION
        public void InsertNewVehicle(string i_VehicleType, List<string> i_ArgsForNewVehicle)
        {
            Console.WriteLine("in InsertNewVehicle");
        }

        private bool checkIfExist(string i_LicensePlateToLookFor, out Vehicle o_Vehicle)
        {
            bool result = false;
            o_Vehicle = null;

            if (i_LicensePlateToLookFor != null)
            {

                result = m_AllVehicles.TryGetValue(i_LicensePlateToLookFor, out o_Vehicle);
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



        // require license, air (in BAR/PSI) and index of wheels to apply.
        // if no index given, fill all the wheels in the given amount
        public void FillAirInWheels(string i_UserLicensePlate, float i_UnitsToFill, params int[] i_WheelIndex) { }

        // require license and amount of gas
        public void FillGas(string i_UserLicensePlate, float i_GasToFill) { }

        // require license and amount of battery
        public void FillBattery(string i_UserLicensePlate, float i_EnergyToFill) { }

        public void Fix(string i_UserLicensePlate) { }

        public eCarState updateCarState(string i_UserLicensePlate) { return eCarState.InRepair; }

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

        // TODO: AT THE END
        //// return list of parameters (name and type) from method name 
        //public List<Props> getProps(MethodInfo i_MethodName)
        //{
        //    ParameterInfo[] parameterInfo = i_MethodName.GetParameters();
        //    foreach(ParameterInfo pi in parameterInfo)
        //    {
                
        //    }
           
        //}
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