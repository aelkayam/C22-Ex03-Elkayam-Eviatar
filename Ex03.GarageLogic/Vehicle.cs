using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private const eCarState k_ECarStateInit = eCarState.InRepair;  // move it 

        private readonly string r_LicensePlate; // different

        // relevant for compare
        private readonly string r_ModelName;
        private readonly WheelArr r_Wheels;
        private object m_Engine; // gas or electric

        // irrelevant for compare
        private eCarState m_CarState;
        private float m_EnergyLeft;

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
                    if (!(Engine is GasEngine))
                    {
                        throw new Exception("not suitable engine");
                    }
                }

                return isElectric;
            }
        }

        /******** Constructor ************/
        public Vehicle(string i_Name, string i_LicensePlate, float i_EnergyLeft, WheelArr i_Wheels, object i_Engine)
        {
            r_ModelName = i_Name;
            r_LicensePlate = i_LicensePlate;
            m_EnergyLeft = i_EnergyLeft;
            r_Wheels = i_Wheels;
            m_CarState = k_ECarStateInit;
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
            Console.WriteLine("in v");
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
