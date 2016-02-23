using System;
using System.Windows.Forms;

namespace lesouchet
{
    public partial class Edit : Form
    {
        private Work _workForm;
        
        public Edit(Work workForm)
        {
            InitializeComponent();
            _workForm = workForm;
        }
        //метод, выполняемый при загрузке формы 
        private void edit_Load(object sender, EventArgs e)
        {

        }
        
        //метод, выполняемый при нажатии на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            var work = new Work();
            int a = work.i;

            _workForm.dataGridView1.Rows[a].Cells[0].Value = textBox12.Text;
            _workForm.dataGridView1.Rows[a].Cells[1].Value = comboBox1.Text;
            _workForm.dataGridView1.Rows[a].Cells[2].Value = textBox2.Text;
            _workForm.dataGridView1.Rows[a].Cells[3].Value = comboBox5.Text;
            _workForm.dataGridView1.Rows[a].Cells[4].Value = textBox6.Text;
            _workForm.dataGridView1.Rows[a].Cells[5].Value = comboBox6.Text;
            _workForm.dataGridView1.Rows[a].Cells[6].Value = comboBox3.Text;
            _workForm.dataGridView1.Rows[a].Cells[7].Value = comboBox4.Text;
            _workForm.dataGridView1.Rows[a].Cells[8].Value = comboBox7.Text;
            _workForm.dataGridView1.Rows[a].Cells[9].Value = textBox9.Text;
            _workForm.dataGridView1.Rows[a].Cells[10].Value = textBox10.Text;
            _workForm.dataGridView1.Rows[a].Cells[11].Value = textBox11.Text;
   
            ActiveForm.Hide();
        }
       
     
        private void edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActiveForm.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            _workForm.Show();
        }

        private void отменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < Controls.Count; i++)
            {
                var c = Controls[i];
                if (c.GetType() == typeof (TextBox))
                    c.Text = string.Empty;
            }
        }
    }
}

      
  
   
