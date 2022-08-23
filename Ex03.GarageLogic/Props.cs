using System;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class Props
    {
        // TODO : Use this class instead of strings
        // TODO : Create this class as generic

        private ParameterInfo m_Pi;

        // replace this >>
        private readonly Type r_Type;

        private readonly string r_Msg;

        public Props(string i_msg, Type i_Type)
        {
            this.r_Type = i_Type;
            this.r_Msg = i_msg;
        }

        public Type Type
        {
            get { return r_Type; }
        }

        public string Message
        {
            get { return r_Msg; }
        }
    }
}
