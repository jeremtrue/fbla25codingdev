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

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panelNav.Height = btnDashboard.Height;
            panelNav.Top = btnDashboard.Top;
            panelNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnDashboard.Height;
            panelNav.Top = btnDashboard.Top;
            panelNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSpending_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnSpending.Height;
            panelNav.Top = btnSpending.Top;
            panelNav.Left = btnSpending.Left;
            btnSpending.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnStatistics.Height;
            panelNav.Top = btnStatistics.Top;
            panelNav.Left = btnStatistics.Left;
            btnStatistics.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            panelNav.Height = btnSettings.Height;
            panelNav.Top = btnSettings.Top;
            panelNav.Left = btnSettings.Left;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSpending_Leave(object sender, EventArgs e)
        {
            btnSpending.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnStatistics_Leave(object sender, EventArgs e)
        {
            btnStatistics.BackColor = Color.FromArgb(24, 30, 54);
        }
    }
}
