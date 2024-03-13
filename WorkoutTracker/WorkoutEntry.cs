using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    internal class WorkoutEntry
    {
        private DateTime entryDate = new();
        private WeightAmt bodyWeight = new();
        private List<ExerciseEntry> exercizeEntries = new();

        public DateTime EntryDate { get; set; }
        public WeightAmt BodyWeight {  get; set; }
        public List<ExerciseEntry>? ExerciseEntries { get; set; }

        

    }
}
