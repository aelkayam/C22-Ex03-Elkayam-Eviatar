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
            get { return this.m_CurrentAirPressure; }
            set { this.m_CurrentAirPressure = value; }
        }

        /******** Constructor ************/
        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            bool isParmsValid = i_CurrentAirPressure <= i_MaxAirPressure && i_MaxAirPressure > 0 && i_CurrentAirPressure > 0;
            if (!isParmsValid)
            {
                throw new ValueOutOfRangeException(i_MaxAirPressure, i_CurrentAirPressure);
            }

            this.m_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(float i_MaxAirPressure)
            : this(k_Manufacturer, i_MaxAirPressure, i_MaxAirPressure * k_InflatedPercentage)
        {
        }

        public static List<Wheel> GetDefaultListWheels(int i_NumOfWheels, string i_ManufacturerName,
            float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < wheels.Count; i++)
            {
                wheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }

            return wheels;
        }

        /******** Methods ************/
        public void FillAir()
        {
            CurrentAirPressure = MaxAirPressure;
        }

        public void FillAir(float i_AirPressureToAdd)
        {
            if(CurrentAirPressure + i_AirPressureToAdd <= MaxAirPressure)
            {
                CurrentAirPressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(MaxAirPressure - CurrentAirPressure, 0);
            }
        }

        public override string ToString()
        {
            return string.Format(@"Current: {0}     Max: {1}", CurrentAirPressure, MaxAirPressure);
        }

        public static bool operator ==(Wheel i_Wheel1, Wheel i_Wheel2)
        {
            return i_Wheel1.Equals(i_Wheel2);
        }

        public static bool operator !=(Wheel i_Wheel1, Wheel i_Wheel2)
        {
            return !i_Wheel1.Equals(i_Wheel2);
        }

        public override bool Equals(object obj)
        {
            return obj is Wheel wheel &&
                   ManufacturerName == wheel.ManufacturerName &&
                   MaxAirPressure == wheel.MaxAirPressure;
        }

        public override int GetHashCode()
        {
            int hashCode = -944765117;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(ManufacturerName);
            hashCode = (hashCode * -1521134295) + MaxAirPressure.GetHashCode();
            return hashCode;
        }
    }
}
