using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WorkoutTracker.WeightAmt;

namespace WorkoutTracker
{
    public partial class frmNewEntry : Form
    {
        private WorkoutEntry? woEntry = null;
        SortedSet<DateTime>? datesExistingEntries = null;

        public frmNewEntry()
        {
            InitializeComponent();
        }


        /// <summary>
        /// form on load event handler;
        /// initializes the weight unit combo boxes' items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNewEntry_Load(object sender, EventArgs e)
        {
            foreach (WeightUnit wu in Enum.GetValues(typeof(WeightUnit)))
            {
                cbbBodyWeightUnit.Items.Add(wu.ToString().ToLower());
                cbbExerciseWeightUnit.Items.Add(wu.ToString().ToLower());
            }
        }

        /// <summary>
        /// function to call to get a new WorkoutEntry object created from this form;
        /// takes list of dates to check if new entry will overwrite existing
        /// returns object if form was saved;
        /// returns null if form was cancelled
        /// </summary>
        /// <param name="dates">dates to check against if already exist and warn user of overwrite; pass null to bypass check</param>
        /// <returns>the WorkoutEntry if saved; null if form was cancelled</returns>
        public WorkoutEntry GetNewEntry(IList<DateTime>? dates)
        {
            if (dates != null)
                this.datesExistingEntries = new SortedSet<DateTime>(dates);
            this.ShowDialog();
            return woEntry!;
        }

        /// <summary>
        /// Save button event handler;
        /// Validates the data currently entered in the form;
        /// if valid, builds the WorkoutEntry object to pass on and closes the form;
        /// else does nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsDataValid() && shouldSaveEntry())
            {
                //WorkoutEntry property initialization
                woEntry = new()
                {
                    EntryDate = dtpWorkoutDate.Value.Date,
                    BodyWeight = new WeightAmt(Convert.ToDecimal(txtBodyWeightAmt.Text),
                        (WeightUnit)cbbBodyWeightUnit.SelectedIndex)
                };

                //Adding the exercise entry
                woEntry.ExerciseEntries.Add(new()
                {
                    Name = txtExerciseName.Text,
                    SetCount = Convert.ToInt32(txtExerciseSetCt.Text),
                    RepCount = Convert.ToInt32(txtExerciseRepCt.Text),
                    ExcessRepCount = Convert.ToInt32(txtExerciseExRepCt.Text),
                    WeightAmount = new WeightAmt(Convert.ToDecimal(txtExerciseWeightAmt.Text),
                        (WeightUnit)cbbExerciseWeightUnit.SelectedIndex)
                });

                this.Close();
            }
        }

        /// <summary>
        /// Checks if the entry date already exists,
        /// if so, asks the user if they want to overwrite and returns response
        /// if date doesn't exist, returns true
        /// </summary>
        /// <returns>whether or not an entry should be saved based on another entry having a date, and whether user wants to overwrite</returns>
        private bool shouldSaveEntry()
        {
            if (datesExistingEntries is not null && 
                datesExistingEntries.Contains(dtpWorkoutDate.Value.Date))
            {
                    return DialogResult.Yes ==
                        MessageBox.Show(
                        "This date already contains a workout entry.  Proceeding will overwrite the existing entry.\n\nWoud you like to continue?",
                        "Overwrite Entry?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
            }
            return true;
        }


        /// <summary>
        /// Data validation for each of the form's inputs;
        /// checking if present, valid number, etc
        /// displays an error message denoting issues and returns false if any error is found;
        /// returns true if no errors are found
        /// </summary>
        /// <returns>whether or not the data is valid</returns>
        private bool IsDataValid()
        {
            //Errors to display in message for user to correct
            //Adds a message for each failed validation
            string errors = "";

            //Body Weight Amount
            if (!Validator.IsPresent(txtBodyWeightAmt.Text))
                errors += "'Body weight amount' must be present\n";
            else if (!Validator.IsDecimal(txtBodyWeightAmt.Text) || !Validator.IsNotNegative(Convert.ToDecimal(txtBodyWeightAmt.Text)))
                errors += "'Body weight amount' must be a non-negative number\n";

            //Body Weight Unit
            if (!Validator.IsPresent(cbbBodyWeightUnit.Text))
                errors += "'Body weight unit' must be present\n";
            else if (!Validator.IsValidWeightUnit(cbbBodyWeightUnit.SelectedIndex))
                errors += "'Body weight unit' must be a valid weight unit\n";

            //ExerciseName
            if (!Validator.IsPresent(txtExerciseName.Text))
                errors += "'Exercise name' must be present\n";

            //Set Count
            if (!Validator.IsPresent(txtExerciseSetCt.Text))
                errors += "'Set count' must be present\n";
            else if (!Validator.IsInt(txtExerciseSetCt.Text) || !Validator.IsNotNegative(Convert.ToInt32(txtExerciseSetCt.Text)))
                errors += "'Set count' must be a non-negative integer\n";

            //Rep Count
            if (!Validator.IsPresent(txtExerciseRepCt.Text))
                errors += "'Rep count' must be present\n";
            else if (!Validator.IsInt(txtExerciseRepCt.Text) || !Validator.IsNotNegative(Convert.ToInt32(txtExerciseRepCt.Text)))
                errors += "'Rep count' must be a non-negative integer\n";


            //Set Count
            if (!Validator.IsPresent(txtExerciseExRepCt.Text))
                errors += "'Excess rep count' must be present\n";
            else if (!Validator.IsInt(txtExerciseExRepCt.Text) || !Validator.IsNotNegative(Convert.ToInt32(txtExerciseExRepCt.Text)))
                errors += "'Excess rep count' must be a non-negative integer\n";

            //Exercise Weight Amount
            if (!Validator.IsPresent(txtExerciseWeightAmt.Text))
                errors += "'Exercise weight amount' must be present\n";
            else if (!Validator.IsDecimal(txtExerciseWeightAmt.Text) || !Validator.IsNotNegative(Convert.ToDecimal(txtExerciseWeightAmt.Text)))
                errors += "'Exercise weight amount' must be a non-negative number\n";

            //Exercise Weight Unit
            if (!Validator.IsPresent(cbbExerciseWeightUnit.Text))
                errors += "'Exercise weight unit' must be present\n";
            else if (!Validator.IsValidWeightUnit(cbbExerciseWeightUnit.SelectedIndex))
                errors += "'Exercise weight unit' must be a valid weight unit\n";


            if (errors != String.Empty)
            {
                MessageBox.Show("One or more entries has an error:\n" + errors, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
