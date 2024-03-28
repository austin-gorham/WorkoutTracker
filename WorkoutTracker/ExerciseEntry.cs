using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    public class ExerciseEntry
    {
        private string name = "";
        private int 
            setCount = 0, 
            repCount = 0, 
            excessRepCount = 0;

        public ExerciseEntry() { }

        [SetsRequiredMembers]
        public ExerciseEntry(string name) =>
            this.Name = name;

        /// <summary>
        /// Name of the exercise (e.g. push-ups, squats);
        /// cannot be null or empty
        /// </summary>
        public required string Name
        {
            get => name;
            set
            {
                // if (value == String.Empty)
                //This is more performant cause in the above one String.Empty will create a new empty string in memory to compare it to every time vs just checking to see if the value is null or empty,
                //also if the string was straight null and gets evaluated it would still cause a blow up I think
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException("Must not be empty",nameof(Name));
                name = value;
            }
        }

        /// <summary>
        /// Number of sets performed;
        /// integer; cannot be negative
        /// </summary>
        public int SetCount
        {
            get => setCount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(SetCount),value,"Cannot be less than 0");
                setCount = value;
            }
        }

        /// <summary>
        /// Number of reps per set performed;
        /// integer; cannot be negative
        /// </summary>
        public int RepCount
        {
            get => repCount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(RepCount), value, "Cannot be less than 0");
                repCount = value;
            }
        }

        /// <summary>
        /// Number of excess reps performed;
        /// integer; cannot be negative
        /// </summary>
        public int ExcessRepCount
        {
            get => excessRepCount;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(ExcessRepCount), value, "Cannot be less than 0");
                excessRepCount = value;
            }
        }

        /// <summary>
        /// Weight amount for the exercise;
        /// WeightAmt object
        /// </summary>
        public WeightAmt WeightAmount { get; set; }

        public override string ToString()
        {
            return $"{Name} [{SetCount}*{RepCount}+{ExcessRepCount}@{WeightAmount}]";
        }

    }
}
