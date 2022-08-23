using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Runner
    {
        private const bool k_IsMenuOption = true;

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
            exitProgram();

        }

        private void run()
        {
            string welcomeMsg = string.Format("Welcome to {0} garage", Garage.Name);

            while (IsRunning)
            {
                try
                {
                    eMenuOptions eMenu = menuOptionsOperation(welcomeMsg);
                    string userLicensePlate = string.Empty;

                    if (eMenu != eMenuOptions.Exit && eMenu != eMenuOptions.AllLicensePlates)
                    {
                        Screen.GetLicensePlateFromUser();
                        userLicensePlate = UI.LicensePlatePrompt();
                    }

                    switch (eMenu)
                    {
                        case eMenuOptions.InsertVehicle: // 1
                            insertNewVehicle(userLicensePlate);
                            // Garage.InsertNewVehicle(userLicensePlate);
                            // TODO: make enum for CAR, MOTORBIKE, TRUCK
                            // TODO: get parameters for: CAR, MOTORBIKE, TRUCK
                            // TODO: make getUserInput function
                            break;

                        case eMenuOptions.AllLicensePlates: // 2
                            showAllLicensePlates();
                            break;

                        case eMenuOptions.UpdateVehicle: // 3
                            updateVehicle(userLicensePlate, k_IsMenuOption);
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

                UI.ReadInput();
                Console.ReadLine();
            } // END OF WHILE

        }

        private void showAllLicensePlates()
        {
            Screen.ShowFilters();
            Screen.ShowMessage(Garage.GetDetailsAboutAllVehicles());

            eCarState filterTarget = UI.CarStatePrompt();
            Screen.ShowMessage(Garage.FilterByVehicleState(filterTarget));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="i_UserLicensePlate"></param>
        /// <param name="i_IsUserRequest"></param>
        /// <returns>True if the license plate exists</returns>
        private bool updateVehicle(string i_UserLicensePlate, bool i_IsUserRequest)
        {
            bool ans = false;
            eCarState carStateTarget = eCarState.Repaired;

            bool isExistsLicensePlates = Garage.DoesLicensePlateExist(i_UserLicensePlate);
            if (isExistsLicensePlates)
            {
                if (i_IsUserRequest)
                {
                    Screen.GetVehicleStateFromUser();
                    carStateTarget = UI.CarStatePrompt();
                }

                Garage.UpdateCarState(i_UserLicensePlate, carStateTarget);
                Screen.Confirmation();

                ans = true;
            }

            return ans;
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
            float energyToFill = getFloatForUser(Screen.k_GetGasMsg);

            eGasType gasTypeToFill = getEGasType();

            Garage.FillGas(userLicensePlate, energyToFill, gasTypeToFill);
            Screen.Confirmation();
        }

        // Charge battery in the vehicle and confirm
        private void chargeBattery(string userLicensePlate)
        {
            float energyToFill = getFloatForUser(Screen.k_GetBatteryMsg);

            Garage.FillBattery(userLicensePlate, energyToFill);
            Screen.Confirmation();
        }

        private eGasType getEGasType()
        {
            bool userResponse = true;
            eGasType gasType = eGasType.Octan98;
            do
            {
                try
                {
                    Screen.GetGasTypeFromUSer();
                    gasType = UI.GasTypePrompt();
                    userResponse = false;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(string.Format("fe : not in Screen {0}", fe.Message));
                    Screen.ShowError(eErrorType.FormatError);
                }
            }
            while (userResponse);

            return gasType;
        }

        private float getFloatForUser(string i_msg)
        {
            bool userResponse = true;
            float userInpu = 0f;
            do
            {
                try
                {
                    Screen.ShowMessage(i_msg);

                    userInpu = UI.EnergyToFillPrompt();
                    userResponse = false;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(string.Format("fe : not in Screen {0}", fe.Message));
                    Screen.ShowError(eErrorType.FormatError);
                }
            }
            while (userResponse);

            return userInpu;
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

        private eMenuOptions menuOptionsOperation(string i_WelcomeMsg)
        {
            eMenuOptions o_Result;

            bool isValidChoice;
            do
            {
                m_Screen.ShowMenu(i_WelcomeMsg);
                isValidChoice = UI.GetMenuOptions(out o_Result);
                if (!isValidChoice)
                {
                    Screen.ShowMessage("invalid input, try again!");
                }
            }
            while (!isValidChoice);

            return o_Result;
        }

        private void insertNewVehicle(string i_UserLicensePlate)
        {
            // check if the vehicle exists
            bool isExistsLicensePlates = Garage.DoesLicensePlateExist(i_UserLicensePlate);

            if (!isExistsLicensePlates)
            {
                eGasType gasTypeToFill = eGasType.Soler;
                string vehicleType = getNewVehicleType();
                string msgForAmountOfEnergy = Screen.k_GetBatteryMsg;
                string msgForMaxEnergy = "What is the max battery?";
                string vehicleModel = askString("What is the vehicle manufacturer");
                bool isElectric = askedBoolean("is the Vehicle Electric? (yse / no)");

                if (!isElectric)
                {
                    Console.WriteLine(" the car is not Electric");
                    gasTypeToFill = getEGasType();
                    msgForAmountOfEnergy = Screen.k_GetGasMsg;
                    msgForMaxEnergy = "What is the The contents of the fuel tank?";
                }

                float energyToFill = getFloatForUser(msgForAmountOfEnergy);
                float maxBattery = getFloatForUser(msgForMaxEnergy);

                int numOfWheels = askInt("How many wheels are there?");
                float maxAirPressure = getFloatForUser("What is the max pressure of the wheels?");
                float currentAirPressure = getFloatForUser("What is the current pressure of the wheels?");
                string manufacturer = askString("What is the Wheel manufacturer");

                List<string> argsNeedForNewVehiclem = Garage.GetParams(vehicleType);
                List<string> userArgsForNewVehicle = new List<string>();
                foreach (string arg in argsNeedForNewVehiclem)
                {
                    Screen.ShowMessage(string.Format("Please enter {0}", arg));
                    userArgsForNewVehicle.Add(UI.ReadInput());
                }

                string name = askString("What is the owner name?");
                string phoneNumber = askString("What is the owner's phone number?");

                Garage.InsertNewVehicle(i_UserLicensePlate, vehicleType, vehicleModel, isElectric, gasTypeToFill, maxBattery, energyToFill, numOfWheels, maxAirPressure, currentAirPressure, manufacturer, userArgsForNewVehicle, name, phoneNumber);
            }
            else
            {
                updateVehicle(i_UserLicensePlate, k_IsMenuOption);
            }
        }

        private int askInt(string i_Msg)
        {
            bool isAns = true;
            int ans = 0;
            do
            {
                try
                {
                    Screen.ShowMessage(i_Msg);
                    ans = UI.GetInt(i_Msg);
                    isAns = false;
                }
                catch
                {

                }

            } while (isAns);


            return ans;
        }

        private bool askedBoolean(string i_Msg)
        {
            string strReslt;
            do
            {
                Screen.ShowMessage(i_Msg);
                strReslt = UI.ReadInput().ToLower();
            } while (strReslt != "yes" && strReslt != "no");

            bool resut = strReslt == "yes";

            return resut;
        }

        private string askString(string i_Msg)
        {
            Screen.ShowMessage(i_Msg);
            return UI.GetString();
        }

        private string getNewVehicleType()
        {
            List<string> vehicleTypes = Garage.GetVehicleTypes();
            StringBuilder sb = new StringBuilder(Screen.k_AskForCarType);

            sb.AppendLine();
            foreach (string vehicleType in vehicleTypes)
            {
                sb.AppendFormat("{0}, ", vehicleType);
            }

            Screen.ShowMessage(sb.ToString());

            return UI.GetInputFormArray(vehicleTypes, sb.ToString());
        }
    }
}
