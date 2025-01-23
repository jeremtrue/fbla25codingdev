using MongoDB.Bson;
using MongoDB.Driver;
using System;
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
            // Add code here if you need to handle something when the form loads
        }


        private void panelDataGridView_Paint(object sender, PaintEventArgs e)
        {
            // Remove or comment out if you don't need custom painting for the panel
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
                BackgroundColor = System.Drawing.Color.FromArgb(24, 30, 54), // Dark background color
                ForeColor = System.Drawing.Color.White, // Text color
                Font = new System.Drawing.Font("Apercu Pro", 12, System.Drawing.FontStyle.Regular) // Change font
            };

            // Change column headers style
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Apercu Pro", 12, System.Drawing.FontStyle.Bold);
            dataGridView.EnableHeadersVisualStyles = false; // Disable default theme styling

            // Change row background color
            dataGridView.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(34, 40, 60);
            dataGridView.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(75, 83, 135); // Selected row color
            dataGridView.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

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
            var connectionString = "mongodb+srv://jeremtruelove:Jeremy.2008@cluster0.sgvtj.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            var client = new MongoClient(connectionString); // Replace with your MongoDB connection string
            var database = client.GetDatabase("FinancialApp"); // Replace with your database name
            var collection = database.GetCollection<BsonDocument>("Transactions"); // Replace with your collection name

            var filter = Builders<BsonDocument>.Filter.Empty; // Get all documents
            var transactions = collection.Find(filter).ToList();

            foreach (var transaction in transactions)
            {
                decimal amount = 0;

                // Check if the 'Amount' field is Decimal128 and convert accordingly
                var amountValue = transaction.GetValue("Amount");
                if (amountValue.IsDecimal128)
                {
                    Decimal128 decimalAmount = amountValue.ToDecimal128(); // Get the Decimal128 value
                    amount = (decimal)decimalAmount; // Convert to decimal directly
                }
                else
                {
                    amount = 0; // Handle if the value is not Decimal128 (fallback)
                }

                string category = transaction.GetValue("Category").AsString;
                string transactionType = transaction.GetValue("TransactionType").AsString;
                DateTime date = transaction.GetValue("Date").ToUniversalTime();

                // Add the data to the DataGridView
                dataGridView.Rows.Add(amount, category, transactionType == "Expense", date);
            }
        }

        private void addbutt_Click(object sender, EventArgs e)
        {
            // Open the FormAddEntry as a dialog
            FormAddEntry addEntryForm = new FormAddEntry();
            addEntryForm.ShowDialog();
        }

    }
}
