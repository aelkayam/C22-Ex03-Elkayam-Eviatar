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
        internal const bool k_TruckRefrigerated = true;

        private static readonly List<Vehicle> sr_ValidVehicles;
        private static readonly Random sr_Random = new Random();

        // ======================================================
        /** Member values of the object         **/
        // ======================================================

        private string m_Name;
        private List<string> m_EmployeeNames;

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
                return m_EmployeeNames[sr_Random.Next(m_EmployeeNames.Count)];
            }
        }

        public string Owner
        {
            get { return m_EmployeeNames[0]; }
            set { m_EmployeeNames[0] = value; }
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
            m_EmployeeNames = i_EmployeeNames;
            new List<string>();
            m_AllVehicles = new Dictionary<string, Vehicle>();

            //// for debugging
            //m_AllVehicles.Add("1234", sr_ValidVehicles[0]);
            //m_AllVehicles.Add("5678", sr_ValidVehicles[1]);
            //m_AllVehicles.Add("9012", sr_ValidVehicles[2]);
        }

        /******** Methods ************/

        /**** Methods for a new car Vehicles ****/
        public List<string> GetParams(string i_VehicleType)
        {
            List<string> list = new List<string>();

            switch (i_VehicleType)
            {
                case "Car":
                    list = Car.GetParmsForNew();
                    break;
                case "Truck":
                    list = Truck.GetParmsForNew();
                    break;
                case "Motorbike":
                    list = Motorbike.GetParmsForNew();
                    break;
            }

            return list;
        }

        public List<string> GetVehicleTypes()
        {
            List<string> result = new List<string>();
            foreach (Vehicle vehicle in sr_ValidVehicles)
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

            foreach (Vehicle vehicle in AllVehicles.Values)
            {
                if (vehicle.CarState == filterTarget)
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

        public bool DoesLicensePlateExist(string i_LicensePlates)
        {
            return checkIfExist(i_LicensePlates, out _);
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

        // require license. Fill air to the max
        public void FillAir(string i_UserLicensePlate)
        {
            if (checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
            {
                foreach (Wheel wheel in o_TargetVehicle.Wheels)
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
            if (checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
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

            switch (i_Engine)
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

        public void InsertNewVehicle(string i_LicensePlate, string i_VehicleType, string i_ModelName, bool i_IsElectric,
            eGasType i_GasTypeToFill, float i_MaxEnergy, float i_EnergyToFill, int i_NumOfWheels, float i_MaxAirPressure,
            float i_CurrentAirPressure, string i_WheelsManufacturer, List<string> i_UserArgsForNewVehicle, string i_Name,
            string i_PhoneNumber)
        {
            try
            {
                Vehicle v;
                List<Wheel> wheels = createWheels(i_NumOfWheels, i_WheelsManufacturer, i_MaxAirPressure, i_CurrentAirPressure);
                object engine = createEngine(i_IsElectric, i_GasTypeToFill, i_EnergyToFill, i_MaxEnergy);

                switch (i_VehicleType)
                {
                    case "Car":
                        v = createNewCar(i_LicensePlate, i_ModelName, i_IsElectric, engine, wheels, i_UserArgsForNewVehicle);
                        break;
                    case "Truck":
                        v = createNewTruck(i_LicensePlate, i_ModelName, i_IsElectric, engine, wheels, i_UserArgsForNewVehicle);
                        break;
                    case "Motorbike":
                        v = createNewMotorbike(i_LicensePlate, i_ModelName, i_IsElectric, engine, wheels, i_UserArgsForNewVehicle);
                        break;
                    default: throw new FormatException();
                }

                AllVehicles.Add(i_LicensePlate, v);
            }
            catch (ArgumentException)
            {
                // we already catch exceptions in runner!
            }
            catch (Exception)
            {
                // we already catch exceptions in runner!
            }

        }

        private object createEngine(bool i_IsElectric, eGasType i_GasTypeToFill, float i_EnergyToFill, float i_MaxEnergy)
        {
            object engine;
            if (i_IsElectric)
            {
                engine = new ElectricEngine(i_EnergyToFill, i_MaxEnergy);
            }
            else
            {
                engine = new GasEngine(i_GasTypeToFill, i_EnergyToFill, i_MaxEnergy);
            }

            return engine;
        }

        private List<Wheel> createWheels(int i_NumOfWheels, string i_Manufacturer, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < wheels.Count; i++)
            {
                wheels.Add(new Wheel(i_Manufacturer, i_CurrentAirPressure, i_MaxAirPressure));
            }

            return wheels;
        }

        private Motorbike createNewMotorbike(string i_LicensePlate, string i_ModelName, bool i_IsElectric, object engine, List<Wheel> wheels, List<string> i_UserArgsForNewVehicle)
        {
            Motorbike motorbike;
            bool success1 = Enum.TryParse<eLicense>(i_UserArgsForNewVehicle[0], out eLicense o_License);
            bool success2 = int.TryParse(i_UserArgsForNewVehicle[1], out int o_EngineCapacity);

            if (success1 && success2)
            {
                if (i_IsElectric)
                {
                    motorbike = new Motorbike(i_ModelName, i_LicensePlate, 0f, wheels, (ElectricEngine)engine, o_License, o_EngineCapacity);
                }
                else
                {
                    motorbike = new Motorbike(i_ModelName, i_LicensePlate, 0f, wheels, (GasEngine)engine, o_License, o_EngineCapacity);
                }
            }
            else
            {
                throw new FormatException("wrong arguments");
            }

            return motorbike;
        }

        private Truck createNewTruck(string i_LicensePlate, string i_ModelName, bool i_IsElectric, object engine, List<Wheel> wheels, List<string> i_UserArgsForNewVehicle)
        {
            Truck truck;
            bool success1 = bool.TryParse(i_UserArgsForNewVehicle[0], out bool o_IsRefrigerated);
            bool success2 = float.TryParse(i_UserArgsForNewVehicle[1], out float o_MaxCapacity);

            if (success1 && success2)
            {
                truck = new Truck(i_ModelName, i_LicensePlate, 0f, wheels, engine, o_IsRefrigerated, o_MaxCapacity);
            }
            else
            {
                throw new FormatException("wrong arguments");
            }

            return truck;
        }

        private Car createNewCar(string i_LicensePlate, string i_ModelName, bool i_IsElectric, object engine, List<Wheel> wheels, List<string> i_UserArgsForNewVehicle)
        {
            Car car;
            bool success1 = Enum.TryParse<eColor>(i_UserArgsForNewVehicle[0], out eColor o_color);
            bool success2 = Enum.TryParse<eDoors>(i_UserArgsForNewVehicle[1], out eDoors o_Doors);

            if (success1 && success2)
            {
                if (i_IsElectric)
                {
                    car = new Car(i_ModelName, i_LicensePlate, 0f, wheels, (ElectricEngine)engine, o_color, o_Doors);
                }
                else
                {
                    car = new Car(i_ModelName, i_LicensePlate, 0f, wheels, (GasEngine)engine, o_color, o_Doors);
                }
            }
            else
            {
                throw new FormatException("wrong arguments");
            }

            return car;
        }
    }
}