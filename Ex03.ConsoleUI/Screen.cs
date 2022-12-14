using System;

namespace Ex03.ConsoleUI
{
    internal struct Screen
    {
        public const string k_FiltersMsg = "Choose vehicle state:";

        public const string k_GetGasTypeMsg = "Please enter what type of gas to fill";
        private const string k_FormatMsg = "Parsing failure, invalid input was typed.";
        private const string k_ArgumentMsg = "Wrong argument was typed.";
        private const string k_ValueOutOfRangeMsg = "Value out of range was typed.";

        private const string k_GetLicensePlateMsg = "Please enter your license plate number:";
        public const string k_GetBatteryMsg = "Please enter how many hours you want to charge into the battery:";
        public const string k_GetGasMsg = "Please enter how much gas you want to fill:";

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
        private const string k_ActionSucces = "Successfully done!";
        private const string k_ActionSuccessArgs = "'{0}' successfully!";
        private const string k_UpdateSuccess = "Updated your vehicle to {0} successfully!";
        private const string k_GasSuccess = "Filled {0}L to your fuel tank successfully!";
        private const string k_BatterySuccess = "charged {0} hours to your vehicle battery successfully!";
        private const string k_AirFillSuccess = "Maximum air pressure in all your wheels!";
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

        private void print(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal void ShowMenu(string i_StrMenu)
        {
            Console.Clear();
            print(i_StrMenu);
        }

        internal void Confirmation()
        {
            print(k_ActionSucces);
        }

        internal void Confirmation(string i_Args)
        {
            print(string.Format(k_ActionSuccessArgs, i_Args));
        }

        internal void ConfirmUpdate(string i_Args)
        {
            print(string.Format(k_UpdateSuccess, i_Args));
        }

        internal void ConfirmGas(string i_Args)
        {
            print(string.Format(k_GasSuccess, i_Args));
        }

        internal void ConfirmBattery(string i_Args)
        {
            print(string.Format(k_BatterySuccess, i_Args));
        }

        internal void ConfirmAirPressure()
        {
            print(k_AirFillSuccess);
        }

        internal void Failure()
        {
            print(k_ActionFailure);
        }
    }
}
