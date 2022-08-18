using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const string k_modle = "Truck-Modle"; 
        private const float k_EnergyLeft = 20f ;

        private readonly bool r_IsRefrigerator;
        private readonly float r_MaxCapacity;

        private readonly static Truck sr_Model;
        /*
         *  public Truck(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, eCarState i_CarState, object i_Engine, bool i_isRefrigerator, int i_MaxCapacity)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_CarState, i_Engine)
         */
        static Truck()
        {
            // object i_Engine, bool i_isRefrigerator, int i_MaxCapacity)
            //: base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_CarState, i_Engine)
            List<Wheel> modelWheels = new List<Wheel>() ;

            for(int i = 0; i < GarageManager.k_TruckNumOfWhell; i++)
            {
                modelWheels.Add(new Wheel()); // is it mast ?? 
            }

            GasEngine gasEngine = new GasEngine();
            sr_Model = new Truck(k_modle, k_modle, k_EnergyLeft, modelWheels, gasEngine, GarageManager.v_TruckRefrigerated, GarageManager.k_TruckFuelTankContents);
        }

        public static Truck CloneModel()
        {
            return sr_Model.Clone();
        }

        public Truck Clone()
        {
            return new Truck(Name, LicencePlate, EnergyLeft, Wheels, Engine, IsRefrigerator,  MaxCapacity );
        }

        /******** Properties ************/
        public bool IsRefrigerator
        {
            get { return r_IsRefrigerator; }
        }

        public float MaxCapacity
        {
            get { return r_MaxCapacity; }
        }

        public Object GasEngine { get; }

        /******** Constructor ************/
        public Truck(string i_Name, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels, object i_Engine, bool i_isRefrigerator, float i_MaxCapacity)
            : base(i_Name, i_LicensePlate, i_EnergyLeft, i_Wheels, i_Engine)
        {
            r_IsRefrigerator = i_isRefrigerator;
            r_MaxCapacity = i_MaxCapacity;
        }

        /******** Methods ************/
        public override string ToString()
        {
            return string.Format(@"{0}Has refrigerator: {1} Capacity: {2}L", base.ToString(), IsRefrigerator, MaxCapacity);
        }

        public override bool Equals(object obj)
        {
            bool results = false;
            Truck otherVehicle = obj as Truck;
            if (otherVehicle != null)
            {
                results = this == otherVehicle;
            }

            return results;
        }

        public static bool operator ==(Truck i_vehicle1, Truck i_vehicle2)
        {
            bool asTHeSemLIcane = ((Vehicle)i_vehicle1) == ((Vehicle)i_vehicle2);


            if(i_vehicle1.Wheels == i_vehicle2.Wheels) && ()
            return i_vehicle1.LicencePlate == i_vehicle2.LicencePlate;
        }

        public static bool operator !=(Vehicle i_vehicle1, Vehicle i_vehicle2)
        {
            return i_vehicle1 != i_vehicle2;
        }

        public override int GetHashCode()
        {
            return LicencePlate.GetHashCode();
        }
    }
}
