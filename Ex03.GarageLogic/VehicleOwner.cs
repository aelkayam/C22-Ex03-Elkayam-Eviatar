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

        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        private string m_OwnerTel;

        public string OwnerTel
        {
            get { return m_OwnerTel; }
        }

        private string m_LicensePlate;

        public string LicensePlate
        {
            get { return m_LicensePlate; }
        }

        private Vehicle m_Vehicle;

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        public eCarState CarState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }

        private eCarState m_VehicleState;

        public VehicleOwner(string i_OwnerName, string i_OwnerTel, string i_LicensePlate, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerTel = i_OwnerTel;
            m_LicensePlate = i_LicensePlate;
            m_VehicleState = eCarState.InRepair;
            m_Vehicle = i_Vehicle;
        }



    }
}
