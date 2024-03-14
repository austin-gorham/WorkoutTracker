namespace WorkoutTracker
{
    partial class frmNewEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBodyWeightAmt = new TextBox();
            cbbBodyWeightUnit = new ComboBox();
            dtpWorkoutDate = new DateTimePicker();
            txtExerciseName = new TextBox();
            cbbExerciseWeightUnit = new ComboBox();
            txtExerciseWeightAmt = new TextBox();
            txtExerciseSetCt = new TextBox();
            txtExerciseRepCt = new TextBox();
            txtExerciseExRepCt = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtBodyWeightAmt
            // 
            txtBodyWeightAmt.Location = new Point(63, 41);
            txtBodyWeightAmt.Name = "txtBodyWeightAmt";
            txtBodyWeightAmt.Size = new Size(55, 23);
            txtBodyWeightAmt.TabIndex = 1;
            // 
            // cbbBodyWeightUnit
            // 
            cbbBodyWeightUnit.FormattingEnabled = true;
            cbbBodyWeightUnit.Location = new Point(124, 41);
            cbbBodyWeightUnit.Name = "cbbBodyWeightUnit";
            cbbBodyWeightUnit.Size = new Size(53, 23);
            cbbBodyWeightUnit.TabIndex = 2;
            // 
            // dtpWorkoutDate
            // 
            dtpWorkoutDate.Location = new Point(12, 12);
            dtpWorkoutDate.Name = "dtpWorkoutDate";
            dtpWorkoutDate.Size = new Size(200, 23);
            dtpWorkoutDate.TabIndex = 3;
            // 
            // txtExerciseName
            // 
            txtExerciseName.Location = new Point(63, 118);
            txtExerciseName.Name = "txtExerciseName";
            txtExerciseName.Size = new Size(106, 23);
            txtExerciseName.TabIndex = 4;
            // 
            // cbbExerciseWeightUnit
            // 
            cbbExerciseWeightUnit.FormattingEnabled = true;
            cbbExerciseWeightUnit.Location = new Point(116, 176);
            cbbExerciseWeightUnit.Name = "cbbExerciseWeightUnit";
            cbbExerciseWeightUnit.Size = new Size(53, 23);
            cbbExerciseWeightUnit.TabIndex = 8;
            // 
            // txtExerciseWeightAmt
            // 
            txtExerciseWeightAmt.Location = new Point(63, 176);
            txtExerciseWeightAmt.Name = "txtExerciseWeightAmt";
            txtExerciseWeightAmt.Size = new Size(47, 23);
            txtExerciseWeightAmt.TabIndex = 7;
            // 
            // txtExerciseSetCt
            // 
            txtExerciseSetCt.Location = new Point(63, 147);
            txtExerciseSetCt.Name = "txtExerciseSetCt";
            txtExerciseSetCt.Size = new Size(31, 23);
            txtExerciseSetCt.TabIndex = 9;
            // 
            // txtExerciseRepCt
            // 
            txtExerciseRepCt.Location = new Point(100, 147);
            txtExerciseRepCt.Name = "txtExerciseRepCt";
            txtExerciseRepCt.Size = new Size(31, 23);
            txtExerciseRepCt.TabIndex = 10;
            // 
            // txtExerciseExRepCt
            // 
            txtExerciseExRepCt.Location = new Point(137, 148);
            txtExerciseExRepCt.Name = "txtExerciseExRepCt";
            txtExerciseExRepCt.Size = new Size(31, 23);
            txtExerciseExRepCt.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(19, 234);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(137, 234);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewEntry
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(240, 294);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtExerciseExRepCt);
            Controls.Add(txtExerciseRepCt);
            Controls.Add(txtExerciseSetCt);
            Controls.Add(cbbExerciseWeightUnit);
            Controls.Add(txtExerciseWeightAmt);
            Controls.Add(txtExerciseName);
            Controls.Add(dtpWorkoutDate);
            Controls.Add(cbbBodyWeightUnit);
            Controls.Add(txtBodyWeightAmt);
            Name = "NewEntry";
            Text = "NewEntry";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBodyWeightAmt;
        private ComboBox cbbBodyWeightUnit;
        private DateTimePicker dtpWorkoutDate;
        private TextBox txtExerciseName;
        private ComboBox cbbExerciseWeightUnit;
        private TextBox txtExerciseWeightAmt;
        private TextBox txtExerciseSetCt;
        private TextBox txtExerciseRepCt;
        private TextBox txtExerciseExRepCt;
        private Button btnSave;
        private Button btnCancel;
    }
}