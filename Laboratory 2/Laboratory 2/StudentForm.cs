using MaterialSkin.Controls;
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
using System.Xml.Linq;
using UniversitySystem;

namespace Laboratory_2
{
    public partial class StudentForm : MaterialForm
    {
        public string studentData {  get; set; }

        public StudentForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string age = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }
                string gender = radioButton1.Checked ? "Male" : (radioButton2.Checked ? "Female" : "Not selected");

                string faculty = radioButton3.Checked ? "Mathematics" : (radioButton4.Checked ? "History" : "Not selected");

                string studentData = $"{name}, {gender}, {age}, {faculty}";
        

            if (radioButton3.Checked)
            {
                 MathTest mh = new MathTest();
                 mh.ReceivedData = studentData; 
                 mh.Show();
            }
            else if (radioButton4.Checked)
            {
                HistoryTest th = new HistoryTest();
                th.ReceivedData = studentData;
                th.Show();
            }
            else
            {
                MessageBox.Show("Please choose a Faculty");
            }

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string age = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }
            string gender = radioButton1.Checked ? "Male" : (radioButton2.Checked ? "Female" : "Not selected");

            string faculty = radioButton3.Checked ? "Mathematics" : (radioButton4.Checked ? "History" : "Not selected");

            string studentData = $"{name}, {gender}, {age}, {faculty}";


            if (radioButton3.Checked)
            {
                MathTest mh = new MathTest();
                mh.ReceivedData = studentData;
                mh.Show();
            }
            else if (radioButton4.Checked)
            {
                HistoryTest th = new HistoryTest();
                th.ReceivedData = studentData;
                th.Show();
            }
            else
            {
                MessageBox.Show("Please choose a Faculty");
            }

            this.Close();
        }
    }
}
