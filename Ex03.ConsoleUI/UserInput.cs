﻿using System;


namespace Ex03.ConsoleUI
{
    internal class UserInput
    {
        public string UserName { get; set; }

        internal bool getMenuOptions(out eMenuOptions o_result)
        {
            throw new NotImplementedException();
        }

        internal bool GetInuput(Type type)
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
