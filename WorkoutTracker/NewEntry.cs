﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkoutTracker
{
    public partial class NewEntry : Form
    {
        private WorkoutEntry woEntry = new();

        public NewEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            woEntry.EntryDate = D;
        }

        private bool isFormValid()
        {


            return true;
        }
    }
}