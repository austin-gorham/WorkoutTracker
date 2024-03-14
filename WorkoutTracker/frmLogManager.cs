


namespace WorkoutTracker
{
    public partial class frmLogManager : Form
    {
        private List<WorkoutEntry> entries = new();

        public frmLogManager()
        {
            InitializeComponent();
        }

        private void frmLogManager_Load(object sender, EventArgs e)
        {
  
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
            if (newEntryForm.GetNewEntry() is WorkoutEntry entry)
            {
                entries.Add(entry);
                this.UpdateLogView();
            }
        }

        /// <summary>
        /// Updates whatever is displaying the log to adjust to any entry list modifications
        /// </summary>
        private void UpdateLogView()
        {
            foreach (WorkoutEntry entry in entries)
            {
                lstExerciseLog.Items.Clear();
                lstExerciseLog.Items.Add(entry.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }


    }
}
