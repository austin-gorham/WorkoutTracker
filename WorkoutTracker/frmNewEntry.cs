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
        private WorkoutEntry woEntry = null!;

        public frmNewEntry()
        {
            InitializeComponent();
        }

        private void frmNewEntry_Load(object sender, EventArgs e)
        {
            foreach (WeightUnit wu in Enum.GetValues(typeof(WeightUnit)))
            {
                cbbBodyWeightUnit.Items.Add(wu.ToString().ToLower());
                cbbExerciseWeightUnit.Items.Add(wu.ToString().ToLower());
            }
        }

        public WorkoutEntry GetNewEntry()
        {
            this.ShowDialog();
            return woEntry;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsDataValid())
            {
                woEntry = new()
                {
                    EntryDate = dtpWorkoutDate.Value,
                    BodyWeight = new WeightAmt(Convert.ToDecimal(txtBodyWeightAmt.Text),
                        (WeightUnit)cbbBodyWeightUnit.SelectedIndex)
                };


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



        private bool IsDataValid()
        {

            string errors = "";

            //Body Weight Amount
            if (!IsPresent(txtBodyWeightAmt.Text))
                errors += "'Body weight amount' must be present\n";
            else if (!IsDecimal(txtBodyWeightAmt.Text) || !IsNotNegative(Convert.ToDecimal(txtBodyWeightAmt.Text)))
                errors += "'Body weight amount' must be a non-negative number\n";

            //Body Weight Unit
            if (!IsPresent(cbbBodyWeightUnit.Text))
                errors += "'Body weight unit' must be present\n";
            else if (!IsValidWeightUnit(cbbBodyWeightUnit.SelectedIndex))
                errors += "'Body weight unit' must be a valid weight unit\n";

            //ExerciseName
            if (!IsPresent(txtExerciseName.Text))
                errors += "'Exercise name' must be present\n";

            //Set Count
            if (!IsPresent(txtExerciseSetCt.Text))
                errors += "'Set count' must be present\n";
            else if (!IsInt(txtExerciseSetCt.Text) || !IsNotNegative(Convert.ToInt32(txtExerciseSetCt.Text)))
                errors += "'Set count' must be a non-negative integer\n";

            //Rep Count
            if (!IsPresent(txtExerciseRepCt.Text))
                errors += "'Rep count' must be present\n";
            else if (!IsInt(txtExerciseRepCt.Text) || !IsNotNegative(Convert.ToInt32(txtExerciseRepCt.Text)))
                errors += "'Rep count' must be a non-negative integer\n";


            //Set Count
            if (!IsPresent(txtExerciseExRepCt.Text))
                errors += "'Excess rep count' must be present\n";
            else if (!IsInt(txtExerciseExRepCt.Text) || !IsNotNegative(Convert.ToInt32(txtExerciseExRepCt.Text)))
                errors += "'Excess rep count' must be a non-negative integer\n";

            //Exercise Weight Amount
            if (!IsPresent(txtExerciseWeightAmt.Text))
                errors += "'Exercise weight amount' must be present\n";
            else if (!IsDecimal(txtExerciseWeightAmt.Text) || !IsNotNegative(Convert.ToDecimal(txtExerciseWeightAmt.Text)))
                errors += "'Exercise weight amount' must be a non-negative number\n";

            //Exercise Weight Unit
            if (!IsPresent(cbbExerciseWeightUnit.Text))
                errors += "'Exercise weight unit' must be present\n";
            else if (!IsValidWeightUnit(cbbExerciseWeightUnit.SelectedIndex))
                errors += "'Exercise weight unit' must be a valid weight unit\n";


            if (errors != String.Empty)
            {
                MessageBox.Show("One or more entries has an error:\n" + errors, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private static bool IsPresent(string s) => s != String.Empty;
        private static bool IsInt(string s) => Int32.TryParse(s, out _);
        private static bool IsDecimal(string s) => Decimal.TryParse(s, out _);
        private static bool IsNotNegative(int i) => i >= 0;
        private static bool IsNotNegative(decimal d) => d >= 0;
        private static bool IsValidWeightUnit(int i) => Enum.IsDefined(typeof(WeightUnit), (WeightUnit)i);


    }
}
