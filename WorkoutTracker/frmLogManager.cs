


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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewEntry newEntryForm = new();
            entries.Add(newEntryForm.GetNewEntry());
            this.UpdateLogView();
        }

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
