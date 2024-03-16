using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker
{
    internal class WorkoutLog : IEnumerable<WorkoutEntry>, ICollection<WorkoutEntry>
    {
        private List<WorkoutEntry> entries;

        public WorkoutLog() => entries = [];
        //TODO: more constructors?

        public void Overwrite() => throw new NotImplementedException();
        public void Combine() => throw new NotImplementedException();
        public void AddExercise() => throw new NotImplementedException();


        //Interface implements
        public int Count => entries.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(WorkoutEntry item)//TODO
        {
            throw new NotImplementedException();
        }

        public WorkoutEntry this[DateTime date]//TODO
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public WorkoutEntry this[int i] //TODO: from? latest date
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Clear()
        {
            entries.Clear();
        }

        public bool Contains(WorkoutEntry item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(WorkoutEntry[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<WorkoutEntry> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(WorkoutEntry item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
