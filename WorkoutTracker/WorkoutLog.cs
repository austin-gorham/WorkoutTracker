using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    //TODO: implement exceptions properly
    //right now i'm letting them bubble up from the sorted list because it's easier
    //but that implementation should be hidden afaik
    public class WorkoutLog : IEnumerable<WorkoutEntry>, ICollection<WorkoutEntry>
    {
        private SortedList<DateTime,WorkoutEntry> entries;

        public WorkoutLog() => entries = [];
        //TODO: more constructors?

        public void Overwrite(WorkoutEntry entry)
        {
            if (!entries.ContainsKey(entry.EntryDate))
                throw new ArgumentException("Item to overwrite doesn't exist: " + nameof(entry));
            entries[entry.EntryDate] = entry;
        }

        public void AddOrOverwrite(WorkoutEntry entry)
        {
            if (entries.ContainsKey(entry.EntryDate))
                Overwrite(entry);
            else
                Add(entry);
        }
        //public void Combine() => throw new NotImplementedException();
        public void AddExercise(ExerciseEntry entry) => throw new NotImplementedException();
        public void OverwriteExercise(ExerciseEntry entry) => throw new NotImplementedException();

        public bool Contains(DateTime date) => 
            entries.ContainsKey(date);

        //Interface implements
        public int Count => entries.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(WorkoutEntry item)//TODO
        {
            if (entries.ContainsKey(item.EntryDate))
                throw new ArgumentException("Duplicate item: " + nameof(item));
            entries.Add(item.EntryDate, item);
            
            //This looks kooler and prally is a bit more performant cause it doesnt need to scan the list and check first it just assumes success then throws
            //the error if there is a problem. THough hypothetically it could be a diff problem
            // if (!entries.TryAdd(item.EntryDate, item))
            //     throw new ArgumentException("Duplicate item: " + nameof(item));
        }

        public WorkoutEntry this[DateTime date]//TODO
        {
            //TODO: add local error handling and exception info
            get => entries[date];
            
            set => entries[date] = value;
        }

        public WorkoutEntry this[int i] //TODO: from? latest date
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Clear() =>
            entries.Clear();
        

        public bool Contains(WorkoutEntry item) =>
            entries.Contains(new KeyValuePair<DateTime,WorkoutEntry> (item.EntryDate, item));

        public void CopyTo(WorkoutEntry[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<WorkoutEntry> GetEnumerator()
        {
            foreach (var entry in entries)
                yield return entry.Value;
        }

        public bool Remove(WorkoutEntry item) =>
            entries.Remove(item.EntryDate);
        

        public void RemoveAt(int index) =>
            entries.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
