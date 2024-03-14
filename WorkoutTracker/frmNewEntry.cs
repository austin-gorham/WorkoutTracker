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

        public WorkoutEntry GetNewEntry()
        {
            this.ShowDialog();
            return woEntry;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isDataValid())
            {
                woEntry = new()
                {
                    EntryDate = dtpWorkoutDate.Value,
                    BodyWeight = new WeightAmt(Convert.ToDecimal(txtBodyWeightAmt.Text),
                        (WeightAmt.WeightUnit)cbbBodyWeightUnit.SelectedIndex)
                };


                woEntry.ExerciseEntries.Add(new()
                {
                    Name = txtExerciseName.Text,
                    SetCount = Convert.ToInt32(txtExerciseSetCt.Text),
                    RepCount = Convert.ToInt32(txtExerciseRepCt.Text),
                    ExcessRepCount = Convert.ToInt32(txtExerciseExRepCt.Text),
                    WeightAmount = new WeightAmt(Convert.ToDecimal(txtExerciseWeightAmt.Text),
                        (WeightAmt.WeightUnit)cbbExerciseWeightUnit.SelectedIndex)
                });

                this.Close();
            }
        }



        private bool isDataValid()
        {

            string errors = "";

            if ( !isPresent(txtBodyWeightAmt.Text) )
                errors += "'Body weight amount' must be present\n";
            else if ( !isInt(txtBodyWeightAmt.Text) || !isNotNegative(Convert.ToInt32(txtBodyWeightAmt.Text)) )
                errors += "Body Weight must be a non-negative integer\n";

            if ( !isPresent(cbbBodyWeightUnit.Text) )
                errors += "Body Weight must be present\n";
            else if ( !isValidWeightUnit(cbbBodyWeightUnit.Text) )
                errors += "Body Weight must be a non-negative integer\n";


            return true;
        }

        private bool isPresent(string s) => true;
        private bool isInt(string s) => true;
        private bool isDecimal(string s) => true;
        private bool isNotNegative(int i) => true;
        private bool isNotNegative(decimal d) => true;
        private bool isValidWeightUnit(string s) => true;
    }
}
