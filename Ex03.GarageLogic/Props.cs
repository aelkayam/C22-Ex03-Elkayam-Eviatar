using System;

namespace Ex03.GarageLogic
{
    public class Props
    {
        private readonly Type r_type;
        private readonly string r_msg;

        public Props(string i_msg, Type type)
        {
            this.r_type = type;
            this.r_msg = i_msg;
        }

        public Type Type
        {
            get { return r_type; }
        }

        public string Message
        {
            get { return r_msg; }
        }
    }
}
