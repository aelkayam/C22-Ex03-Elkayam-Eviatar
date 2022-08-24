using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInput
    {
        internal string ReadInput()
        {
            return Console.ReadLine().Trim();
        }

        // TODO eviatar: Create a class that accepts an enum
        // and eulogizes the possible options
        //internal bool GetMenuOptions(out eMenuOptions o_Results)
        //{
        //    bool isValid = false;
        //    try
        //    {
        //        o_Results = EnumPrompt<eMenuOptions>();
        //        isValid = true;
        //    }
        //    catch
        //    {
        //        o_Results = default;
        //        Console.WriteLine("catch getMEnuOptions");
        //    }

        //    return isValid;
        //}

        //internal eGasType GasTypePrompt()
        //{
        //    if(Enum.TryParse<eGasType>(ReadInput(), true, out eGasType o_GasType))
        //    {
        //        return o_GasType;
        //    }
        //    else
        //    {
        //        throw new FormatException();
        //    }
        //}

        //internal eCarState CarStatePrompt()
        //{
        //    if(Enum.TryParse<eCarState>(ReadInput(), true, out eCarState o_CarState))
        //    {
        //        return o_CarState;
        //    }
        //    else
        //    {
        //        throw new FormatException();
        //    }
        //}

        //internal TEnum EnumPrompt<TEnum>()
        //    where TEnum : Enum
        //{
        //    return (TEnum)Enum.Parse(typeof(TEnum), ReadInput(), true);
        //}

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
            if(float.TryParse(ReadInput(), out float value))
            {
                return value;
            }
            else
            {
                throw new FormatException();
            }
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
    }
}
