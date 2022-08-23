using System;
using System.Collections.Generic;
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

        internal string GetString()
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

        internal string ReadInput()
        {
            return Console.ReadLine().Trim();
        }

        internal string GetInputFormArray(List<string> i_StrArrValues, params string[] i_AnotherMessage)
        {
            bool isUserchooseFormArray = false;
            string result = string.Empty;

            do
            {
                result = ReadInput().Trim().ToLower();
                isUserchooseFormArray = i_StrArrValues.Contains(result);
            }
            while (!isUserchooseFormArray);

            return result;
        }



        internal int GetInt(string i_Msg)
        {
            if (int.TryParse(ReadInput(), out int o_reslt))
            {
                return o_reslt;
            }
            else
            {
                throw new FormatException();
            }

        }
    }
}
