using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    internal class UserInput
    {
        /// <summary>
        /// get a string
        /// </summary>
        /// <returns></returns>
        public string GetUserString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get a char
        /// </summary>
        /// <returns></returns>
        public char GetUserChar()
        {
            string input = Console.ReadLine();

            // this is so it read the first char just in case if the user input multiple
            return input[0];
        }
    }
}
