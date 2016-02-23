using System;
using System.Windows.Forms;

namespace lesouchet
{
    public partial class BeginProg : Form
    {
       
        public BeginProg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var work = new Work();
            if (ActiveForm != null) ActiveForm.Hide();
            work.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var close = new CloseForm();
            close.Show();
        }
    }
}
