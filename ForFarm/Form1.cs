using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForFarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point lastPoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            string log;
            log = comboBox1.Text;
            Clipboard.SetText(log);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText("-window -w 640 -h 480 -nosound -novid");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText("connect 94.249.140.10:27015");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Process iStartProcess = new Process();
            iStartProcess.StartInfo.FileName = @"D:\Steam\steam.exe";
            iStartProcess.StartInfo.Arguments = "krezeroferm KF2303@@123456";
            iStartProcess.Start();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string nameFile;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nameFile = openFileDialog1.FileName;
                using (StreamReader streamReader = new StreamReader(nameFile, false))
                {
                    string line;
                    int index = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] templine = line.Split();
                        dataGridView1.Rows.Add();
                        dataGridView1[0, index].Value = templine[0];
                        dataGridView1[1, index].Value = templine[1];
                        index++;
                        comboBox1.Items.Add(templine[0]);
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for(int j=0;j<dataGridView1.Rows.Count;j++)
            {
                if(dataGridView1[0,j].Value.ToString() == comboBox1.Text)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(dataGridView1[1,j].Value.ToString());
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                int i = Convert.ToInt32(comboBox1.SelectedIndex);
                if (i == -1)
                {
                    i = 0;
                    comboBox1.Text = comboBox1.Items[i].ToString();
                    i++;
                }
                else
                {
                    i++;
                    try
                    {
                        comboBox1.Text = comboBox1.Items[i].ToString();
                    }
                    catch
                    {
                        i = 0;
                        comboBox1.Text = comboBox1.Items[i].ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Тупорылый,загрузи данные");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = Color.White;
            dataGridView1.Rows.Clear();
            string nameFile = @"I:\logAndPas.txt";
            using (StreamReader streamReader = new StreamReader(nameFile, false))
            {
                string line;
                int index = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] templine = line.Split();
                    dataGridView1.Rows.Add();
                    dataGridView1[0, index].Value = templine[0];
                    dataGridView1[1, index].Value = templine[1];
                    index++;
                    comboBox1.Items.Add(templine[0]);
                }
            }
        }
    }
}
