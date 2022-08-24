using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct VehicleOwner
    {
        private string m_OwnerName;
        private string m_OwnerTel;
        private string m_LicensePlate;
        private Vehicle m_Vehicle;
        private eCarState m_VehicleState;

        public VehicleOwner(string i_OwnerName, string i_OwnerTel, string i_LicensePlate, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerTel = i_OwnerTel;
            m_LicensePlate = i_LicensePlate;
            m_VehicleState = eCarState.InRepair;
            m_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        public string OwnerTel
        {
            get { return m_OwnerTel; }
        }

        public string LicensePlate
        {
            get { return m_LicensePlate; }
        }

        public eCarState CarState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }
    }
}
