﻿using System;

namespace Ex03.ConsoleUI
{
    internal class Screen
    {
        public const string k_FiltersMsg = "Choose filter by vehicle state:";

        public const string k_GetGasTypeMsg = "Please enter what type of gas to fill";
        private const string k_FormatMsg = "Parsing failure, invalid input was typed.";
        private const string k_ArgumentMsg = "Wrong argument was typed.";
        private const string k_ValueOutOfRangeMsg = "Value out of range was typed.";

        private const string k_GetLicensePlateMsg = "Please enter your license plate number:";
        public const string k_GetBatteryMsg = "Please enter how many hours you want to charge into the battery:";
        public const string k_GetGasMsg = "Please enter how much gas you want to fill:";

        private const string k_GetVehicleStateMsg = "Please enter the new state (Repaired/Paid):";
        private const string k_ActionSucces = "Successfully done!";
        private const string k_ActionFailure = "Action denied.";
        public const string k_AskForCarType = @"Please enter the type of vehicle you want to enter the garage";
        public const string k_AskMaxBattery = "What is the max battery?";
        public const string k_AskVehicleManufacturer = "What is the vehicle manufacturer?";
        public const string k_AskIsElectric = "is the Vehicle Electric? (yes / no)";
        public const string k_AskMaxFuel = "What is the max capacity of the fuel tank?";
        public const string k_AskHowManyWheels = "How many wheels the vehicle has?";
        public const string k_AskMaxAirPressure = "What is the max pressure of the wheels?";
        public const string k_AskCurrentAirPressure = "What is the current pressure of the wheels?";
        public const string k_AskWheelManufacturer = "What is the wheels' manufacturer";
        public const string k_AskOwnerName = "What is the owner's name?";
        public const string k_AskOwnerTelNumber = "What is the owner's phone number?";

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

        //public void GetBatteryFromUser()
        //{
        //    print(k_GetBatteryMsg);
        //}

        //public void GetGasFromUser()
        //{
        //    print(k_GetGasMsg);
        //}

        //internal void GetGasTypeFromUSer()
        //{
        //    print(k_GetGasTypeMsg);
        //}

        //internal void GetVehicleStateFromUser()
        //{
        //    print(k_GetVehicleStateMsg);
        //}

        private void print(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal void ShowMenu(string i_StrMenu)
        {
            Console.Clear();
            print(i_StrMenu);
        }

        //internal void ShowFilters()
        //{
        //    print(k_FiltersMsg);
        //}

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
