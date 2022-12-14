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

        private readonly Screen r_Screen;
        private readonly UserInput r_UserInput;
        private readonly Menu r_Menu;
        private bool m_IsRunning;
        private GarageManager m_GarageManager;

        /******** Properties ************/
        public bool IsRunning
        {
            get { return m_IsRunning; }
            set { m_IsRunning = value; }
        }

        public Screen Screen
        {
            get { return r_Screen; }
        }

        public UserInput UI
        {
            get { return r_UserInput; }
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
            m_GarageManager = new GarageManager();
            r_Screen = default;
            r_UserInput = default;
            r_Menu = new Menu(r_Screen, r_UserInput);
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
            Screen.ShowMessage("Welcome to our garage!");
            while (IsRunning)
            {
                try
                {
                    eMenuOptions eMenu = r_Menu.MenuOptionsOperation();
                    string userLicensePlate = string.Empty;

                    if (eMenu != eMenuOptions.Exit && eMenu != eMenuOptions.AllLicensePlates)
                    {
                        Screen.GetLicensePlateFromUser();
                        userLicensePlate = UI.LicensePlatePrompt();
                    }

                    switch (eMenu)
                    {
                        case eMenuOptions.InsertVehicle:
                            insertNewVehicle(userLicensePlate);
                            break;

                        case eMenuOptions.AllLicensePlates:
                            showAllLicensePlates();
                            break;

                        case eMenuOptions.UpdateVehicle:
                            updateVehicle(userLicensePlate, k_IsMenuOption);
                            break;

                        case eMenuOptions.FillAirInWheels:
                            fillAirInWheelsToMax(userLicensePlate);
                            break;

                        case eMenuOptions.FillGas:
                            fillGas(userLicensePlate);
                            break;

                        case eMenuOptions.ChargeBattery:
                            chargeBattery(userLicensePlate);
                            break;

                        case eMenuOptions.ShowDetails:
                            showDetails(userLicensePlate);
                            break;

                        case eMenuOptions.Exit:
                            stopProgram();
                            break;
                    }
                }
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

                waitForKeyPress();
            } // END OF WHILE
        }

        private void showAllLicensePlates()
        {
            Screen.ShowMessage(Garage.GetDetailsAboutAllVehicles());

            eCarState filterTarget = r_Menu.GetEnumPrompt<eCarState>(Screen.k_FiltersMsg);

            string filteredVehicles = Garage.FilterByVehicleState(filterTarget);
            Screen.ShowMessage(filteredVehicles);
        }

        private bool updateVehicle(string i_UserLicensePlate, bool i_IsUserRequest)
        {
            eCarState carStateTarget = eCarState.Repaired;

            bool doesLicensePlateExist = Garage.DoesLicensePlateExist(i_UserLicensePlate);
            bool ans;
            if (doesLicensePlateExist)
            {
                if (i_IsUserRequest)
                {
                    carStateTarget = r_Menu.GetEnumPrompt<eCarState>(Screen.k_FiltersMsg);
                }

                Garage.UpdateCarState(i_UserLicensePlate, carStateTarget);
                Screen.ConfirmUpdate(carStateTarget.ToString());

                ans = true;
            }
            else
            {
                throw new ArgumentException("This license plate is not in our garage");
            }

            return ans;
        }

        private void fillAirInWheelsToMax(string i_UserLicensePlate)
        {
            Garage.FillAir(i_UserLicensePlate);
            Screen.ConfirmAirPressure();
        }

        private void fillGas(string i_UserLicensePlate)
        {
            float energyToFill = getFloatForUser(Screen.k_GetGasMsg);

            eGasType gasTypeToFill = r_Menu.GetEnumPrompt<eGasType>(Screen.k_GetGasTypeMsg);

            Garage.FillGas(i_UserLicensePlate, energyToFill, gasTypeToFill);
            Screen.ConfirmGas(energyToFill.ToString());
        }

        private void chargeBattery(string i_UserLicensePlate)
        {
            float energyToFill = getFloatForUser(Screen.k_GetBatteryMsg);

            Garage.FillBattery(i_UserLicensePlate, energyToFill);
            Screen.ConfirmBattery(energyToFill.ToString());
        }

        private float getFloatForUser(string i_Msg)
        {
            bool userResponse = true;
            float userInpu = 0f;
            do
            {
                try
                {
                    Screen.ShowMessage(i_Msg);

                    userInpu = UI.EnergyToFillPrompt();
                    userResponse = false;
                }
                catch (FormatException fe)
                {
                    Screen.ShowError(eErrorType.FormatError);
                    Screen.ShowMessage(fe.Message);
                }
            }
            while (userResponse);

            return userInpu;
        }

        private void showDetails(string i_UserLicensePlate)
        {
            Screen.ShowMessage(Garage.GetDetailsAboutVehicle(i_UserLicensePlate));
        }

        private void waitForKeyPress()
        {
            Screen.ShowMessage("\nPlease enter any key to continue...");
            UI.ReadInput();
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

        private void insertNewVehicle(string i_UserLicensePlate)
        {
            // check if the vehicle exists
            bool isExistsLicensePlates = Garage.DoesLicensePlateExist(i_UserLicensePlate);

            if (!isExistsLicensePlates)
            {
                bool isElectric = askedBoolean(Screen.k_AskIsElectric);
                string vehicleType, msgForAmountOfEnergy, msgForMaxEnergy, vehicleModel;
                eGasType gasTypeToFill = default;

                if (isElectric)
                {
                    msgForAmountOfEnergy = Screen.k_GetBatteryMsg;
                    msgForMaxEnergy = Screen.k_AskMaxBattery;
                }
                else
                {
                    gasTypeToFill = r_Menu.GetEnumPrompt<eGasType>(Screen.k_GetGasTypeMsg);
                    msgForAmountOfEnergy = Screen.k_GetGasMsg;
                    msgForMaxEnergy = Screen.k_AskMaxFuel;
                }

                vehicleType = getNewVehicleType();
                vehicleModel = askString(Screen.k_AskVehicleManufacturer);

                float engineCurrentEnergy = getFloatForUser(msgForAmountOfEnergy);
                float engineMaxEnergy = getFloatForUser(msgForMaxEnergy);

                int wheelsAmount = askInt(Screen.k_AskHowManyWheels);
                float wheelAirPressureMax = getFloatForUser(Screen.k_AskMaxAirPressure);
                float wheelAirPressureCurrent = getFloatForUser(Screen.k_AskCurrentAirPressure);
                string wheelManufacturer = askString(Screen.k_AskWheelManufacturer);

                List<string> argsNeedForNewVehicle = Garage.GetParams(vehicleType);
                List<string> userArgsForNewVehicle = new List<string>();

                foreach (string arg in argsNeedForNewVehicle)
                {
                    Screen.ShowMessage(string.Format("Please enter {0}", arg));
                    userArgsForNewVehicle.Add(UI.ReadInput());
                }

                string ownerName = askString(Screen.k_AskOwnerName);
                string ownerPhone = askString(Screen.k_AskOwnerTelNumber);

                Garage.InsertNewVehicle(i_UserLicensePlate, vehicleType, vehicleModel, isElectric, gasTypeToFill, engineMaxEnergy, engineCurrentEnergy, wheelsAmount, wheelAirPressureMax, wheelAirPressureCurrent, wheelManufacturer, userArgsForNewVehicle, ownerName, ownerPhone);
            }
            else
            {
                updateVehicle(i_UserLicensePlate, k_IsMenuOption);
            }
        }

        private int askInt(string i_Msg)
        {
            bool isAns = false;
            int ans = 0;
            do
            {
                try
                {
                    Screen.ShowMessage(i_Msg);
                    ans = UI.GetInt();
                    isAns = true;
                }
                catch(FormatException)
                {
                    Screen.ShowError(eErrorType.FormatError);
                }
            }
            while (!isAns);

            return ans;
        }

        private bool askedBoolean(string i_Msg)
        {
            string strReslt;
            do
            {
                Screen.ShowMessage(i_Msg);
                strReslt = UI.ReadInput().ToLower();
            }
            while (strReslt != "yes" && strReslt != "no");

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

            return UI.GetInputFormArray(vehicleTypes);
        }
    }
}