using System;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private const eCarState k_ECarStateDefault = eCarState.InRepair;
        private readonly string r_LicensePlate;
        private readonly string r_ModelName;
        private readonly WheelArr r_Wheels;
        private object m_Engine;
        private eCarState m_CarState;

        /******** Properties ************/
        public string Name
        {
            get { return r_ModelName; }
        }

        public string LicencePlate
        {
            get { return r_LicensePlate; }
        }

        public WheelArr Wheels
        {
            get { return r_Wheels; }
        }

        public float EnergyLeft
        {
            get
            {
                float energyLeft;
                if (IsElectric)
                {
                    energyLeft = ((ElectricEngine)Engine).BatteryLeft;
                }
                else
                {
                    energyLeft = ((GasEngine)Engine).GasLeft;
                }

                return energyLeft;
            }

            set
            {
                if (IsElectric)
                {
                    ((ElectricEngine)Engine).ChargeBattery(value);
                }
                else
                {
                    ((GasEngine)Engine).FillTank(value, ((GasEngine)Engine).GasType);
                }
            }
        }

        public float MaxEnergy
        {
            get
            {
                float maxEnergy;
                if (IsElectric)
                {
                    maxEnergy = ((ElectricEngine)Engine).MaxBattery;
                }
                else
                {
                    maxEnergy = ((GasEngine)Engine).MaxGas;
                }

                return maxEnergy;
            }
        }

        public eCarState CarState
        {
            get { return m_CarState; }
            internal set { m_CarState = value; }
        }

        public object Engine
        {
            get { return m_Engine; }
            internal set { m_Engine = value; }
        }

        public bool IsElectric
        {
            get
            {
                bool isElectric = false;

                if (Engine is ElectricEngine)
                {
                    isElectric = true;
                }
                else
                {
                    if (!(Engine is GasEngine))
                    {
                        throw new Exception("not suitable engine");
                    }
                }

                return isElectric;
            }
        }

        /******** Constructor ************/
        public Vehicle(string i_Name, string i_LicensePlate, WheelArr i_Wheels, object i_Engine)
        {
            r_ModelName = i_Name;
            r_LicensePlate = i_LicensePlate;
            r_Wheels = i_Wheels;
            m_CarState = k_ECarStateDefault;
            m_Engine = i_Engine;
        }

        /******** Methods ************/
        public override bool Equals(object obj)
        {
            bool results = false;
            Vehicle otherVehicle = obj as Vehicle;
            if (otherVehicle != null)
            {
                results = this == otherVehicle;
            }

            return results;
        }

        public static bool operator ==(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return i_Vehicle1.LicencePlate == i_Vehicle2.LicencePlate;
        }

        public static bool operator !=(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return i_Vehicle1 != i_Vehicle2;
        }

        public override int GetHashCode()
        {
            return LicencePlate.GetHashCode();
        }

        internal void UpdateVehicleState(eCarState i_CarStateTarget)
        {
                CarState = i_CarStateTarget;
        }

        public virtual bool IsPropertiesEqual(Vehicle i_Other)
        {
            bool engineEqual = isEngineEqual(i_Other);
            bool wheelsEqual = Wheels == i_Other.Wheels;

            return engineEqual && wheelsEqual;
        }

        private bool isEngineEqual(Vehicle i_Other)
        {
            bool engineEqual;
            if (IsElectric)
            {
                engineEqual = ((ElectricEngine)Engine).Equals(i_Other.Engine);
            }
            else
            {
                engineEqual = ((GasEngine)Engine).Equals(i_Other.Engine);
            }

            return engineEqual;
        }

        public override string ToString()
        {
            return string.Format(
@"
Manufacturer: {0} License: {1}
Engine:
{2}
Wheels:
{3}
Energy Left: {4} hours
Current state: {5}

",
Name,
LicencePlate,
Engine,
Wheels.ToString(),
EnergyLeft,
CarState);
        }
    }
}
