using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        // private const eLicence eLicence = new eLicence(""); ??
        private readonly eLicence r_License;
        private readonly int r_EngineCapacity;

        /******** Properties ************/
        public eLicence Licence
        {
            get { return r_License; }
        }

        public int EngineCapacity
        {
            get { return r_EngineCapacity; }
        }

        /******** Constructor ************/
        public Motorbike(object i_Engine)
        {
            //switch (i_Engine)
            //{
            //    case GasEngine engine:
            //        break;
            //    case ElectricEngine engine:
            //        break;
            //        default: throw new ArgumentException();
            //}

           // check engine type
            if (i_Engine is GasEngine)
            {
            }
            else if (i_Engine is ElectricEngine)
            {
            }
            else
            {
                throw new FormatException("NOT AN ENGINE!");
            }
        }

        public Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, eCarState i_CarState, object i_Engine, eLicence i_License, int i_EngineCapacity)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_CarState, i_Engine)
        {
            r_License = i_License;
            r_EngineCapacity = i_EngineCapacity;
        }

        /******** Methods ************/
        public override string ToString()
        {
            return string.Format(@"{0}License type: {1} Engine Capacity: {2}", base.ToString(), Licence, EngineCapacity);
        }
    }
}