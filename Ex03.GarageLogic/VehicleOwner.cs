using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal struct VehicleOwner
    {
        // TODO: continue building VehicleOwner
        private string m_OwnerName;
        private int m_OwnerTel;
        private string m_LicensePlate;

        public string OwnerName { get { return m_OwnerName; } }

        public int OwnerTel { get { return m_OwnerTel; } }

        public string LicensePlate { get { return m_LicensePlate; } }

    }
}
