using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    public class WorkoutEntry
    {
        //private DateTime entryDate = new();
        //private WeightAmt bodyWeight = new();
        //private List<ExerciseEntry> exercizeEntries;

        public WorkoutEntry()
        {
            ExerciseEntries = new();
        }

        public DateTime EntryDate { get; set; }
        public WeightAmt BodyWeight {  get; set; }
        public List<ExerciseEntry> ExerciseEntries { get; set; }

        
        public override string ToString()
        {
            string date = String.Format("{0:M/d/yy}", EntryDate);
            string bWeight = this.BodyWeight.ToString();
            string exercises = "";
            foreach (var entry in ExerciseEntries) 
                exercises += "\n\t" + entry.ToString();
            return $"{date}, [{bWeight}]{exercises}";
        }
    }
}
