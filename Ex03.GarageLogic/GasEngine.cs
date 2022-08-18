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
        public override string ToString()
        {
            return string.Format(@"Gas type: {0}    Left: {1}L  Max: {2}L", GasType, GasLeft, MaxGas);
        }
    }
}
