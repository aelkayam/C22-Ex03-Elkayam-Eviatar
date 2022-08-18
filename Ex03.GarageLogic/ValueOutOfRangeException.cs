using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public readonly float m_MaxValue;
        public readonly float m_MinValue;


        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue):base()
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_msg) : base(i_msg)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_msg, Exception innerException) : base(i_msg,  innerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
        
    }
}
