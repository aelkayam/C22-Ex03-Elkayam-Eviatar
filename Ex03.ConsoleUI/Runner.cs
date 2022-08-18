using System;
using System.Collections.Generic;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Runner
    {
        private bool m_IsRunning;
        private Screen m_Screen;
        private UserInput m_UserInput;
        private GarageManager m_GarageManager;

        /******** Properties ************/
        public bool IsRunning
        {
            get { return m_IsRunning; }
            set { m_IsRunning = value; }
        }

        public Screen Screen
        {
            get { return m_Screen; }
        }

        public UserInput UI
        {
            get { return m_UserInput; }
        }

        public GarageManager Garage
        {
            get { return m_GarageManager; }
            set { m_GarageManager = value; }
        }

        /******** Constructor ************/
        public Runner()
        {
            IsRunning = false;
            m_Screen = new Screen();
            m_UserInput = new UserInput();
            List<string> employees = new List<string>() { "Shimon", "Asaf-Plutz", "KMNO" };

            m_GarageManager = new GarageManager("Abba Shimon and Sons' garage", employees);
        }

        /******** Methods ************/
        public void Start()
        {
            this.IsRunning = true;
            run();
        }

        private void run()
        {
            Screen.ShowMessage(string.Format("Welcome to {0} garage", Garage.Name));
            while (IsRunning)
            {
                try
                {
                    eMenuOptions eMenu = menuOptionsOperation();

                    Screen.GetLicensePlateFromUser();
                    string userLicensePlate = UI.LicensePlatePrompt();

                    float energyToFill;
                    eGasType gasTypeToFill;
                    eCarState carStateTarget;

                    // TODO: each case will have ONLY FUCTION CALLS!!!
                    switch (eMenu)
                    {
                        case eMenuOptions.InsertCar:
                            Garage.InsertNewVehicle(userLicensePlate);

                            // TODO: make getUserInput function
                            break;

                        case eMenuOptions.AllLicensePlates:
                            Screen.ShowMessage(Garage.GetDetailsAboutAllVehicles());

                            // TODO: filter by car state
                            break;

                        case eMenuOptions.UpdateVehicle:
                            Screen.GetVehicleStateFromUser();
                            carStateTarget = UI.CarStatePrompt();
                            Garage.updateCarState(userLicensePlate, carStateTarget);

                            // TODO: filter by car state
                            break;

                        case eMenuOptions.FillAirInWheels:
                            Garage.FillAir(userLicensePlate); // fill to the max!
                            break;

                        case eMenuOptions.FillGas:
                            Screen.GetGasFromUser();
                            energyToFill = UI.EnergyToFillPrompt();
                            Screen.GetGasTypeFromUSer();
                            gasTypeToFill = UI.GasTypePrompt();
                            Garage.FillGas(userLicensePlate, energyToFill, gasTypeToFill);
                            break;

                        case eMenuOptions.ChargeBattery:
                            Screen.GetBatteryFromUser();
                            energyToFill = UI.EnergyToFillPrompt();
                            Garage.FillBattery(userLicensePlate, energyToFill);
                            break;

                        case eMenuOptions.ShowDetails:
                            Screen.ShowMessage(Garage.GetDetailsAboutVehicle(userLicensePlate));
                            break;

                        case eMenuOptions.Exit:
                            stopProgram();
                            break;

                        default:
                            Console.WriteLine("default");
                            break;
                    }
                }

                // TODO: check the order (~what order?)
                catch (FormatException fe)
                {
                    Screen.ShowError(eErrorType.FormatError);
                }
                catch (ArgumentException ae)
                {
                    Screen.ShowError(eErrorType.ArgumentError);
                }
                catch (ValueOutOfRangeException voore)
                {
                    Screen.ShowError(eErrorType.ValueOutOfRangeError);
                }
                catch (Exception e)
                {
                    Screen.ShowMessage(e.Message);
                }
            } // END OF WHILE

            exitProgram();
        }

        private void stopProgram()
        {
            Screen.ShowMessage("Exiting...");
            Thread.Sleep(1000);
            m_IsRunning = false;
        }

        private void exitProgram()
        {
            Screen.ShowMessage("Goodbye! press enter to exit the garage :D");
            UI.ReadInput();
        }

        private eMenuOptions menuOptionsOperation()
        {
            eMenuOptions o_Result;

            bool isValidChoice;
            do
            {
                m_Screen.ShowMenu();
                isValidChoice = UI.GetMenuOptions(out o_Result);
                if (!isValidChoice)
                {
                    Screen.ShowMessage("invalid input, try again!");
                }
            }
            while (!isValidChoice);

            return o_Result;
        }
    }
}
