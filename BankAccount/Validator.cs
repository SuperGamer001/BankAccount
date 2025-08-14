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
        /// <exception cref="ArgumentException">Thrown if min boundary is greater than max boundary</exception>
        public bool IsWithinRange(double value, double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException("Minimum cannot be greater than maximum.");
            }
            return value >= min && value <= max;
        }
    }
}
