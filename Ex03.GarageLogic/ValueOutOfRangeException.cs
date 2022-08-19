using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public override string Message
        {
            get { return string.Format("Value must be between {0} - {1}", r_MinValue, r_MaxValue); }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base()
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_msg)
            : base(i_msg)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_msg, Exception innerException)
            : base(i_msg, innerException)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }
    }
}
