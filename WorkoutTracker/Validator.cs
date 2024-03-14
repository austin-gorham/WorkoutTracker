using static WorkoutTracker.WeightAmt;

namespace WorkoutTracker
{
    internal static class Validator
    {
        internal static bool IsDecimal(string s) => Decimal.TryParse(s, out _);
        internal static bool IsInt(string s) => Int32.TryParse(s, out _);
        internal static bool IsNotNegative(int i) => i >= 0;
        internal static bool IsNotNegative(decimal d) => d >= 0;
        internal static bool IsPresent(string s) => s != String.Empty;
        internal static bool IsValidWeightUnit(int i) => Enum.IsDefined(typeof(WeightUnit), (WeightUnit)i);
    }
}