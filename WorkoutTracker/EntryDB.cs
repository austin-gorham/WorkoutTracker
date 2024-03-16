using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    internal static class EntryDB
    {
        const string workoutEntryFile = "WorkoutEntries.txt";
        const string exerciseEntryFile = "ExerciseEntries.txt";
        const string directory = @"C:\Users\agven\source\repos\WorkoutTracker";
        const string woEntryPath = directory + workoutEntryFile;
        const string exEntryPath = directory + exerciseEntryFile;

        const string sep = ",";

        public static WorkoutLog getEntries() 
        {
            WorkoutLog entries = new();

            using (StreamReader woReader = new(
                new FileStream(woEntryPath,FileMode.OpenOrCreate,FileAccess.Read) ) )
            {
                while(woReader.Peek() != -1)
                {
                    string record = woReader.ReadLine() ?? "";
                    string[] fields = record.Split( sep );

                    if (fields.Length == 2)
                    {
                        DateTime date = DateTime.Parse(fields[0]);
                        WorkoutEntry entry = new WorkoutEntry()
                        {
                            EntryDate = date,
                            BodyWeight = WeightAmt.Parse(fields[1])
                        };
                        entries.Add(entry);
                    }
                }
            }

            using (StreamReader exReader = new(
                new FileStream(exEntryPath,FileMode.OpenOrCreate,FileAccess.Read)))
            {
                while(exReader.Peek() != -1)
                {
                    string record = exReader.ReadLine() ?? "";
                    string[] fields = record.Split( sep );

                    if (fields.Length == 6)
                    {
                        DateTime date = DateTime.Parse(fields[0]);

                        ExerciseEntry entry = new ExerciseEntry() { 
                            Name = fields[1],
                            SetCount = Convert.ToInt32(fields[2]),
                            RepCount = Convert.ToInt32(fields[3]),
                            ExcessRepCount = Convert.ToInt32(fields[4]),
                            WeightAmount = WeightAmt.Parse(fields[5])
                        };
                        entries[date].ExerciseEntries.Add(entry);
                    }
                }
            }

            return entries;
        }

        //TODO: swap over to workout log?
        public static void saveEntries(IEnumerable<WorkoutEntry> entries)
        {
            using (StreamWriter woWriter = new(
                new FileStream(woEntryPath, FileMode.Create, FileAccess.Write)))
            {
                foreach (WorkoutEntry entry in entries)
                {
                    woWriter.Write(entry.EntryDate + sep);
                    woWriter.WriteLine(entry.BodyWeight);
                }
            }

            using (StreamWriter exWriter = new(
                new FileStream(exEntryPath, FileMode.Create, FileAccess.Write)))
            {
                foreach (WorkoutEntry woEntry in entries)
                {
                    foreach (ExerciseEntry exEntry in woEntry.ExerciseEntries)
                    {
                        exWriter.Write(woEntry.EntryDate + sep);//Primary key
                        exWriter.Write(exEntry.Name + sep);
                        exWriter.Write(exEntry.SetCount + sep);
                        exWriter.Write(exEntry.RepCount + sep);
                        exWriter.Write(exEntry.ExcessRepCount + sep);
                        exWriter.WriteLine(exEntry.WeightAmount);
                    }

                }
            }
        }

        
        
    }
}
