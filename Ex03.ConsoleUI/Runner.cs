using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Runner
    {
        // todo : move to ui 
        private const string k_AskForCarType = @"Please enter the type of vehicle you want to enter the garage";

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
                    string userLicensePlate = string.Empty;

                    if (eMenu != eMenuOptions.Exit && eMenu != eMenuOptions.AllLicensePlates && eMenu != eMenuOptions.InsertVehicle)
                    {
                        Screen.GetLicensePlateFromUser();
                        userLicensePlate = UI.LicensePlatePrompt();
                    }

                    switch (eMenu)
                    {
                        case eMenuOptions.InsertVehicle: // 1
                            insertNewVehicle();
                            // Garage.InsertNewVehicle(userLicensePlate);
                            // TODO: make enum for CAR, MOTORBIKE, TRUCK
                            // TODO: get parameters for: CAR, MOTORBIKE, TRUCK
                            // TODO: make getUserInput function
                            break;

                        case eMenuOptions.AllLicensePlates: // 2
                            showAllLicensePlates();
                            break;

                        case eMenuOptions.UpdateVehicle: // 3
                            updateVehicle(userLicensePlate);
                            break;

                        case eMenuOptions.FillAirInWheels: // 4
                            fillAirInWheels(userLicensePlate);
                            break;

                        case eMenuOptions.FillGas: // 5
                            fillGas(userLicensePlate);
                            break;

                        case eMenuOptions.ChargeBattery: // 6
                            chargeBattery(userLicensePlate);
                            break;

                        case eMenuOptions.ShowDetails: // 7
                            showDetails(userLicensePlate);
                            break;

                        case eMenuOptions.Exit: // 0
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
                    Screen.ShowMessage(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Screen.ShowError(eErrorType.ArgumentError);
                    Screen.ShowMessage(ae.Message);
                }
                catch (ValueOutOfRangeException voore)
                {
                    Screen.ShowError(eErrorType.ValueOutOfRangeError);
                    Screen.ShowMessage(voore.Message);
                }
                catch (Exception e)
                {
                    Screen.ShowMessage(e.Message);
                }
            } // END OF WHILE

            exitProgram();
        }

        private void showAllLicensePlates()
        {
            Screen.ShowFilters();
            Screen.ShowMessage(Garage.GetDetailsAboutAllVehicles());

            eCarState filterTarget = UI.CarStatePrompt();
            Screen.ShowMessage(Garage.FilterByVehicleState(filterTarget));
        }

        // update Vehicle to the next step
        private void updateVehicle(string userLicensePlate)
        {
            Screen.GetVehicleStateFromUser();
            eCarState carStateTarget = UI.CarStatePrompt();
            Garage.UpdateCarState(userLicensePlate, carStateTarget);
            Screen.Confirmation();
        }

        // Fill air in the vehicle
        private void fillAirInWheels(string userLicensePlate)
        {
            Garage.FillAir(userLicensePlate); // fill to the max!
            Screen.Confirmation();
        }

        // Fill gas in the vehicle and confirm
        private void fillGas(string userLicensePlate)
        {
            Screen.GetGasFromUser();
            float energyToFill = UI.EnergyToFillPrompt();

            Screen.GetGasTypeFromUSer();
            eGasType gasTypeToFill = UI.GasTypePrompt();

            Garage.FillGas(userLicensePlate, energyToFill, gasTypeToFill);
            Screen.Confirmation();
        }

        // Charge battery in the vehicle and confirm
        private void chargeBattery(string userLicensePlate)
        {
            Screen.GetBatteryFromUser();
            float energyToFill = UI.EnergyToFillPrompt();

            Garage.FillBattery(userLicensePlate, energyToFill);
            Screen.Confirmation();
        }

        private void showDetails(string i_UserLicensePlate)
        {
            Screen.ShowMessage(Garage.GetDetailsAboutVehicle(i_UserLicensePlate));
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

        private void insertNewVehicle()
        {
            string vehicleType = getNewVehicleType();

            Console.WriteLine("vehicleType" + vehicleType);
            bool isElectric = askedBouliani("is the Vehicle Electric?");
            int numOfWhell = askInt("How many wheels are there?");
            List<string> argsNeedForNewVehiclem = Garage.GetParams(vehicleType, isElectric, numOfWhell);
            List<string> userArgsForNewVehicle = new List<string>();
            foreach (string arg in argsNeedForNewVehiclem)
            {
                Screen.ShowMessage(string.Format("Please enter {0}", arg));
                userArgsForNewVehicle.Add(UI.ReadInput());
            }

            Garage.InsertNewVehicle(vehicleType, userArgsForNewVehicle);
        }

        private int askInt(string i_Msg)
        {
            Screen.ShowMessage(i_Msg);
            return UI.GetInt(i_Msg);
        }

        private bool askedBouliani(string i_Msg)
        {
            Screen.ShowMessage(i_Msg);
            return UI.GetBool(i_Msg);
        }

        private string getNewVehicleType()
        {
            List<string> vehicleTypes = Garage.GetVehicleTypes();
            StringBuilder sb = new StringBuilder(k_AskForCarType);

            sb.AppendLine();
            foreach (string vehicleType in vehicleTypes)
            {
                sb.AppendFormat(" {0} ,", vehicleType);
            }

            Screen.ShowMessage(sb.ToString());

            return UI.GetInputFormArray(vehicleTypes, sb.ToString());
        }
    }
}
