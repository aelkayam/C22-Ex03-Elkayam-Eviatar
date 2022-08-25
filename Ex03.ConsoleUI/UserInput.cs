using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal struct UserInput
    {
        internal string ReadInput()
        {
            return Console.ReadLine().Trim();
        }

        internal string LicensePlatePrompt()
        {
            return ReadInput();
        }

        internal string GetString()
        {
            return ReadInput();
        }

        internal float EnergyToFillPrompt()
        {
            if(float.TryParse(ReadInput(), out float o_Value))
            {
                return o_Value;
            }
            else
            {
                throw new FormatException();
            }
        }

        internal int GetInt()
        {
            if (int.TryParse(ReadInput(), out int o_Result))
            {
                return o_Result;
            }
            else
            {
                throw new FormatException();
            }
        }

        internal string GetInputFormArray(List<string> i_StrArrValues)
        {
            bool isUserchooseFormArray;
            string result;
            do
            {
                result = ReadInput().Trim().ToLower();
                isUserchooseFormArray = i_StrArrValues.Contains(result);
            }
            while (!isUserchooseFormArray);

            return result;
        }
    }
}
