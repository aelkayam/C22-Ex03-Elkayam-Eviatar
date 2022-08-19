﻿using System;

namespace Ex03.ConsoleUI
{
    internal class Screen
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

        private const string k_FiltersMsg = @"Filter by vehicle state:
1  - InRepair
2  - Repaired
3  - Paid
";

        private const string k_FormatMsg = "Parsing failure, invalid input was typed.";
        private const string k_ArgumentMsg = "Wrong argument was typed.";
        private const string k_ValueOutOfRangeMsg = "Value out of range was typed.";

        private const string k_GetLicensePlateMsg = "Please enter your license plate number:";
        private const string k_GetBatteryMsg = "Please enter how many hours you want to charge into the battery:";
        private const string k_GetGasMsg = "Please enter how much gas you want to fill:";
        private const string k_GetGasTypeMsg = @"Please enter what type of gas to fill 
(1 - Soler / 95 - Octan95 / 96 - Octan96 / 98 - Octan98):";

        private const string k_GetVehicleStateMsg = "Please enter the new state (Repaired/Paid):";
        private const string k_ActionSucces = "Successfully done!";
        private const string k_ActionFailure = "Action denied.";

        /******** Methods ************/
        public void ShowMessage(string i_MessageToShow)
        {
            print(i_MessageToShow);
        }

        public void ShowError(eErrorType i_ErrorType)
        {
            switch (i_ErrorType)
            {
                case eErrorType.FormatError:
                    print(k_FormatMsg);
                    break;
                case eErrorType.ArgumentError:
                    print(k_ArgumentMsg);
                    break;
                case eErrorType.ValueOutOfRangeError:
                    print(k_ValueOutOfRangeMsg);
                    break;
            }
        }

        public void GetLicensePlateFromUser()
        {
            print(k_GetLicensePlateMsg);
        }

        public void GetBatteryFromUser()
        {
            print(k_GetBatteryMsg);
        }

        public void GetGasFromUser()
        {
            print(k_GetGasMsg);
        }

        internal void GetGasTypeFromUSer()
        {
            print(k_GetGasTypeMsg);
        }

        internal void GetVehicleStateFromUser()
        {
            print(k_GetVehicleStateMsg);
        }

        private void print(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal void ShowMenu()
        {
            print(k_MenuMsg);
        }

        internal void ShowFilters()
        {
            print(k_FiltersMsg);
        }

        internal void Confirmation()
        {
            print(k_ActionSucces);
        }

        internal void Failure()
        {
            print(k_ActionFailure);
        }
    }
}
