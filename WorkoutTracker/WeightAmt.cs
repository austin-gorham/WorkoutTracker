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

        private decimal amount = 0;
        private WeightUnit unit = WeightUnit.GRAMS;

        public WeightAmt () { }

        public WeightAmt (decimal amount, WeightUnit unit) =>
            (this.Amount, this.Unit) = (amount, unit);

        public decimal Amount { 
            get => amount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Amount cannot be less than 0");
                amount = value;
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

        public WeightUnit Unit { get; set; }

        public static readonly Dictionary<WeightUnit, decimal> UnitInGrams = new()
        {
            { WeightUnit.GRAMS, 1m },
            { WeightUnit.KILOGRAMS, 1000m },
            { WeightUnit.OUNCES, 28.3495m },
            { WeightUnit.POUNDS, 453.592m }
        };

    
    }
}
