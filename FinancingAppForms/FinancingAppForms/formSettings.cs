using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancingAppForms
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
        }

        private void checkDark_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDark.Checked)
            {
                // Switch to Dark Mode
                this.BackColor = Color.FromArgb(24, 30, 54); // Dark background color
                label5.ForeColor = Color.White; // Change label text color to white
                // Change other controls to suit dark mode
                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        control.BackColor = Color.FromArgb(46, 51, 73);
                        control.ForeColor = Color.White;
                    }
                    else if (control is TextBox)
                    {
                        control.BackColor = Color.FromArgb(34, 40, 60);
                        control.ForeColor = Color.White;
                    }
                    else if (control is Label)
                    {
                        control.ForeColor = Color.White;
                    }
                    // Add other control types as needed
                }
            }
            else
            {
                // Switch to Light Mode
                this.BackColor = Color.White; // Light background color
                label5.ForeColor = Color.Black; // Change label text color to black
                // Change other controls to suit light mode
                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        control.BackColor = SystemColors.Control;
                        control.ForeColor = Color.Black;
                    }
                    else if (control is TextBox)
                    {
                        control.BackColor = Color.White;
                        control.ForeColor = Color.Black;
                    }
                    else if (control is Label)
                    {
                        control.ForeColor = Color.Black;
                    }
                    // Add other control types as needed
                }
            }
        }
    }
}
