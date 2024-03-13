using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    internal class ExerciseEntry
    {
        private string name = "";
        private int 
            setCount = 0, 
            repCount = 0, 
            excessRepCount = 0;
        private WeightAmt weightAmount = new();

        public ExerciseEntry() { }

        [SetsRequiredMembers]
        public ExerciseEntry(string name) =>
            this.Name = name;

        public required string Name
        {
            get => name;
            set
            {
                if (name == String.Empty)
                    throw new ArgumentException("Name must not be empty");
                name = value;
            }
        }

        public int SetCount
        {
            get => setCount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("SetCount cannot be less than 0");
                setCount = value;
            }
        }

        public int RepCount
        {
            get => repCount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("RepCount cannot be less than 0");
                repCount = value;
            }
        }

        public int ExcessRepCount
        {
            get => excessRepCount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("ExcessRepCount cannot be less than 0");
                excessRepCount = value;
            }
        }

        public WeightAmt WeightAmount { get; set; }

    }
}
