using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MaterialSkin.Controls;

namespace Laboratory_2
{
    public partial class ProfesorForm : MaterialForm
    {
        public ProfesorForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadStudents()
        {
            dataGridView1.Rows.Clear();
            if (!File.Exists("studentinfo.txt")) return;

            string[] lines = File.ReadAllLines("studentinfo.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 6)
                {
                        string name = parts[0].Trim();
                        string gender = parts[1].Trim();
                        string age = parts[2].Trim();
                        string faculty = parts[3].Trim();
                        string grade = parts[4].Trim();
                        string status = parts[5].Trim();


                        if (status.ToLower() == "expelled") status = "Expelled";
                        else status = "Active";

                        dataGridView1.Rows.Add(name, gender, age, faculty, grade, status);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string selectedName = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                string[] lines = File.ReadAllLines("studentinfo.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length < 5) continue;

                    if (parts[0].Trim() == selectedName)
                    {
                        parts[5] = (parts[5].Trim().ToLower() == "expelled") ? "Active" : "Expelled";
                        lines[i] = string.Join(",", parts);
                        break;
                    }
                }

                File.WriteAllLines("studentinfo.txt", lines);
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Select a student!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void ProfesorForm_Load_1(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

