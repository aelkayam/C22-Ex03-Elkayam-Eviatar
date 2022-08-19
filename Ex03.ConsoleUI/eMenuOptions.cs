using System;

namespace Ex03.ConsoleUI
{
    internal enum eMenuOptions
    {
        InsertVehicle = 1,
        AllLicensePlates = 2, // (filter by eCarState))license plates
        UpdateVehicle = 3,
        FillAirInWheels = 4,
        FillGas = 5,
        ChargeBattery = 6,
        ShowDetails = 7,
        Exit = 0,
    }
}
