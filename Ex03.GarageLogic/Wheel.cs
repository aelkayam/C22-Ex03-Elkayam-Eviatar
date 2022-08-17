using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct Wheel
    {
        private const string k_Manufacturer = "MICHELIN";
        private const float k_InflatedPercentage = 0.75f; 
        private string m_ManufacturerName;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        /******** Properties ************/
        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { this.m_ManufacturerName = value; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { this.m_MaxAirPressure = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        /******** Constructor ************/
        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure =Math.Min(i_CurrentAirPressure , i_MaxAirPressure);
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(float i_MaxAirPressure)
            :this(k_Manufacturer ,i_MaxAirPressure , i_MaxAirPressure* k_InflatedPercentage)
        {

        }

        /******** Methods ************/
        public override string ToString()
        {
            return string.Format(@"Current: {0} Max: {1}", CurrentAirPressure, MaxAirPressure);
        }
    }
}
