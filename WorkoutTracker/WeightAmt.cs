using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    public partial record struct WeightAmt 
    {
        /// <summary>
        /// Units of weight; 
        /// use dictionary for conversion factors
        /// </summary>
        public enum WeightUnit
        {
            //I think if you add this description decorator on each enum, when you do a WeightUnit.GRAMS.ToString() it will return the description text... I think
            [Description("g")]
            GRAMS,
            [Description("kg")]
            KILOGRAMS,
            OUNCES,
            POUNDS
        }

        private decimal amount = 0;
        private WeightUnit unit = WeightUnit.GRAMS;

        /// <summary>
        /// what a monster lmao;
        /// checks for valid decimal number (allows , and _ thousands seperators);
        /// doesn't allow headless decimals (ex .3 or .45);
        /// and for valid unit (singluar or plural);
        /// allows for a space between the number and unit
        /// </summary>
        /// <returns>regex object for a valid weight</returns>
        [GeneratedRegex(@"^((\d{1,3},)?((\d{3},)*\d{3})|(\d{1,3}_)?((\d{3}_)*\d{3})|\d+)(\.\d*)?\s?(gram|kilogram|ounce|pound|g|kg|oz|lb)s?$", 
            RegexOptions.IgnoreCase)]
        private static partial Regex ValidWeightGeneratedRegex();

        /// <summary>
        /// simple catch all for units;
        /// meant only to seperate unit from number;
        /// only to be used after primary validity check;
        /// does not check if unit is appropriate
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex(@"[a-z]+", RegexOptions.IgnoreCase)]
        private static partial Regex GroupedLettersGeneratedRegex();

        //An attempt at breaking down the monster, but compiler doesn't like it
        //likely due to the string insertion 
        /*private const string RegPatPlainInt = @"\d+",
            RegPatCommaInt = @"((\d{1,3},)?((\d{3},)*\d{3})",
            RegPatUnderscoreInt = @"(\d{1,3}_)?((\d{3}_)*\d{3})",
            RegPatDecimal = @"(\.\d*)?",
            RegPatUnit = @"(gram|kilogram|ounce|pound|g|kg|oz|lb)s?";*/

        //private const string RegPatValidWeight = $"^({RegPatCommaInt}|{RegPatUnderscoreInt}|{RegPatPlainInt}){RegPatDecimal}\\s?{RegPatUnit}$";



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
            //There is a description decorator on the enum now I think that would do this for you, see above
            $"{this.Amount}{ this.unit switch {
                WeightUnit.GRAMS => "g",
                WeightUnit.KILOGRAMS => "kg",
                WeightUnit.OUNCES => "oz",
                WeightUnit.POUNDS => "lb",
                _ => throw new ArgumentException("Invalid unit")
            }}";


        public static WeightAmt Parse(string s)
        {
            if (ValidWeightGeneratedRegex().IsMatch(s))
            {
                string unitPart = GroupedLettersGeneratedRegex().Match(s).Value;
                string numericPart = s.Replace(unitPart,null);
                decimal amount = Convert.ToDecimal(numericPart);
                WeightUnit unit = unitPart.ToLower().TrimEnd('s') switch
                {
                    "g" => WeightUnit.GRAMS,
                    "gram" => WeightUnit.GRAMS,
                    "kg" => WeightUnit.KILOGRAMS,
                    "kilogram" => WeightUnit.KILOGRAMS,
                    "oz" => WeightUnit.OUNCES,
                    "ounce" => WeightUnit.OUNCES,
                    "lb" => WeightUnit.POUNDS,
                    "pound" => WeightUnit.POUNDS,
                    _ => throw new ArgumentException("Invalid unit")
                };
                return new WeightAmt(amount, unit);
            }
            throw new FormatException("Invalid weight unit format.  String should be (valid decimal)(valid unit)");
        }

        public static bool TryParse(string s, out WeightAmt w)
        {
            try
            {
                w = Parse(s);
                return true;
            } catch (Exception e) when (
                e is FormatException 
                or ArgumentNullException) { }
            {
                w = new WeightAmt();
                return false;
            }
        }

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
