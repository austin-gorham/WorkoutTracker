


using System.Diagnostics;

namespace WorkoutTracker
{
    public partial class frmLogManager : Form
    {
        private WorkoutLog entries = [];

        public frmLogManager()
        {
            InitializeComponent();
        }

        private void frmLogManager_Load(object sender, EventArgs e)
        {
            entries = EntryDB.getEntries();
            UpdateLogView();
        }

        /// <summary>
        /// add button event handler;
        /// attempts to add a new workout by prompting the user with a new workout entry form;
        /// creates the form, calls the get method,
        /// if its not null, adds the new entry and updates the log display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewEntry newEntryForm = new();
            
            if (newEntryForm.GetNewEntry(entries.Keys) is WorkoutEntry entry)
            {
                //Update entry if date exists, otherwise add new
                if (entries.ContainsKey(entry.EntryDate) )
                    entries[entry.EntryDate] = entry;
                else
                    entries.Add(entry.EntryDate,entry);
                
                this.UpdateLogView();
                EntryDB.saveEntries(entries.Values);
            }
        }

        /// <summary>
        /// Updates whatever is displaying the log to adjust to any entry list modifications
        /// </summary>
        private void UpdateLogView()
        {
            lstExerciseLog.Items.Clear();
            foreach (KeyValuePair<DateTime,WorkoutEntry> entry in entries)
                lstExerciseLog.Items.Add(entry.Value.ToString());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }


    }
}
