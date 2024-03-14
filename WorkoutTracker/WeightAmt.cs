using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    public record struct WeightAmt 
    {
        public enum WeightUnit
        {
            GRAMS,
            KILOGRAMS,
            OUNCES,
            POUNDS
        }

        private decimal amount;
        private WeightUnit unit;

        public WeightAmt () 
        {
            this.Amount = 0;
            this.Unit = WeightUnit.GRAMS;
        }

        public WeightAmt (decimal amount, WeightUnit unit) =>
            (this.Amount, this.Unit) = (amount, unit);

        public decimal Amount { 
            get => amount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Amount),value,"Cannot be less than 0");
                amount = value;
            }
        }

        public WeightUnit Unit
        {
            get => unit;
            set
            {
                int upperBound = sizeof(WeightUnit) - 1;
                if (value > (WeightUnit)upperBound || value < (WeightUnit)0)
                    throw new ArgumentOutOfRangeException(nameof(Unit), value, $"Must be between 0 and {upperBound}, inclusive");
                unit = value;
            }
        }

        /*public bool isValidWeightUnitInt(int i)
        {
            int upperBound = sizeof(WeightUnit) - 1;
            return i <= upperBound && i >= 0;
        }*/

        public override string ToString() =>
            $"{this.Amount}{ this.unit switch {
                WeightUnit.GRAMS => "g",
                WeightUnit.KILOGRAMS => "kg",
                WeightUnit.OUNCES => "oz",
                WeightUnit.POUNDS => "lb",
                _ => throw new NotImplementedException()
            }}";



        public static readonly Dictionary<WeightUnit, decimal> UnitInGrams = new()
        {
            { WeightUnit.GRAMS, 1m },
            { WeightUnit.KILOGRAMS, 1000m },
            { WeightUnit.OUNCES, 28.3495m },
            { WeightUnit.POUNDS, 453.592m }
        };

    
    }
}
