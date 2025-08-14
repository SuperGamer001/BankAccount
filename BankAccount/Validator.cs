using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Validator
    {
        /// <summary>
        /// Checks to ensure a value is between inclusive boundaries.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="min">Minimum Inclusive Boundaries</param>
        /// <param name="max">Maximum Inclusive Boundaries</param>
        /// <returns></returns>
        public bool IsWithinRange(double value, double min, double max)
        {
            //return value >= min && value <= max;
            if (value < min)
            {
                return true;
            }
            else if (value > max)
            {
                return true;
            }
            return false;
        }
    }
}
