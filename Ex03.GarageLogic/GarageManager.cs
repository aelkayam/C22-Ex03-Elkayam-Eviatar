using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private const string k_InsertionFailed = "The insertion of the new vehicle failed ";
        private const string k_Lineseparator = "===========================";
        private static readonly List<Vehicle> sr_ValidVehicles;
        private readonly Dictionary<string, VehicleOwner> r_DataOfAllVehicles;

        private Dictionary<string, VehicleOwner> DataOfAllVehicles
        {
            get { return r_DataOfAllVehicles; }
        }

        /******** Properties ************/
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
        public GarageManager()
        {
            new List<string>();
            r_DataOfAllVehicles = new Dictionary<string, VehicleOwner>();
        }

        /******** Methods ************/

        public List<string> GetParams(string i_VehicleType)
        {
            List<string> list = new List<string>();

            switch (i_VehicleType)
            {
                case "car":
                    list = Car.GetParmsForNew();
                    break;
                case "truck":
                    list = Truck.GetParmsForNew();
                    break;
                case "motorbike":
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
                string nameVehicle = vehicle.GetType().Name.ToLower();

                if (!result.Contains(nameVehicle))
                {
                    result.Add(nameVehicle);
                }
            }

            return result;
        }

        public bool DoesLicensePlateExist(string i_LicensePlates)
        {
            return checkIfExist(i_LicensePlates, out _);
        }

        public string FilterByVehicleState(eCarState i_FilterTarget)
        {
            bool isEmpty = true;
            StringBuilder filteredVehicles = new StringBuilder();
            filteredVehicles.AppendLine(k_Lineseparator);

            foreach (KeyValuePair<string, VehicleOwner> vehicleOwnerKAndVP in r_DataOfAllVehicles )
            {
                if (vehicleOwnerKAndVP.Value.CarState == i_FilterTarget)
                {
                    isEmpty = false;
                    filteredVehicles.AppendLine(vehicleOwnerKAndVP.Key);
                }
            }

            if (isEmpty)
            {
                filteredVehicles.AppendLine("No matching vehicles found!");
            }

            filteredVehicles.Append(k_Lineseparator);

            return filteredVehicles.ToString();
        }

        public void FillAir(string i_UserLicensePlate)
        {
            if (checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
            {
                o_TargetVehicle.Wheels.FillAir();
            }
            else
            {
                throw new ArgumentException("This vehicle does not exist in our garage");
            }
        }

        private bool checkIfExist(string i_LicensePlateToLookFor, out Vehicle o_Vehicle)
        {
            bool result = false;
            o_Vehicle = null;

            if (i_LicensePlateToLookFor != null)
            {
                result = r_DataOfAllVehicles.TryGetValue(i_LicensePlateToLookFor, out VehicleOwner o_Owner);
                if (result)
                {
                    o_Vehicle = o_Owner.Vehicle;
                }
            }

            return result;
        }

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

        public void UpdateCarState(string i_UserLicensePlate, eCarState i_CarStateTarget)
        {
            if (checkIfExist(i_UserLicensePlate, out Vehicle o_TargetVehicle))
            {
                o_TargetVehicle.UpdateVehicleState(i_CarStateTarget);
            }
            else
            {
                throw new ArgumentException("This vehicle does not exist in our garage");
            }
        }

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

        private bool validationNewVehicle(Vehicle i_NewVehicle)
        {
            bool ans = false;

            foreach (Vehicle v in sr_ValidVehicles)
            {
                ans = i_NewVehicle.ArePropertiesEqual(v);

                if (ans)
                {
                    break;
                }
            }

            return ans;
        }

        public void InsertNewVehicle(string i_LicensePlate, string i_VehicleType, string i_ModelName, bool i_IsElectric, eGasType i_GasTypeToFill, float i_MaxEnergy, float i_EnergyToFill, int i_NumOfWheels, float i_MaxAirPressure, float i_CurrentAirPressure, string i_WheelsManufacturer, List<string> i_UserArgsForNewVehicle, string i_Name, string i_PhoneNumber)
        {
            try
            {
                Vehicle enteringVehcile;
                WheelArr wheels = new WheelArr(i_NumOfWheels, i_WheelsManufacturer, i_CurrentAirPressure, i_MaxAirPressure);
                object engine = createEngine(i_IsElectric, i_GasTypeToFill, i_EnergyToFill, i_MaxEnergy);

                switch (i_VehicleType)
                {
                    case "car":
                        enteringVehcile = createNewCar(i_LicensePlate, i_ModelName, i_IsElectric, engine, wheels, i_UserArgsForNewVehicle);
                        break;
                    case "truck":
                        enteringVehcile = createNewTruck(i_LicensePlate, i_ModelName, i_IsElectric, engine, wheels, i_UserArgsForNewVehicle);
                        break;
                    case "motorbike":
                        enteringVehcile = createNewMotorbike(i_LicensePlate, i_ModelName, i_IsElectric, engine, wheels, i_UserArgsForNewVehicle);
                        break;
                    default: throw new FormatException();
                }

                bool isCarValid = validationNewVehicle(enteringVehcile);
                if (isCarValid)
                {
                    DataOfAllVehicles.Add(i_LicensePlate, new VehicleOwner(i_Name, i_PhoneNumber, i_LicensePlate, enteringVehcile));
                }
                else
                {
                    throw new FormatException(k_InsertionFailed);
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException(k_InsertionFailed);
            }
            catch (Exception e)
            {
                throw new FormatException(k_InsertionFailed, e);
            }
        }

        public string GetDetailsAboutAllVehicles()
        {
            StringBuilder allLicensePlates = new StringBuilder(string.Empty);
            allLicensePlates.AppendLine(k_Lineseparator);

            foreach (string licensePlate in DataOfAllVehicles.Keys)
            {
                allLicensePlates.AppendLine(licensePlate);
            }

            allLicensePlates.Append(k_Lineseparator);

            return allLicensePlates.ToString();
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

        private Motorbike createNewMotorbike(string i_LicensePlate, string i_ModelName, bool i_IsElectric, object i_Engine, WheelArr i_Wheels, List<string> i_UserArgsForNewVehicle)
        {
            Motorbike motorbike;
            bool success1 = Enum.TryParse<eLicense>(i_UserArgsForNewVehicle[0], out eLicense o_License);
            bool success2 = int.TryParse(i_UserArgsForNewVehicle[1], out int o_EngineCapacity);

            if (success1 && success2)
            {
                if (i_IsElectric)
                {
                    motorbike = new Motorbike(i_ModelName, i_LicensePlate, i_Wheels, (ElectricEngine)i_Engine, o_License, o_EngineCapacity);
                }
                else
                {
                    motorbike = new Motorbike(i_ModelName, i_LicensePlate, i_Wheels, (GasEngine)i_Engine, o_License, o_EngineCapacity);
                }
            }
            else
            {
                throw new FormatException("wrong arguments");
            }

            return motorbike;
        }

        private Truck createNewTruck(string i_LicensePlate, string i_ModelName, bool i_IsElectric, object i_Engine, WheelArr i_Wheels, List<string> i_UserArgsForNewVehicle)
        {
            Truck truck;
            bool success1 = bool.TryParse(i_UserArgsForNewVehicle[0], out bool o_IsRefrigerated);
            bool success2 = float.TryParse(i_UserArgsForNewVehicle[1], out float o_MaxCapacity);

            if (success1 && success2)
            {
                if (i_IsElectric)
                {
                    truck = new Truck(i_ModelName, i_LicensePlate, i_Wheels, (ElectricEngine)i_Engine, o_IsRefrigerated, o_MaxCapacity);
                }
                else
                {
                    truck = new Truck(i_ModelName, i_LicensePlate, i_Wheels, (GasEngine)i_Engine, o_IsRefrigerated, o_MaxCapacity);
                }
            }
            else
            {
                throw new FormatException("wrong arguments");
            }

            return truck;
        }

        private Car createNewCar(string i_LicensePlate, string i_ModelName, bool i_IsElectric, object i_Engine, WheelArr i_Wheels, List<string> i_UserArgsForNewVehicle)
        {
            Car car;
            bool success1 = Enum.TryParse<eColor>(i_UserArgsForNewVehicle[0], out eColor o_Color);
            bool success2 = Enum.TryParse<eDoors>(i_UserArgsForNewVehicle[1], out eDoors o_Doors);

            if (success1 && success2)
            {
                if (i_IsElectric)
                {
                    car = new Car(i_ModelName, i_LicensePlate, i_Wheels, (ElectricEngine)i_Engine, o_Color, o_Doors);
                }
                else
                {
                    car = new Car(i_ModelName, i_LicensePlate, i_Wheels, (GasEngine)i_Engine, o_Color, o_Doors);
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