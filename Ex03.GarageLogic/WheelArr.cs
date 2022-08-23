using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class WheelArr
    {
        // TODO :  Move the wheel class to be a nested class
        private Wheel[] m_Wheels;

        public WheelArr(int i_NumOfWheel, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.m_Wheels = new Wheel[i_NumOfWheel];
            for (int j = 0; j < i_NumOfWheel; j++)
            {
                this[j] = new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            }
        }

        public WheelArr(int i_NumOfWheel)
        {
            this.m_Wheels = new Wheel[i_NumOfWheel];
        }

        public int Count
        {
            get { return m_Wheels.Length; }
        }

        public Wheel this[int i]
        {
            get { return m_Wheels[i]; }
            set { m_Wheels[i] = value; }
        }

        public void FillAir()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.FillAir();
            }
        }

        public void FillAir(float i_AirPressureToAdd)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.FillAir(i_AirPressureToAdd);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("wheels:");
            foreach (Wheel w in m_Wheels)
            {
                sb.AppendFormat(w.ToString());
            }

            return sb.ToString();
        }
        public override bool Equals(object i_Obj)
        {
            WheelArr wheels = i_Obj as WheelArr;

            bool ans = true;
            if ((object)wheels == null)
            {
                ans = false;
            }
            else
            {
                for (int i = 0; i < m_Wheels.Length; i++)
                {
                    if (!this[i].Equals(wheels.m_Wheels[i]))
                    {
                        ans = false;
                        break;
                    }
                }
            }

            return ans;
        }

        public static bool operator ==(WheelArr i_Left, WheelArr i_Right)
        {
            return i_Left.Equals(i_Right);
        }

        public static bool operator !=(WheelArr i_Left, WheelArr i_Right)
        {
            return !i_Left.Equals(i_Right);
        }


    }
}
