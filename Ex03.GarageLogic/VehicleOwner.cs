using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal struct VehicleOwner
    {
        private readonly string r_OwnerName;

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        private readonly string r_OwnerTel;

        public string OwnerTel
        {
            get { return r_OwnerTel; }
        }

        private readonly string r_LicensePlate;

        public string LicensePlate
        {
            get { return r_LicensePlate; }
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
            r_OwnerName = i_OwnerName;
            r_OwnerTel = i_OwnerTel;
            r_LicensePlate = i_LicensePlate;
            m_VehicleState = eCarState.InRepair;
            m_Vehicle = i_Vehicle;
        }
    }
}
