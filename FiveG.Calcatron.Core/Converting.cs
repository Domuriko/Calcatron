using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveG.Calcatron.Core
{
    abstract class Converting
    {
        const string pattern = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Finds the largest Divisor of a given Number and base
        /// </summary>
        /// <param name="num">Number for divisor finding</param>
        /// <param name="baseN">base</param>
        /// <returns></returns>
        private static int FindLargestDivisor(double num, int baseN)
        {
            //dividor
            int div = 0;

            for (int i = 0; num % Math.Pow(baseN, i) < num; i++)
            {
                div = i;
            }
            return div;
        }
        /// <summary>
        /// Calculates the number from dec to a baseN number
        /// </summary>
        /// <param name="dec">Number</param>
        /// <param name="baseN">Base</param>
        /// <returns></returns>
        public static string DecToBaseOf(double dec, int baseN)
        {
            //get the list for the specified base
            string numberEq = pattern[..baseN];

            //placeholder for the converted Number
            string convertedNum = "";

            //temporary value for current solution
            int current;

            //get the largest divisor for the given base
            int div = FindLargestDivisor(dec, baseN);
            
            while (dec >= baseN)
            {
                //get the current division value
                current = (int)(dec / Math.Pow(baseN, div));

                //adding the number equivalent of the specified base
                convertedNum += numberEq[current];

                //changing the decimal to be the rest value
                dec %= Math.Pow(baseN, div);

                //add a comma as soon as the value gets comma separated
                if (div == 0) convertedNum += ",";

                //move on to the next base
                div--;
            }
            
            //fill out the rest of the numbers with 0
            while (div != 0)
            {
                convertedNum += 0;
                div--;
            }

            return convertedNum;
        }
        /// <summary>
        /// Calculates the number from a baseN number to dec
        /// </summary>
        /// <param name="num">Number</param>
        /// <param name="baseN">Base</param>
        /// <returns></returns>
        public static double BaseOfToDec(string num, int baseN)
        {
            //get the list for the specified base
            string numberEq = pattern[..baseN];

            //placeholder for the converted Number
            string convertedNum = "";

            //location of the comma; if no comma is in the number to convert, -1 if there is no comma.
            int commaLocation = num.IndexOf(',');

            //the current exponent for the calculation
            int current = commaLocation != -1 ? num[..commaLocation].Length - 1 : num.Length - 1;

            //the duration for the for-loop
            int duration = commaLocation != -1 ? num.Length+1 : num.Length;

            for (int i = 0; i < duration; i++)
            {
                if (i != commaLocation)
                {
                    //finds the index of a number in the given list (e.g. base16 'A' returns 10)
                    //multiplies the number receiver with the current potency
                    convertedNum += (numberEq.IndexOf(num[i]) * Math.Pow(baseN,current));
                }
                else
                {
                    convertedNum += ',';
                }
                current--;
            }

            return Double.Parse(convertedNum);
        }

        /// <summary>
        /// Converts a number from a specified originBase to a specified destinationBase
        /// </summary>
        /// <param name="num">Number</param>
        /// <param name="baseO">Origin base</param>
        /// <param name="baseD">Destination base</param>
        /// <returns></returns>
        public static string BaseOfToBaseOf(string num, int baseO, int baseD)
        {
            return (DecToBaseOf(BaseOfToDec(num,baseO),baseD));
        }
    }
}
