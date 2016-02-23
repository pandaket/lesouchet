using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace lesouchet
{
    public partial class Work : Form
    {
       //инициализация формы
        public Work()
        {
            InitializeComponent();
        }
        
        //пункт меню выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var close = new CloseForm();
            close.Show();
        }
        
        private void новаяТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void новаяЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var inventar = new Inventar(this);
            inventar.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inventar = new Inventar(this);
            inventar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //подключение Microsoft Office Excel к проекту
            var forestExl = new Microsoft.Office.Interop.Excel.Application();
            //создание новой книги Excel, в которой в отдельных листах хранятся таблицы
            Workbook forestWb;
            //определяет стиль ссылки на Excel
            XlReferenceStyle refStyle = forestExl.ReferenceStyle;
            forestExl.Visible = true;

            //путь к шаблону книги Excel, по которой будут заполнятся таблицы
            String forestAccountPath = System.Windows.Forms.Application.StartupPath + @"\Forestry.xlsx";
            try
            {
                //открывается книга по заданному адресу
                forestWb = forestExl.Workbooks.Add(forestAccountPath);
            }
            //в случае ошибки
            catch (Exception ex)
            {
                //вывод сообщения об ошибке
                throw new Exception("Не удалось загрузить шаблон для экспорта " + forestAccountPath + "\n" + ex.Message);
            }
            //Таблица.
            Worksheet forestws = forestWb.Worksheets.Item[1] as Worksheet;
            //заполнение таблицы Excel из данных таблицы из окна dataGridView1, заполненной ранее пользователем
            for (int j = 0; j < dataGridView1.Columns.Count; ++j)
            {
                (forestws.Cells[1, j + 1] as Range).Value2 = dataGridView1.Columns[j].HeaderText;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    object Val = dataGridView1.Rows[i].Cells[j].Value;
                    if (Val != null)
                        (forestws.Cells[i + 2, j + 1] as Range).Value2 = Val.ToString();
                }
            }
            forestws.Columns.EntireColumn.AutoFit();
            forestExl.ReferenceStyle = refStyle;

        }

        private int _i;
        public int i { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            var _edit = new Edit(this);
            _i = dataGridView1.CurrentCell.RowIndex;

            _edit.textBox12.Text = (dataGridView1.Rows[_i].Cells[0].Value ?? "").ToString();
            _edit.comboBox1.Text = dataGridView1.Rows[_i].Cells[1].Value.ToString();
            _edit.textBox2.Text = dataGridView1.Rows[_i].Cells[2].Value.ToString();
            _edit.comboBox5.Text = dataGridView1.Rows[_i].Cells[3].Value.ToString();
            _edit.textBox6.Text = dataGridView1.Rows[_i].Cells[4].Value.ToString();
            _edit.comboBox6.Text = dataGridView1.Rows[_i].Cells[5].Value.ToString();
            _edit.comboBox3.Text = dataGridView1.Rows[_i].Cells[6].Value.ToString();
            _edit.comboBox4.Text = dataGridView1.Rows[_i].Cells[7].Value.ToString();
            _edit.comboBox7.Text = dataGridView1.Rows[_i].Cells[8].Value.ToString();
            _edit.textBox9.Text = dataGridView1.Rows[_i].Cells[9].Value.ToString();
            _edit.textBox10.Text = dataGridView1.Rows[_i].Cells[10].Value.ToString();
            _edit.textBox11.Text = dataGridView1.Rows[_i].Cells[11].Value.ToString();

            _edit.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Файл Excel|*.XLSX;*.XLS";
            openDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\Таблицы инвентаризации";
            openDialog.ShowDialog();
            var ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                var ObjWorkBook = ObjExcel.Workbooks.Open(openDialog.FileName);
                var ObjWorkSheet = ObjExcel.ActiveSheet as Worksheet;
                Range rg = null;
 
            try
            {
                Int32 row = 2;
                dataGridView1.Rows.Clear();
                List<String> arr = new List<string>();
                while (ObjWorkSheet.get_Range("a" + row, "a" + row).Value != null)
                {
                    rg = ObjWorkSheet.get_Range("a" + row, "u" + row);
                    foreach (Range item in rg)
                    {
                        try
                        {
                            arr.Add(item.Value.ToString().Trim());
                        }
                        catch { arr.Add(""); }
                    }
                    dataGridView1.Rows.Add(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8].Clone(), arr[9], arr[10], arr[11]);
                    arr.Clear();
                    row++;
                }
                MessageBox.Show("Файл успешно считан!", "Считывание файла", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message, "Ошибка при считывании excel файла", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            {
 
                ObjWorkBook.Close(false, "", null);
                ObjExcel.Quit();
            }
        }

        private void Work_FormClosing(object sender, FormClosingEventArgs e)
        {
            var beginProg = new BeginProg();
            beginProg.Show();
        }

        }
    }

