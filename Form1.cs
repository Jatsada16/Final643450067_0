using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "เสื้อยืดสีดำ")
            {
                textBox1.Text = "250";
            }
            else if (comboBox1.Text == "กางเกงวอมสีดำ")
            {
                textBox1.Text = "200";
            }

            else if (comboBox1.Text == "รองเท่าแตะสีดำ")
            {
                textBox1.Text = "199";
            }

            else if (comboBox1.Text == "กระเป๋าสะพายสีดำ")
            {
                textBox1.Text = "300";
            }
            else if (comboBox1.Text == "หมวกสีขาวดำ")
            {
                textBox1.Text = "100";
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (.csv)|.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string ClassdataRAW = readAllLine[i];
                    string[] ClassdataSplited = ClassdataRAW.Split(',');
                    Classdata classdata = new Classdata(ClassdataSplited[0], ClassdataSplited[1], ClassdataSplited[2], ClassdataSplited[3]);
                    addDataToGridView("name", "amount", "price");
                }
            }
            void addDataToGridView(string name, string amount, string price)
            {
                this.dataGridView1.Rows.Add(new string[] { name, amount, price });
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(.csv)|.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }




            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int D1, D2, all;
            D1 = (int)Convert.ToInt64(textBox1.Text);
            D2 = (int)Convert.ToInt64(textBox2.Text);
            all = D1 * D2;
            textBox3.Text = "" + all;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;

            
        }
    }
}
  
