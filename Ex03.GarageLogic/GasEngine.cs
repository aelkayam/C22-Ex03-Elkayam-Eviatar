using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal struct GasEngine
    {
        private eGasType m_GasType;
        private float m_GasLeft;
        private float m_MaxGas;

        /******** Properties ************/
        public eGasType GasType
        {
            get { return m_GasType; }
            set { m_GasType = value; }
        }

        public float GasLeft
        {
            get { return m_GasLeft; }
            set { m_GasLeft = value; }
        }

        public float MaxGas
        {
            get { return m_MaxGas; }
            set { m_MaxGas = value; }
        }

        /******** Constructor ************/
        public GasEngine(eGasType i_GasType, float i_GasLeft, float i_MaxGas)
        {
            m_GasType = i_GasType;
            m_GasLeft = i_GasLeft;
            m_MaxGas = i_MaxGas;
        }

        /******** Methods ************/

        // fill tank to the max
        public void FillTank()
        {
            GasLeft = MaxGas;
        }

        // fill tank by given amount (liters)
        public void FillTank(float i_GasToFill, eGasType i_GasTypeToFill)
        {
            if(i_GasTypeToFill == GasType)
            {
                if(GasLeft + i_GasToFill <= MaxGas)
                {
                    GasLeft += i_GasToFill;
                }
                else
                {
                    throw new ValueOutOfRangeException(MaxGas - GasLeft, 0);
                }
            }
            else
            {
                throw new ArgumentException("Wrong type of Gas");
            }
        }
        public override string ToString()
        {
            return string.Format(@"Gas type: {0}    Left: {1}L      Max: {2}L", GasType, GasLeft, MaxGas);
        }

        internal static List<string> getPramsForNew()
        {
            List<string> prams = new List<string>();

            prams.Add("GasType: Soler = 1, Octan95 = 95,Octan96 = 96, Octan98 = 97, ");
            prams.Add("Gas Left");
            prams.Add("Max Gas");

            return prams;
        }

        public override bool Equals(object obj)
        {
            return obj is GasEngine engine &&
                   GasType == engine.GasType &&
                   MaxGas == engine.MaxGas;
        }

        public override int GetHashCode()
        {
            int hashCode = 1948794520;
            hashCode = (hashCode * -1521134295) + GasType.GetHashCode();
            hashCode = (hashCode * -1521134295) + MaxGas.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(GasEngine i_gasEngine1, GasEngine i_GasEngine2)
        {
            return i_gasEngine1.Equals(i_GasEngine2);
        }

        public static bool operator !=(GasEngine i_gasEngine1, GasEngine i_GasEngine2)
        {
            return !i_gasEngine1.Equals(i_GasEngine2);
        }
    }
}
