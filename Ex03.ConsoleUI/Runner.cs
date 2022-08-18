using System;
using System.Collections.Generic;
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
            m_Screen.ShowMessage(string.Format("Welcome to {0} garage", Garage.Name));
            while (IsRunning)
            {
                try
                {
                    eMenuOptions eMenu = menuOptionsOperation();

                    // Props[] argForMenueCosie =  Garage.GetPropForMenuOptions();
                    switch (eMenu)
                    {
                        case eMenuOptions.InsertCar:
                            break;
                        case eMenuOptions.AllLicensePlates:
                            break;
                        case eMenuOptions.UpdateVehicle:
                            break;
                        case eMenuOptions.FillAirInWheels:
                            break;
                        case eMenuOptions.FillGas:
                            break;
                        case eMenuOptions.ChargeBattery:
                            break;
                        case eMenuOptions.ShowDetails:
                            break;
                        case eMenuOptions.Exit:
                            break;
                    }
                }
                catch(Exception)
                {
                }
            }
        }

        private eMenuOptions menuOptionsOperation()
        {
            eMenuOptions o_Result;

            bool isValidChoice;
            do
            {
                m_Screen.ShowMenu();
                isValidChoice = UI.GetMenuOptions(out o_Result);
            }
            while (isValidChoice);

            return o_Result;
        }
    }
}
