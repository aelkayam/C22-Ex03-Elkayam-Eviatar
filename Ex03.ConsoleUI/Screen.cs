using System;

namespace Ex03.ConsoleUI
{
    internal class Screen
    {
        public void ShowMessage(string i_MessageToShow)
        {
            Print(i_MessageToShow);
        }

        private void Print(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal void ShowMenu()
        {
            throw new NotImplementedException();
        }

        //public static void PrintCar(Vehicle i_Vehicle)
        //{
        //    Print(i_Vehicle.ToString());
        //}
    }
}
