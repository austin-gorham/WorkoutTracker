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

        public WorkoutEntry()
        {
            ExerciseEntries = new();
        }

        /// <summary>
        /// Date of the workout
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Weight of person working out
        /// </summary>
        public WeightAmt BodyWeight {  get; set; }

        /// <summary>
        /// List of exercises performed
        /// </summary>
        public List<ExerciseEntry> ExerciseEntries { get; set; }

        
        public override string ToString()
        {
            string date = String.Format("{0:M/d/yy}", EntryDate);
            string bWeight = this.BodyWeight.ToString();
            string exercises = "{";
            foreach (var entry in ExerciseEntries) 
                exercises += entry.ToString() + ",";
            exercises = exercises.TrimEnd(',');
            exercises += "}";
            return $"{date}, [{bWeight}]{exercises}";
        }
    }
}
