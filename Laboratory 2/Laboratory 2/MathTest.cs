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
    public partial class MathTest : MaterialForm
    {
        public string ReceivedData { get; set; }

        public MathTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score = 5; 

            if (!radioButton1.Checked) 
                score--;

            if (!radioButton6.Checked) 
                score--;

            if (!radioButton7.Checked) 
                score--;

            MessageBox.Show($"Your final score: {score}/5");
            using (StreamWriter writer = new StreamWriter("studentinfo.txt", true))
            {
                string studentData = $"{ReceivedData}, {score}, Active";

                writer.WriteLine(studentData);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int score = 5;

            if (!radioButton1.Checked)
                score--;

            if (!radioButton6.Checked)
                score--;

            if (!radioButton7.Checked)
                score--;

            MessageBox.Show($"Your final score: {score}/5");
            using (StreamWriter writer = new StreamWriter("studentinfo.txt", true))
            {
                string studentData = $"{ReceivedData}, {score}, Active";

                writer.WriteLine(studentData);
            }
            this.Close();
        }
    }
}
