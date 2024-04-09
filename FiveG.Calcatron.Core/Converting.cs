﻿using System;
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
        /// Finds the largest Dividor of a given Number and base
        /// </summary>
        /// <param name="num">Number for divider finding</param>
        /// <param name="baseN">base</param>
        /// <returns></returns>
        private static int FindLargestDividor(double num, int baseN)
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

            string numberEq = pattern.Substring(0, baseN);

            string convertedNum = "";

            int current;

            int div = FindLargestDividor(dec, baseN);
            while (dec > baseN)
            {
                current = (int)(dec / Math.Pow(baseN, div));
                convertedNum += numberEq[current];
                dec = dec % Math.Pow(baseN, div);
                if (div == 0) convertedNum += ",";
                div--;
            }
            convertedNum += numberEq[(int)dec];
            while (div != 0)
            {
                convertedNum += 0;
                div--;
            }

            return convertedNum;
        }
    }
}
