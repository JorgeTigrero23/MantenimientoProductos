using System;
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
    public partial class frmSuccess : Form
    {
        public frmSuccess(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        private void frmSuccess_Load(object sender, EventArgs e)
        {
            clarifyForm.ShowAsyc(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void confirmationForm(string message)
        {
            frmSuccess frm = new frmSuccess(message);
            frm.ShowDialog();
        }

    }
}
