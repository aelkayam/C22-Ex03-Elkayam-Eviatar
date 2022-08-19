using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class UserInput
    {
        public static readonly List<string> rm_TrueFalseAns = new List<string>() { "TRUE", "YES", "Y", "false", "NO", "N" };
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

        internal string GetInput()
        {
            bool ans = false;
            ReadInput();

            return ans;

        }

        internal string ReadInput()
        {
            return Console.ReadLine().Trim();
        }

        internal string GetInputFormArray(List<string> i_StrArrValues ,params string[] i_AnotherMessage)
        {
            bool isUserchooseFormArray = false;
            string result = string.Empty;

            do
            {
                result = readInput().Trim();
                isUserchooseFormArray = i_StrArrValues.Contains(result);
            }
            while (!isUserchooseFormArray);

            return result;
        }

        internal bool GetBool(string i_Msg)
        {
            bool isAns = true; //trst time not do it 
            bool resletBool = false; 
            string result;

            do
            {
                if (!isAns)
                {
                    Console.WriteLine("try again");
                    Console.WriteLine(i_Msg);
                }

                result = readInput();
                isAns = rm_TrueFalseAns.Contains(result);
            }
            while (isAns);
            
            int i = 0;
            foreach(string s in rm_TrueFalseAns)
            {
                if (s == result)
                {
                    resletBool = true;
                }

                if(i <= rm_TrueFalseAns.Count / 2 )
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
            bool isAns = true; //trst time not do it 

            do
            {
                if (!isAns)
                {
                    Console.WriteLine("try again");
                    Console.WriteLine(i_Msg);
                }

                string result = readInput();
                isAns = Int32.TryParse(result, out ans);
            }
            while (isAns);

            return ans;
        }
    }
}
