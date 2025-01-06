using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FinancingAppForms
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

        );

        private Form activeForm = null;

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panelNav.Height = btnDashboard.Height;
            panelNav.Top = btnDashboard.Top;
            panelNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Dashboard";
            this.panelFormLoader.Controls.Clear();
            formDashboard formDashboard_Vrb = new formDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            formDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.panelFormLoader.Controls.Add(formDashboard_Vrb);
            formDashboard_Vrb.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void ActivateButton(Button activeButton)
        {
            // reset all button colors before setting the active one
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnSpending.BackColor = Color.FromArgb(24, 30, 54);
            btnStatistics.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);

            // set the selected button color
            activeButton.BackColor = Color.FromArgb(46, 51, 73);

            // adjust navigation panel
            panelNav.Height = activeButton.Height;
            panelNav.Top = activeButton.Top;
            panelNav.Left = activeButton.Left;
        }

        private void OpenForm(Form newForm)
        {
            // dispose of the previous form if it exists
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            // set the new active form
            activeForm = newForm;
            activeForm.TopLevel = false;
            activeForm.Dock = DockStyle.Fill;
            activeForm.FormBorderStyle = FormBorderStyle.None;

            // load the new form
            panelFormLoader.Controls.Clear();
            panelFormLoader.Controls.Add(activeForm);
            activeForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Dashboard";

            ActivateButton(btnDashboard);

            OpenForm(new formDashboard());
        }

        private void btnSpending_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Spending";

            ActivateButton(btnSpending);

            OpenForm(new formSpending());
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Statistics";

            ActivateButton(btnStatistics);

            OpenForm(new formStatistics());
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Settings";

            ActivateButton(btnSettings);

            OpenForm(new formSettings());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
