using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    public record struct WeightAmt 
    {
        /// <summary>
        /// Units of weight, use dictionary for conversion factors
        /// </summary>
        public enum WeightUnit
        {
            GRAMS,
            KILOGRAMS,
            OUNCES,
            POUNDS
        }

        private decimal amount = 0;
        private WeightUnit unit = WeightUnit.GRAMS;

        public WeightAmt() { }

        public WeightAmt (decimal amount, WeightUnit unit) =>
            (this.Amount, this.Unit) = (amount, unit);

        /// <summary>
        /// Numeric part of a weight amount;
        /// decimal; cannot be negative
        /// </summary>
        public decimal Amount 
        { 
            get => amount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Amount),value,"Cannot be less than 0");
                amount = value;
            }
        }

        /// <summary>
        /// Unit part of the weight amount;
        /// uses the WeightUnit enum and must be a defined value of such;
        /// (math teachers everywhere breath a sigh of relief)
        /// </summary>
        public WeightUnit Unit
        {
            get => unit;
            set
            {
                if (Enum.IsDefined(typeof(WeightUnit),value))
                    unit = value;
                else 
                    throw new ArgumentException("Must be a defined enum value", nameof(WeightUnit));
            }
        }

        public override string ToString() =>
            $"{this.Amount}{ this.unit switch {
                WeightUnit.GRAMS => "g",
                WeightUnit.KILOGRAMS => "kg",
                WeightUnit.OUNCES => "oz",
                WeightUnit.POUNDS => "lb",
                _ => throw new NotImplementedException()
            }}";


        /// <summary>
        /// Dictionary for conversion factors of the weight units
        /// </summary>
        public static readonly Dictionary<WeightUnit, decimal> UnitInGrams = new()
        {
            { WeightUnit.GRAMS, 1m },
            { WeightUnit.KILOGRAMS, 1000m },
            { WeightUnit.OUNCES, 28.3495m },
            { WeightUnit.POUNDS, 453.592m }
        };

    
    }
}
