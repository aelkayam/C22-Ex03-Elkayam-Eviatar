﻿using System;
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

        //public Motorbike(object i_Engine)
        //{
        //    //switch (i_Engine)
        //    //{
        //    //    case GasEngine engine:
        //    //        break;
        //    //    case ElectricEngine engine:
        //    //        break;
        //    //        default: throw new ArgumentException();
        //    //}

        //   // check engine type
        //    if (i_Engine is GasEngine)
        //    {

        //    }
        //    else if (i_Engine is ElectricEngine)
        //    {
        //    }
        //    else
        //    {
        //        throw new FormatException("NOT AN ENGINE!");
        //    }
        //}

        /******** Constructor ************/
        public Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, eCarState i_CarState, object i_Engine, eLicence i_License, int i_EngineCapacity)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_CarState, i_Engine)
        {
            r_License = i_License;
            r_EngineCapacity = i_EngineCapacity;
        }

        /******** Methods ************/

        // return electric motor model supported by the garage
        public static Motorbike MakeDefaultElectricMotorbike()
        {
            // wheels:
            List<Wheel> defaultElectricMotorbikeWheels = getDefaultMotorbikeWheels();

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, GarageManager.k_MotorbikeMaxBatteryTime);

            return new Motorbike("Manufacturer", "LicesePlate", 0, defaultElectricMotorbikeWheels, eCarState.InRepair, defaultElectricEngine, eLicence.A, 1000); // default engine capacity for bikes???
        }

        // return gas motorbike model supported by the garage
        public static Motorbike MakeDefaultGasMotorbike()
        {
            // wheels:
            List<Wheel> defaultGasMotorbikeWheels = getDefaultMotorbikeWheels();

            // engine:
            ElectricEngine defaultGasEngine = new ElectricEngine(0, GarageManager.k_MotorbikeFuelTankCapacity);

            return new Motorbike("Manufacturer", "LicesePlate", 0, defaultGasMotorbikeWheels, eCarState.InRepair, defaultGasEngine, eLicence.A, 1000); // default engine capacity for bikes???
        }

        // return list of default bike wheels
        private static List<Wheel> getDefaultMotorbikeWheels()
        {
            // wheels:
            List<Wheel> defaultElectricMotorbikeWheels = new List<Wheel>(GarageManager.k_MotorbikeNumOfWheels)
            {
                new Wheel("default", 0, GarageManager.k_MotorbikeMaxAirPressure),
                new Wheel("default", 0, GarageManager.k_MotorbikeMaxAirPressure),
            };

            return defaultElectricMotorbikeWheels;
        }

        public override string ToString()
        {
            return string.Format(@"{0}License type: {1} Engine Capacity: {2}", base.ToString(), Licence, EngineCapacity);
        }
    }
}