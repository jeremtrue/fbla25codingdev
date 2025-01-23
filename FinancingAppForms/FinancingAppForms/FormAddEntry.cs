using System;
using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FinancingAppForms
{
    public partial class FormAddEntry : Form
    {
        public FormAddEntry()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Set form properties
            this.Text = "Add New Entry";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;

            // Create labels and input controls
            Label labelAmount = new Label
            {
                Text = "Amount ($):",
                Location = new Point(20, 20),
                AutoSize = true
            };
            TextBox textBoxAmount = new TextBox
            {
                Name = "textBoxAmount",
                Location = new Point(150, 20),
                Width = 200
            };

            Label labelCategory = new Label
            {
                Text = "Category:",
                Location = new Point(20, 60),
                AutoSize = true
            };
            TextBox textBoxCategory = new TextBox
            {
                Name = "textBoxCategory",
                Location = new Point(150, 60),
                Width = 200
            };

            Label labelIsExpense = new Label
            {
                Text = "Is Expense?",
                Location = new Point(20, 100),
                AutoSize = true
            };
            CheckBox checkBoxIsExpense = new CheckBox
            {
                Name = "checkBoxIsExpense",
                Location = new Point(150, 100)
            };

            Label labelDate = new Label
            {
                Text = "Date:",
                Location = new Point(20, 140),
                AutoSize = true
            };
            DateTimePicker dateTimePickerDate = new DateTimePicker
            {
                Name = "dateTimePickerDate",
                Location = new Point(150, 140),
                Width = 200,
                Format = DateTimePickerFormat.Short
            };

            Button buttonSubmit = new Button
            {
                Text = "Submit",
                Location = new Point(150, 200),
                Width = 100
            };
            buttonSubmit.Click += (sender, e) =>
            {
                AddEntryToDatabase(textBoxAmount.Text, textBoxCategory.Text, checkBoxIsExpense.Checked, dateTimePickerDate.Value);
            };

            // Add controls to the form
            this.Controls.Add(labelAmount);
            this.Controls.Add(textBoxAmount);
            this.Controls.Add(labelCategory);
            this.Controls.Add(textBoxCategory);
            this.Controls.Add(labelIsExpense);
            this.Controls.Add(checkBoxIsExpense);
            this.Controls.Add(labelDate);
            this.Controls.Add(dateTimePickerDate);
            this.Controls.Add(buttonSubmit);
        }

        private void AddEntryToDatabase(string amountText, string category, bool isExpense, DateTime date)
        {
            try
            {
                // Retrieve the MongoDB connection string from the environment variable
                var connectionString = "mongodb+srv://jeremtruelove:Jeremy.2008@cluster0.sgvtj.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("MongoDB connection string is not set in the environment variables.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Parse amount
                if (!decimal.TryParse(amountText, out decimal amount))
                {
                    MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // MongoDB connection setup
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("FinancialApp");
                var collection = database.GetCollection<BsonDocument>("Transactions");

                // Determine transaction type
                string transactionType = isExpense ? "Expense" : "Income";

                // Create a document to insert
                var document = new BsonDocument
                {
                    { "Amount", amount },
                    { "Category", category },
                    { "TransactionType", transactionType },
                    { "Date", date }
                };

                // Insert the document into the database
                collection.InsertOne(document);

                // Notify the user
                MessageBox.Show("Entry added to the database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form after successful submission
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAddEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
