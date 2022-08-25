using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private const string k_ColorsOptions = @"Colors:    Black - 1,  Blue - 2,  Gray - 3,  White - 4 ";
        private const string k_DoorsOptions = @"Number of doors:    Two-Doors - 2,  Three-Doors - 3, Four-Doors - 4, Five-Doors - 5";

        // default values:
        private const byte k_CarNumOfWheels = 4;
        private const byte k_CarMaxAirPressure = 27;
        private const float k_CarMaxBatteryTime = 4.5f;
        private const float k_CarFuelTankCapacity = 52f;
        private const eGasType k_CarGasType = eGasType.Octan95;

        private const eColor k_Color = eColor.Blue;
        private const eDoors k_Doors = eDoors.FourDoors;

        private readonly eDoors r_Doors;
        private eColor m_Color;

        /******** Properties ************/
        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eDoors Doors
        {
            get { return r_Doors; }
        }

        /******** Constructor ************/
        private Car(string i_Name, string i_LicensePlate, WheelArr i_Wheels, object i_Engine, eColor i_Color, eDoors i_Doors)
            : base(i_Name, i_LicensePlate, i_Wheels, i_Engine)
        {
            m_Color = i_Color;
            r_Doors = i_Doors;
        }

        // gas car
        public Car(string i_Name, string i_LicensePlate, WheelArr i_Wheels, GasEngine i_Engine, eColor i_Color, eDoors i_Doors)
            : this(i_Name, i_LicensePlate, i_Wheels, (object)i_Engine, i_Color, i_Doors)
        {
        }

        // electric car
        public Car(string i_Name, string i_LicensePlate, WheelArr i_Wheels, ElectricEngine i_Engine, eColor i_Color, eDoors i_Doors)
            : this(i_Name, i_LicensePlate, i_Wheels, (object)i_Engine, i_Color, i_Doors)
        {
        }

        /******** Methods ************/

        // return electric car model supported by the garage
        public static Car MakeDefaultElectricCar()
        {
            // wheels:
            WheelArr defaultElectricCarWheels = new WheelArr(k_CarNumOfWheels, "default", 0, k_CarMaxAirPressure);

            // engine:
            ElectricEngine defaultElectricEngine = new ElectricEngine(0, k_CarMaxBatteryTime);

            return new Car("Manufacturer", "LicensePlate", defaultElectricCarWheels, defaultElectricEngine, k_Color, k_Doors);
        }

        public static Car MakeDefaultGasCar()
        {
            // wheels:
            WheelArr defaultGasCarWheels = new WheelArr(k_CarNumOfWheels, "default", 0, k_CarMaxAirPressure);

            // engine
            GasEngine defaultGasEngine = new GasEngine(k_CarGasType, 0, k_CarFuelTankCapacity);

            return new Car("Manufacturer", "LicensePlate", defaultGasCarWheels, defaultGasEngine, k_Color, k_Doors);
        }

        public override string ToString()
        {
            return string.Format(@"{0}Color:{1}     Doors: {2}", base.ToString(), Color, Doors);
        }

        public override bool ArePropertiesEqual(Vehicle i_Other)
        {
            bool ans = false;
            bool isEqualType = i_Other is Car;

            if (isEqualType)
            {
                ans = base.ArePropertiesEqual(i_Other);
            }

            return ans;
        }

        internal static List<string> GetParmsForNew()
        {
            List<string> parms = new List<string>
            {
                k_ColorsOptions,
                k_DoorsOptions,
            };

            return parms;
        }
    }
}
