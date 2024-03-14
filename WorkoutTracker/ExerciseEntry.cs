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

        public required string Name
        {
            get => name;
            set
            {
                if (value == String.Empty)
                    throw new ArgumentException("Must not be empty",nameof(Name));
                name = value;
            }
        }

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

        public WeightAmt WeightAmount { get; set; }

        public override string ToString()
        {
            return $"{Name} [{SetCount}*{RepCount}+{ExcessRepCount}@{WeightAmount}]";
        }

    }
}
