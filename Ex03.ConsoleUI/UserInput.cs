using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInput
    {
        private static readonly List<string> sr_TrueFalseAns = new List<string>() { "true", "yes", "y", "false", "no", "n" };

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
                result = ReadInput().Trim();
                isUserchooseFormArray = i_StrArrValues.Contains(result);
            }
            while (!isUserchooseFormArray);

            return result;
        }

        internal bool GetBool(string i_Msg)
        {
            bool isAns = true; // first time not do it
            bool resletBool = false;
            string result;

            do
            {
                if (!isAns)
                {
                    Console.WriteLine("try again");
                    Console.WriteLine(i_Msg);
                }

                result = ReadInput().ToLower();
                isAns = sr_TrueFalseAns.Contains(result);
            }
            while (!isAns);

            int i = 0;
            foreach(string s in sr_TrueFalseAns)
            {
                if (s == result)
                {
                    resletBool = true;
                }

                if(i <= sr_TrueFalseAns.Count / 2 )
                {
                    break;
                }

                i++;
            }

            return resletBool;
        }

        internal int GetInt(string i_Msg)
        {
            int ans;
            bool isAns = true; // first time not do it 

            do
            {
                if (!isAns)
                {
                    Console.WriteLine("try again");
                    Console.WriteLine(i_Msg);
                }

                string result = ReadInput();
                isAns = int.TryParse(result, out ans);
            }
            while (isAns);

            return ans;
        }
    }
}
