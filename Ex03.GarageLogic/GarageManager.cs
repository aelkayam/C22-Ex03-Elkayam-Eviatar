using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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

        /******** Properties ************/
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

        internal Dictionary<string, Vehicle> AllVehicles { get { return m_AllVehicles; } }

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

            // for debugging
            m_AllVehicles.Add("1234", sr_ValidVehicles[0]);
            m_AllVehicles.Add("5678", sr_ValidVehicles[1]);
            m_AllVehicles.Add("9012", sr_ValidVehicles[2]);
        }

        /******** Methods ************/

        /**** Methods for a new car Vehicles ****/
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

        public string FilterByVehicleState(eCarState filterTarget)
        {
            StringBuilder filteredVehicles = new StringBuilder();

            foreach(Vehicle vehicle in AllVehicles.Values)
            {
                if(vehicle.CarState == filterTarget)
                {
                    filteredVehicles.AppendLine(vehicle.LicencePlate);
                }
            }

            return filteredVehicles.ToString();
        }

        // 1. receive all the data from the user in the new car
        // 2. check that LP is new (use IsExist from dictionary)
        // 3. if it is possible:        otherwise: throw EXCEPTION
        // 3.1. make new vehicle
        // 3.2. validate the vehicle (with m_AllValidVehicles)
        // 3.3. if valid: insert to Dictionary (with name and telephone)    otherwise: throw EXCEPTION

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

        public void InsertNewVehicle(string i_vehicleType, List<string> userArgsForNewVehicle)
        {
            // TODO: get parameters for: CAR, MOTORBIKE, TRUCK

            //// check if v is ok
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

        // require license. Fill air to the max
        public void FillAir(string i_UserLicensePlate)
        {
            if (checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
            {
                foreach(Wheel wheel in o_TargetVehicle.Wheels)
                {
                    wheel.FillAir();
                }
            }
            else
            {
                throw new ArgumentException("This vehicle does not exist in our garage");
            }
        }

        // require license and amount of gas
        public void FillGas(string i_UserLicensePlate, float i_GasToFill, eGasType i_TypeOfGasToFill)
        {
            if (checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
            {
                if (o_TargetVehicle.Engine is GasEngine gasEngine)
                {
                    gasEngine.FillTank(i_GasToFill, i_TypeOfGasToFill);
                }
                else
                {
                    throw new ArgumentException("This vehicle is not powered by gas");
                }
            }
            else
            {
                throw new ArgumentException("This vehicle does not exist in our garage");
            }
        }

        // require license and amount of battery
        public void FillBattery(string i_UserLicensePlate, float i_EnergyToFill)
        {
            if (checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
            {
                if (o_TargetVehicle.Engine is ElectricEngine electricEngine)
                {
                    electricEngine.ChargeBattery(i_EnergyToFill);
                }
                else
                {
                    throw new ArgumentException("This vehicle is not powered by electricity");
                }
            }
            else
            {
                throw new ArgumentException("This vehicle does not exist in our garage");
            }
        }

        // require license.
        public void Fix(string i_UserLicensePlate)
        {
            UpdateCarState(i_UserLicensePlate, eCarState.Repaired);
        }

        // require license and car state.
        public eCarState UpdateCarState(string i_UserLicensePlate, eCarState i_CarStateTarget)
        {
            if(checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
            {
                o_TargetVehicle.UpdateVehicleState(i_CarStateTarget);
                return o_TargetVehicle.CarState;
            }
            else
            {
                throw new ArgumentException("This vehicle does not exist in our garage");
            }
        }

        // require license.
        public string GetDetailsAboutVehicle(string i_LicensePlate)
        {
            if (checkIfExist(i_LicensePlate, out Vehicle o_ChosenVehicle))
            {
                return o_ChosenVehicle.ToString();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        // return string of all license plates currently in the garage
        public string GetDetailsAboutAllVehicles()
        {
            StringBuilder allLicensePlates = new StringBuilder(string.Empty);

            foreach (string licensePlate in AllVehicles.Keys)
            {
                allLicensePlates.AppendLine(licensePlate);
            }

            return allLicensePlates.ToString();
        }

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