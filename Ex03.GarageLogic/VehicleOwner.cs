using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // TODO : Make it a wrapper class for in the dictionary
    // TODO : Bring here in the condition of the vehicle and take it out of the vehicle
    internal struct VehicleOwner
    {
        private string m_OwnerName;
        private int m_OwnerTel;
        private string m_LicensePlate;

        public VehicleOwner(string i_OwnerName, int i_OwnerTel, string i_LicensePlate)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerTel = i_OwnerTel;
            m_LicensePlate = i_LicensePlate;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        public int OwnerTel
        {
            get { return m_OwnerTel; }
        }

        public string LicensePlate
        {
            get { return m_LicensePlate; }
        }
    }
}
