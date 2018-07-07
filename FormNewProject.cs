﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDPFManager
{
    public partial class FormNewProject : Form
    {
        public FormNewProject()
        {
            InitializeComponent();
        }

        public string ProjectName
        {
            get
            {
                return this.textBoxProjectName.Text;
            }
        }

        private void FormNewProject_Load(object sender, EventArgs e)
        {
            this.textBoxProjectName.Text = "NewProject";
            this.textBoxProjectName.SelectAll();
            this.textBoxProjectName.Focus();
        }

    }
}
