using System;

namespace Ex03.ConsoleUI
{
    internal class UserInput
    {
        public string UserName { get; set; }

        internal bool GetMenuOptions(out eMenuOptions o_result)
        {
            return Enum.TryParse<eMenuOptions>(readInput(), out o_result);
        }

        internal bool GetInput(Type type)
        {
            bool ans = false;
            readInput();

            return ans;
        }

        private string readInput()
        {
            return Console.ReadLine();
        }
    }
}
