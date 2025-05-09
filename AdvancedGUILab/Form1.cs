using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdvancedGUILab
{
    public partial class Form1 : Form
    {
        private BindingList<Student> students;

        public Form1()
        {
            InitializeComponent();
            InitializeDataSource();
            SetupDataGridView();
        }

        private void InitializeDataSource()
        {
            students = new BindingList<Student>
            {
            new Student { Name = "Alice", Age = 20, GPA = 3.8 },
            new Student { Name = "Bob", Age = 22, GPA = 3.5 },
            new Student { Name = "Charlie", Age = 21, GPA = 3.9 }

            };
        }

        #region add student logic
        /// <summary>
        /// Add student after name, age, & gpa are filled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addStudentButton_Click(object sender, EventArgs e)
        {
            if (ValidInput(out Student newStudent))
            {
                students.Add(newStudent);
            }
        }

        private bool ValidInput(out Student student)
        {
            student = null;
            string name = nameTextBox.Text;
            string gpaInput = gpaTextBox.Text;
            int age = (int)ageNumericUpDown.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Please enter a student name.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return false;
            }

            // convert the string into a double and check if this !false
            if (!double.TryParse(gpaInput, out double gpa) || !IsValidGpa(gpa))
            {
                MessageBox.Show(
                    $"Please enter a valid GPA between {MIN_GPA:F1} and {MAX_GPA:F1}.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                gpaTextBox.Focus();
                gpaTextBox.SelectAll();
                return false;
            }

            // If all input is !false then an object is created
            student = new Student
            {
                Name = name,
                Age = age,
                GPA = gpa
            };
            return true;
        }

        private double MIN_GPA = 0.0;
        private double MAX_GPA = 4.0;

        /// <summary>
        /// Gpa range validation
        /// </summary>
        /// <param name="gpa"></param>
        /// <returns></returns>
        private bool IsValidGpa(double gpa)
        {
            return gpa >= MIN_GPA && gpa <= MAX_GPA;
        }
        #endregion

        #region data grid logic
        private void SetupDataGridView()
        {

            dataGridViewStudents.DataSource = students;

            dataGridViewStudents.Columns["Name"].Width = 115;
            dataGridViewStudents.Columns["Age"].Width = 50;
            dataGridViewStudents.Columns["GPA"].Width = 50;
            dataGridViewStudents.Columns["GPA"].DefaultCellStyle.Format = "F2";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Confirm Exit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region empty code

        private void CellContent(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void inputTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void studentInfoGroupBox_Enter(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        #endregion

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
