using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInput
    {
        public string UserName { get; set; }

        internal bool GetMenuOptions(out eMenuOptions o_Result)
        {
            return Enum.TryParse<eMenuOptions>(ReadInput(), out o_Result);
        }

        internal string LicensePlatePrompt()
        {
            // no restrictions :D
            return ReadInput();
        }

        internal float EnergyToFillPrompt()
        {
            if(float.TryParse(ReadInput(), out float value))
            {
                return value;
            }
            else
            {
                throw new FormatException();
            }
        }

        internal eGasType GasTypePrompt()
        {
            if(Enum.TryParse<eGasType>(ReadInput(), out eGasType o_GasType))
            {
                return o_GasType;
            }
            else
            {
                throw new FormatException();
            }
        }

        internal eCarState CarStatePrompt()
        {
            if(Enum.TryParse<eCarState>(ReadInput(), out eCarState o_CarState))
            {
                return o_CarState;
            }
            else
            {
                throw new FormatException();
            }
        }

        internal bool GetInput(Type type)
        {
            bool ans = false;
            ReadInput();

            return ans;
        }

        internal string ReadInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}
