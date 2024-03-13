namespace WorkoutTracker
{
    public partial class LogManager : Form
    {
        public LogManager()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frmNewEntry = new NewEntry();
            frmNewEntry.ShowDialog();
        }


    }
}
