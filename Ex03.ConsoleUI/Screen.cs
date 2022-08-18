using System;

namespace Ex03.ConsoleUI
{
    internal class Screen
    {
        private const string k_MenuMsg = @"Please select the option: 
1   - To enter a new car in the garage. 
2   - To view all the License Plates in the garage.
3   - To update your vehicle state.
4   - To filling air in your vehicle wheels.
5   - To fill gas in your vehicle.
6   - To charge the battery of your vehicle.
7   - To view the details of your vehicle in the garage.
9   - To Exit.
";

        public void ShowMessage(string i_MessageToShow)
        {
            print(i_MessageToShow);
        }

        private void print(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal void ShowMenu()
        {
            print(k_MenuMsg);
        }
    }
}
