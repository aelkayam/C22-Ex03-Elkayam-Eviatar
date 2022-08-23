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

        // TODO : create a property  of how much fuel is left in percent

        public override string ToString()
        {
            return string.Format(@"Battery Left: {0} hours   Max:{1} hours", BatteryLeft, MaxBattery);
        }

        public override bool Equals(object i_Obj)
        {
            return i_Obj is ElectricEngine engine &&
                   MaxBattery == engine.MaxBattery;
        }

        public override int GetHashCode()
        {
            return -250832942 + MaxBattery.GetHashCode();
        }

        public static bool operator ==(ElectricEngine i_Left, ElectricEngine i_Right)
        {
            return i_Left.Equals(i_Right);
        }

        public static bool operator !=(ElectricEngine i_Left, ElectricEngine i_Right)
        {
            return !i_Left.Equals(i_Right);
        }
    }
}
