using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace lesouchet
{
    public partial class CloseForm : Form
    {
        public CloseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.Assert(ActiveForm != null, "CloseForm.ActiveForm != null");
            ActiveForm.Close();
        }
    }
}
