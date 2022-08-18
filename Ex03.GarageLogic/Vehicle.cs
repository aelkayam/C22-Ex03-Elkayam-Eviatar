using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle

    {
        private const eCarState k_eCarStateInit = eCarState.InRepair;

        private string m_LicensePlate; // diff

        //an relvent for compr 
        private string m_Name;
        private eCarState m_CarState;
        private float m_EnergyLeft;

        // relvent for compr 
        private object m_Engine;                // gas or electric
        private List<Wheel> m_Wheels;           // Shouldn't it be a arr[]? >>It isnt possible to add another wheel

        /******** Properties ************/
        public string Name
        {
            get { return m_Name; }
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
            m_Name = i_Name;
            m_LicensePlate = i_LicensePlate;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = i_Wheels;
            m_CarState = k_eCarStateInit; 
            m_Engine = i_Engine;
        }

        /******** Methods ************/
        public override string ToString()
        {
            return string.Format(
@"Manufacturer: {0} License: {1} Engine Type: {2}
Wheels: {3}
Energy Left: {4}%
Current state: {5}
",
Name,
LicencePlate,
Engine,
Wheels,
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

        public bool isHaveTheSameFildse()
        {

        }
    }
}
