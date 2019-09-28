﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmInformation : Form
    {
        public frmInformation(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        private void frmInformation_Load(object sender, EventArgs e)
        {
            clarifyForm.ShowAsyc(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
