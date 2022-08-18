using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Runner
    {
        private const string k_askForCarType = @"Please enter the type of vehicle you want to enter the garage";

        private bool m_IsRunning;
        private Screen m_Screen;
        private UserInput m_UserInput;
        private GarageManager m_GarageManager;
        private object sdzx;


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

                    // TODO: each case will have ONLY FUCTION CALLS!!!
                    switch (eMenu)
                    {
                        case eMenuOptions.InsertVehicle:
                            insertNewVehicle();
                            // TODO: make enum for CAR, MOTORBIKE, TRUCK
                            // TODO: get parameters for: CAR, MOTORBIKE, TRUCK
                            // TODO: make getUserInput function
                            break;
                        case eMenuOptions.AllLicensePlates:
                            // TODO: get all vehicles from the garage and print the license plates
                            // TODO: filter by car state
                            break;
                        case eMenuOptions.UpdateVehicle:
                            // TODO: get from user: get license plate
                            // TODO: create method for changing state: INREPAIR > REPAIRED > PAYED
                            // TODO: filter by car state
                            break;
                        case eMenuOptions.FillAirInWheels:
                            // TODO: get from user: get license plate
                            // TODO: get from user: fill one wheel(by index) or all wheels
                            // TODO: get from user: how much air to fill (bar or PSI)
                            break;
                        case eMenuOptions.FillGas:
                            // TODO: get from user: get license plate
                            // TODO: get from user: how much gas you want to fill
                            break;
                        case eMenuOptions.ChargeBattery:
                            // TODO: get from user: get license plate
                            // TODO: get from user: how much battery you want to fill
                            break;
                        case eMenuOptions.ShowDetails:
                            // TODO: get from user: get license plate and return DETAILS about the car
                            break;
                        case eMenuOptions.Exit:
                            m_IsRunning = false;
                            break;
                        default:
                            Console.WriteLine("default");
                            break;
                    }
                }

                // TODO: check the order
                catch (FormatException fe)
                {
                    // TODO: think about what will happen with FormatException
                }
                catch (ArgumentException ae)
                {
                    // TODO: think about what will happen with ArgumentException
                }
                catch (ValueOutOfRangeException voore)
                {
                    // TODO: think about what will happen with ValueOutOfRangeException
                }
                catch (Exception)
                {
                    // TODO:
                }
            } // END OF WHILE

            // TODO: create 'Goodbye' method
            Screen.ShowMessage("Goodbye! press enter to exit");
            Console.ReadLine();
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
                userArgsForNewVehicle.Add(UI.GetInput());
            }

            Garage.InsertNewVehicle(vehicleType ,userArgsForNewVehicle);
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
            StringBuilder sb = new StringBuilder(k_askForCarType);

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
