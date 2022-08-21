using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal struct ElectricEngine
    {
        private float m_BatteryLeft;
        private float m_MaxBattery;

        /******** Properties ************/
        public float BatteryLeft
        {
            get { return m_BatteryLeft; }
            set { m_BatteryLeft = value; }
        }

        public float MaxBattery
        {
            get { return m_MaxBattery; }
            set { m_MaxBattery = value; }
        }

        /******** Constructor ************/
        public ElectricEngine(float i_BatteryLeft, float i_MaxBattery)
        {
            m_BatteryLeft = i_BatteryLeft;
            m_MaxBattery = i_MaxBattery;
        }

        /******** Methods ************/
        public override string ToString()
        {
            return string.Format(@"Battery Left: {0}%    Max:{1}%", BatteryLeft, MaxBattery);
        }

        internal static List<string> getPramsForNew()
        {
            List<string> prams = new List<string>();
            prams.Add("Battery Left");
            prams.Add("Max Battery");

            return prams;
        }

        internal void ChargeBattery(float i_EnergyToFill)
        {
            throw new NotImplementedException();
        }
    }
}
