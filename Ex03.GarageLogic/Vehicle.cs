using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private const eCarState k_ECarStateInit = eCarState.InRepair;

        private string m_LicensePlate; // different

        // irrelevant for compare
        private eCarState m_CarState;
        private float m_EnergyLeft;

        // relevant for compare
        private string m_ModelName;
        private object m_Engine; // gas or electric
        private List<Wheel> m_Wheels;

        /******** Properties ************/
        public string Name
        {
            get { return m_ModelName; }
        }

        public string LicencePlate
        {
            get { return m_LicensePlate; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
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
                    if (Engine is GasEngine)
                    {

                    }
                    else
                    {
                        throw new Exception("no engin");
                    }

                }

                return isElectric;

            }
        }

        /******** Constructor ************/
        public Vehicle(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine)
        {
            m_ModelName = i_Name;
            m_LicensePlate = i_LicensePlate;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
            m_CarState = k_ECarStateInit;
            m_Engine = i_Engine;
        }

        /******** Methods ************/
        private string getAllWheels()
        {
            StringBuilder wheelsList = new StringBuilder();
            foreach (Wheel wheel in Wheels)
            {
                wheelsList.AppendLine(wheel.ToString());
            }

            wheelsList.AppendLine();
            return wheelsList.ToString();
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
getAllWheels(),
EnergyLeft,
CarState);
        }

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

        // license plate comparison
        public static bool operator ==(Vehicle i_vehicle1, Vehicle i_vehicle2)
        {
            return i_vehicle1.LicencePlate == i_vehicle2.LicencePlate;
        }

        public static bool operator !=(Vehicle i_vehicle1, Vehicle i_vehicle2)
        {
            return i_vehicle1 != i_vehicle2;
        }

        public override int GetHashCode()
        {
            return LicencePlate.GetHashCode();
        }

        internal void UpdateVehicleState(eCarState i_CarStateTarget)
        {
            if (i_CarStateTarget > CarState)
            {
                CarState = i_CarStateTarget;
            }
            else
            {
                throw new ArgumentException("Cannot go back to " + i_CarStateTarget.ToString());
            }
        }

        public virtual bool IsPropertiesEqual(Vehicle i_Other) 
        {
            bool engineEqual = isEngineEqual(i_Other);
            bool wheelsEqual = isWheelsEqual(i_Other);

            return engineEqual && wheelsEqual;
        }

        private bool isWheelsEqual(Vehicle i_Other)
        {
            bool wheelsEqual = false;
            bool quantityWheels = Wheels.Count == i_Other.Wheels.Count;

            if (quantityWheels)
            {
                Wheel[] vehcicalWheels = Wheels.ToArray();
                Wheel[] otherWheels = i_Other.Wheels.ToArray();

                wheelsEqual = true;

                for (int i = 0; i < Wheels.Count; i++)
                {
                    if (vehcicalWheels[i] != otherWheels[i])
                    {
                        wheelsEqual = false;
                        break;
                    }
                }

            }

            return wheelsEqual; 
        }

        private bool isEngineEqual(Vehicle i_Other)
        {
            bool engineEqual = false;

            if (IsElectric)
            {
                engineEqual = ((ElectricEngine)Engine).Equals(i_Other.Engine);
            }
            else
            {
                engineEqual = ((GasEngine) Engine).Equals(i_Other.Engine);
            }

            return engineEqual;
        }
    }
}
