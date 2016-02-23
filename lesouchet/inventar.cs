using System;
using System.Windows.Forms;

namespace lesouchet
{
    public partial class Inventar : Form
    {
        private Work _workForm;
        
        public Inventar(Work workForm)
        {
            InitializeComponent();
            _workForm = workForm;
        }
        //метод, выполняемый при загрузке формы 
        //метод, выполняемый при нажатии на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            //добавление в таблицу записей из textBox-ов
            _workForm.dataGridView1.Rows.Add(textBox12.Text, comboBox1.Text, textBox2.Text, comboBox5.Text, textBox6.Text, comboBox6.Text, comboBox3.Text, comboBox4.Text, comboBox7.Text, textBox9.Text, textBox10.Text, textBox11.Text);
            ActiveForm.Hide();
          
        }
       
     
        private void inventar_FormClosed(object sender, FormClosedEventArgs e)
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

      
  
   
