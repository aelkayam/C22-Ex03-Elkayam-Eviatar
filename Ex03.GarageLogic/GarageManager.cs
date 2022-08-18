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

        static GarageManager()
        {
            List<Wheel> modleMotorbikeWheel = new List<Wheel>();
            List<Wheel> modleCarWheel = new List<Wheel>();
            List<Wheel> modleTruckWheel = new List<Wheel>();

            for(int i=0; i < k_MotorbikeNumOfWhell; ++i)
            {
                modleMotorbikeWheel.Add(new Wheel(k_CarMaxAirPressure));
            }

            for(int i=0; i < k_CarNumOfWhell; ++i)
            {
                modleMotorbikeWheel.Add(new Wheel(k_CarMaxAirPressure));
            }

            for (int i=0; i < k_TruckNumOfWhell; ++i)
            {
                modleMotorbikeWheel.Add(new Wheel(k_CarMaxAirPressure));
            }

            GasEngine motorbikeWGasEngine = new GasEngine(k_MotorbikeGasType, k_MotorbikeFuelTankContents,
                k_MotorbikeFuelTankContents);
            GasEngine carGasEngine = new GasEngine(k_CarGasType, k_CarFuelTankContents, k_CarFuelTankContents);
            GasEngine truckGasEngine = new GasEngine(k_TruckGasType, k_TruckFuelTankContents, k_TruckFuelTankContents);

            ElectricEngine motorbikeWElectricEngine = new ElectricEngine(k_MotorbikeMaxBatteryTime,  k_MotorbikeMaxBatteryTime);
            ElectricEngine carWElectricEngine = new ElectricEngine(k_CarMaxBatteryTime, k_CarMaxBatteryTime);

            sr_ValidVehicles = new List<Vehicle>()
            {
                   // add the regular Motorbike
                new Motorbike("damo", "demo", k_MotorbikeFuelTankContents, modleMotorbikeWheel, motorbikeWGasEngine, 
                    eLicence.AA, (int)k_MotorbikeFuelTankContents),
                 // add the electric Motorbike
                new Motorbike("damo", "demo", k_MotorbikeMaxBatteryTime, modleMotorbikeWheel, motorbikeWElectricEngine, 
                    eLicence.AA, (int)k_MotorbikeMaxBatteryTime),
                // add the regular Car
                new Car("damo", "demo", k_CarFuelTankContents, modleCarWheel, carGasEngine, eColor.Black, eDoors.FourDoors),
                // add the electric Car
                new Car("damo", "demo", k_CarMaxBatteryTime, modleCarWheel, carWElectricEngine, eColor.Black, eDoors.FourDoors),
                // add the electric Truck
                new Truck("damo", "demo", k_TruckFuelTankContents, modleTruckWheel, truckGasEngine, v_TruckRefrigerated
               , k_TruckFuelTankContents)
            };
        }

        // ======================================================
        /**             Member values of the object         **/
        // ======================================================

        private Dictionary<string, Vehicle> m_AllVehicles;//  add () v
        private string m_Name;
        private List<string> EmployeeNames;

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

        /******** Constructor ************/
        public GarageManager(string i_Name, List<string> i_EmployeeNames)
        {
            m_Name = i_Name;
            EmployeeNames = i_EmployeeNames;
            new List<string>();
            m_AllVehicles = new Dictionary<string, Vehicle>();
        }

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
            // chack if v is ok
            Truck t = new Truck();
            bool result = false;

            foreach(Vehicle v in sr_ValidVehicles)
            {
                Truck demo = v as Truck;

                if (demo != null)
                {
                    result = demo == t;
                    if (result)
                    {
                        break;
                    }
                }
            }

            // 

        }

        public bool isLinD(string i_lookFor, out Vehicle v)
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

        public bool checkIfValid()
        {
            return true;
        }

        public bool checkIfVehicleExists()
        {
            return true;
        }

        public void fillAirInWheels() { }

        public void fillEnergy() { }

        public void Fix() { }

        internal static bool isEngineElectric(object i_Engine)
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