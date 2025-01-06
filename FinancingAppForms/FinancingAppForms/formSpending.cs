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
    public partial class formSpending : Form
    {
        private DataGridView dataGridView;

        public formSpending()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }

        private void formSpending_Load(object sender, EventArgs e)
        {

        }
        private void SetupDataGridView()
        {
            // Initialize the DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill, // Make it fill the panel
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Adjust column width
                AllowUserToAddRows = false, // Disable manual row addition
                RowHeadersVisible = false,
                BackgroundColor = Color.FromArgb(24, 30, 54), // Dark background color
                ForeColor = Color.White, // Text color
                Font = new Font("Apercu Pro", 12, FontStyle.Regular) // Change font
            };

            // Change column headers style
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Apercu Pro", 12, FontStyle.Bold);
            dataGridView.EnableHeadersVisualStyles = false; // Disable default theme styling

            // Change row background color
            dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 40, 60);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(75, 83, 135); // Selected row color
            dataGridView.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Add columns
            dataGridView.Columns.Add("Amount", "Amount ($)");
            dataGridView.Columns["Amount"].ValueType = typeof(decimal);

            dataGridView.Columns.Add("Category", "Category");
            dataGridView.Columns["Category"].ValueType = typeof(string);

            // Boolean checkbox column for Expense (true = Expense, false = Payment)
            DataGridViewCheckBoxColumn expenseColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Expense",
                HeaderText = "Expense?",
                ValueType = typeof(bool),
                TrueValue = true,
                FalseValue = false
            };
            dataGridView.Columns.Add(expenseColumn);

            // Date column
            dataGridView.Columns.Add("Date", "Date");
            dataGridView.Columns["Date"].ValueType = typeof(DateTime);
            dataGridView.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy"; // Format date/time

            // Add DataGridView to the existing panel
            panelDataGridView.Controls.Clear(); // Clear any existing controls
            panelDataGridView.Controls.Add(dataGridView);
        }

        private void LoadData()
        {

            // ADD FEATURE LATER THAT LISTENS TO CHANGES IN DATAGRIDVIEWER AND APPLIES THOSE TO THE DATABASE


            // Sample data to test
            dataGridView.Rows.Add(100.00, "Groceries", true, DateTime.Now);
            dataGridView.Rows.Add(250.50, "Salary", false, DateTime.Now.AddDays(-1));
            dataGridView.Rows.Add(50.75, "Transportation", true, DateTime.Now.AddDays(-3));
            dataGridView.Rows.Add(300.00, "Freelance", false, DateTime.Now.AddDays(-7));
            dataGridView.Rows.Add(100.00, "Groceries", true, DateTime.Now);
            dataGridView.Rows.Add(250.50, "Salary", false, DateTime.Now.AddDays(-1));
            dataGridView.Rows.Add(50.75, "Transportation", true, DateTime.Now.AddDays(-3));
            dataGridView.Rows.Add(300.00, "Freelance", false, DateTime.Now.AddDays(-7));
            dataGridView.Rows.Add(100.00, "Groceries", true, DateTime.Now);
            dataGridView.Rows.Add(250.50, "Salary", false, DateTime.Now.AddDays(-1));
            dataGridView.Rows.Add(50.75, "Transportation", true, DateTime.Now.AddDays(-3));
            dataGridView.Rows.Add(300.00, "Freelance", false, DateTime.Now.AddDays(-7));
            dataGridView.Rows.Add(100.00, "Groceries", true, DateTime.Now);
            dataGridView.Rows.Add(250.50, "Salary", false, DateTime.Now.AddDays(-1));
            dataGridView.Rows.Add(50.75, "Transportation", true, DateTime.Now.AddDays(-3));
            dataGridView.Rows.Add(300.00, "Freelance", false, DateTime.Now.AddDays(-7));
            dataGridView.Rows.Add(100.00, "Groceries", true, DateTime.Now);
            dataGridView.Rows.Add(250.50, "Salary", false, DateTime.Now.AddDays(-1));
            dataGridView.Rows.Add(50.75, "Transportation", true, DateTime.Now.AddDays(-3));
            dataGridView.Rows.Add(300.00, "Freelance", false, DateTime.Now.AddDays(-7));
        }
    }
}
