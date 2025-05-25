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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Laboratory_2
{
    public partial class HistoryTest : MaterialForm
    {
        public string ReceivedData { get; set; }

        public HistoryTest()
        {
            InitializeComponent();
        }

        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            {
                int score = 5;

                if (!radioButton1.Checked)
                    score--;

                if (!radioButton6.Checked)
                    score--;

                if (!radioButton7.Checked)
                    score--;

                MaterialMessageBox.Show($"Your final score: {score}/5");

                using (StreamWriter writer = new StreamWriter("studentinfo.txt", true))
                {
                    string studentData = $"{ReceivedData}, {score}, Active";

                    writer.WriteLine(studentData);
                }
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
