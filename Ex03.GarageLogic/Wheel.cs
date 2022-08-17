using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        /******** Properties ************/
        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        /******** Constructor ************/
        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        /******** Methods ************/
        public override string ToString()
        {
            return string.Format(@"Current: {0} Max: {1}", CurrentAirPressure, MaxAirPressure);
        }
    }
}
