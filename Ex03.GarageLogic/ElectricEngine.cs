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

        // charge to the max
        internal void ChargeBattery()
        {
            BatteryLeft = MaxBattery;
        }

        // charge by given amount (hours)
        internal void ChargeBattery(float i_EnergyToFill)
        {
            if(BatteryLeft + i_EnergyToFill <= MaxBattery)
            {
                BatteryLeft += i_EnergyToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(MaxBattery - BatteryLeft, 0);
            }
        }

        public override string ToString()
        {
            return string.Format(@"Battery Left: {0} hours   Max:{1} hours", BatteryLeft, MaxBattery);
        }

        public override bool Equals(object obj)
        {
            return obj is ElectricEngine engine &&
                   MaxBattery == engine.MaxBattery;
        }

        public static bool operator ==(ElectricEngine left, ElectricEngine right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ElectricEngine left, ElectricEngine right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return -250832942 + MaxBattery.GetHashCode();
        }
    }
}
