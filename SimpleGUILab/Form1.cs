using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleGUILab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// called when the greetButton is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void greetButton_Click(object sender, EventArgs e)
        {
            // get user input in the text box
            // .Text gets the content.
            string name = nameTextBox.Text;

            // check if the name string is null, empty, or only white space char
            if (string.IsNullOrWhiteSpace(name))
            {
                // If validation fails, display an error message box.
                // MessageBox.Show(message, title, buttons, icon);
                MessageBox.Show
                (
                    "Please enter your name.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // If the input is valid, update the Text property of greetingLabel
            greetingLabel.Text = $"Hello, {name}!";
        }

        private void greetingLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
