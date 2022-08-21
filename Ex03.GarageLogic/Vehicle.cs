using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private const eCarState k_eCarStateInit = eCarState.InRepair;

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

        /******** Constructor ************/
        public Vehicle(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine)
        {
            m_ModelName = i_Name;
            m_LicensePlate = i_LicensePlate;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
            m_CarState = k_eCarStateInit;
            m_Engine = i_Engine;
        }

        /******** Methods ************/
        private string getAllWheels()
        {
            StringBuilder wheelsList = new StringBuilder();
            foreach(Wheel wheel in Wheels)
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

        protected bool HaveTheSameFields(Vehicle i_OtherVehicle)
        {
            return m_Engine == i_OtherVehicle.Engine &&
                m_Wheels == i_OtherVehicle.Wheels &&
                m_ModelName == i_OtherVehicle.Name;
        }

        protected static List<string> GetParmsForNew(bool i_isElctiric, int i_NumOfWheel)
        {
            List<string> parms = new List<string>();
            parms.Add("Name of the model");
            parms.Add("License Plate");
            parms.Add("Energy Left");

            List<string> wheelPams = Wheel.getPramsForNew();
            for (int i = 0; i < i_NumOfWheel; ++i)
            {
                parms.AddRange(wheelPams);
            }

            if (i_isElctiric)
            {
                parms.AddRange(GasEngine.getPramsForNew());
            }
            else
            {
                parms.AddRange(ElectricEngine.getPramsForNew());
            }

            return parms;
        }

        internal void UpdateVehicleState(eCarState i_CarStateTarget)
        {
            if(i_CarStateTarget > CarState)
            {
                CarState = i_CarStateTarget;
            }
            else
            {
                throw new ArgumentException("Cannot go back to " + i_CarStateTarget.ToString());
            }
        }
    }
}
