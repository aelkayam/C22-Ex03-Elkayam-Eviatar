using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private const string k_LicensePlate = "Demo-Motorbike";
        private const float k_noFoile = 0f;
        private const eLicence k_eLicence = eLicence.A;
        private const int k_EngineCapacity = 1000; 

        private static readonly Motorbike sr_Model ;

        static Motorbike()
        {
            string modelName = k_LicensePlate;
            string modelLicensePlate = k_LicensePlate;
            float modelEnergyLeft = k_noFoile;
            Wheel modelWheel = new Wheel(GarageManager.k_MotorbikeMaxAirPressure);
            List<Wheel> modelWheels = new List<Wheel>(2) { modelWheel, modelWheel };
            GasEngine gasEngine = new GasEngine();
            sr_Model = new Motorbike(modelName, modelLicensePlate, modelEnergyLeft, modelWheels, gasEngine
               , k_eLicence,  k_EngineCapacity);
        }

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

        public static Motorbike CloneModel()
        {
            return (Motorbike)sr_Model.MemberwiseClone();
        }

        //public static Motorbike Clone(Motorbike i_j)
        //{
        //    return new Motorbike();
        //}

        public Motorbike clone()
        {
            return new Motorbike(this.Name, this.LicencePlate, this.EnergyLeft, this.Wheels
               ,this.Engine, this.r_License, this.EngineCapacity);
        }

        public Motorbike(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels,
            object i_Engine, eLicence i_License, int i_EngineCapacity) 
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_Engine)
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