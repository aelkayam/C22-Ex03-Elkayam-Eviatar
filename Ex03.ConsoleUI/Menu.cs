using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal struct Menu
    {
        private const string k_MenuMsg = @"Please select the option: 
1   - To enter a new car in the garage. 
2   - To view all the License Plates in the garage.
3   - To update your vehicle state.
4   - To filling air in your vehicle wheels.
5   - To fill gas in your vehicle.
6   - To charge the battery of your vehicle.
7   - To view the details of your vehicle in the garage.
0   - To Exit.
";

        private const string k_FormtForMsg = @"{0} 
{1}";

        private readonly Screen r_Screen;
        private readonly UserInput r_UserInput;

        public Menu(Screen i_Screen, UserInput i_UserInput)
        {
            Console.WriteLine("in Menu const");

            r_Screen = i_Screen;
            r_UserInput = i_UserInput;
        }

        public eMenuOptions MenuOptionsOperation()
        {
            eMenuOptions o_Result;
            Console.ForegroundColor = ConsoleColor.Yellow;

            bool isValidChoice;
            do
            {
                r_Screen.ShowMenu(k_MenuMsg);
                isValidChoice = GetMenuOptions(out o_Result);
                if (!isValidChoice)
                {
                    r_Screen.ShowMessage("invalid input, try again!");
                }
            }
            while (!isValidChoice);
            Console.ForegroundColor = ConsoleColor.White;

            return o_Result;
        }

        private bool GetMenuOptions(out eMenuOptions o_Results)
        {
            bool isValid = false;
            try
            {
                o_Results = enumPrompt<eMenuOptions>();
                isValid = true;
            }
            catch
            {
                o_Results = default;
                Console.WriteLine("catch getMEnuOptions");
            }

            return isValid;
        }

        public static string CreateOptionsFromEnum(Type i_EnumType)
        {
            StringBuilder sb = new StringBuilder();

            string[] names = Enum.GetNames(i_EnumType);
            int[] values = (int[])Enum.GetValues(i_EnumType);

            for (int i = 0; i < names.Length; i++)
            {
                sb.AppendLine(string.Format("{0}  -  {1}", names[i], values[i].ToString()));
            }

            return sb.ToString();
        }

        private TEnum enumPrompt<TEnum>()
            where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), r_UserInput.ReadInput(), true);
        }

        public TEnum GetEnumPrompt<TEnum>(string i_QForPrint)
                        where TEnum : Enum
        {
            string strToPrint = string.Format(k_FormtForMsg, i_QForPrint, CreateOptionsFromEnum(typeof(TEnum)));

            TEnum result = default;
            bool isValid = false;
            do
            {
                try
                {
                    r_Screen.ShowMessage(strToPrint);
                    result = enumPrompt<TEnum>();
                    isValid = true;
                }
                catch(Exception e)
                {
                    r_Screen.ShowError(eErrorType.FormatError);
                }
            }
            while (!isValid);

            return (TEnum)result;
        }
    }
}
