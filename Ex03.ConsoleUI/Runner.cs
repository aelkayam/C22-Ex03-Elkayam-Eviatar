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
            List<string> Employees = new List<string>() { "Shimon", "Asaf-Plutz", "KMNO" };
            m_GarageManager = new GarageManager("Abba Shimon and Sons' garage", Employees);
        }

        /********    ************/
        public void Start()
        {
            this.IsRunning = true;
            run();
        }

        private void run()
        {
            m_Screen.ShowMessage(string.Format("Welcome to {0} garage"), Garage.Neme);
            while (IsRunning)
            {
                try
                {
                    eMenuOptions eMenu =MenuOptionsOperation();
                    Props[] argForMenueCosie =  Garage.GetPropForMenuOptions();
                    switch (eMenu)
                    {
                        case eMenuOptions.InsertCar:
                            
                            break;
                        case eMenuOptions.AllSerialNumbers:
                            break;
                        case eMenuOptions.UpdateCar:
                            break;
                        case eMenuOptions.PutAirInWheels:
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

        private eMenuOptions MenuOptionsOperation()
        {
            bool isValidChoice= false;
            eMenuOptions o_result;

            do
            {
                m_Screen.ShowMenu();
                isValidChoice= UI.getMenuOptions(out o_result);
            }
            while (isValidChoice);

            return o_result; 

        }

        private string askFordataExecuter(Props[] i_props)
        {
            foreach(Props Prop in i_props)
            {
                bool isSuccess;
                do
                {
                    Screen.ShowMessage(Prop.Message);
                    isSuccess = UI.GetInuput(Prop.Type);
                }while (!isSuccess);

            }
        }
    }
}
