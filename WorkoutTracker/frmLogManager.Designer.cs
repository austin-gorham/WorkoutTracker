
namespace WorkoutTracker
{
    partial class frmLogManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstExerciseLog = new ListBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lstExerciseLog
            // 
            lstExerciseLog.FormattingEnabled = true;
            lstExerciseLog.ItemHeight = 15;
            lstExerciseLog.Location = new Point(54, 52);
            lstExerciseLog.Name = "lstExerciseLog";
            lstExerciseLog.Size = new Size(262, 349);
            lstExerciseLog.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(377, 130);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add New";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(377, 177);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(377, 223);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmLogManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lstExerciseLog);
            Name = "frmLogManager";
            Text = "Exercise Log Manager";
            Load += frmLogManager_Load;
            ResumeLayout(false);
        }



        #endregion

        private ListBox lstExerciseLog;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}
