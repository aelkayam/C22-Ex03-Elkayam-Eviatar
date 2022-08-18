using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class UserInput
    {
        public static readonly List<string> rm_TrueFalseAns = new List<string>() { "TRUE", "YES", "Y", "false", "NO", "N" };
        public string UserName { get; set; }

        internal bool GetMenuOptions(out eMenuOptions o_result)
        {
            return Enum.TryParse<eMenuOptions>(readInput(), out o_result);
        }

        internal string GetInput()
        {
            return readInput();
        }

        private string readInput()
        {
            return Console.ReadLine();
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
