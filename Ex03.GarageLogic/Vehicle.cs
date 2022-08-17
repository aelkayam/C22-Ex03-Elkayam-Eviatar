using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private readonly string r_Name;
        private readonly string r_LicensePlate;
        private readonly List<Wheel> r_Wheels;
        private float m_EnergyLeft;
        private eCarState m_CarState;
        private object m_Engine; // gas or electric

        /******** Properties ************/
        public string Name
        {
            get { return r_Name; }
        }

        public string LicencePlate
        {
            get { return r_LicensePlate; }
        }

        public List<Wheel> Wheels
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

        /******** Constructor ************/
        public Vehicle(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, eCarState i_CarState, object i_Engine)
        {
            r_Name = i_Name;
            r_LicensePlate = i_LicensePlate;
            m_EnergyLeft = i_EnergyLeft;
            r_Wheels = i_Wheels;
            m_CarState = i_CarState;

            // check if object i_Engine is an engine
            bool isElectric = GarageManager.isEngineElectric(i_Engine);

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
    }
}
