using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancingAppForms
{
    public partial class formDashboard : Form
    {
        public formDashboard()
        {
            InitializeComponent();
            UpdateDashboard();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            // This will run when the form is loaded, we can use this to call UpdateDashboard if needed
        }

        private void UpdateDashboard()
        {
            var connectionString = "mongodb+srv://jeremtruelove:Jeremy.2008@cluster0.sgvtj.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FinancialApp"); // Replace with your database name
            var collection = database.GetCollection<BsonDocument>("Transactions"); // Replace with your collection name

            var filter = Builders<BsonDocument>.Filter.Empty; // Get all documents
            var transactions = collection.Find(filter).ToList();

            decimal monthlyExpenses = 0;
            decimal monthlyEarnings = 0;

            // Get the start of the current month and current date (use local time if needed)
            DateTime currentMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime currentDate = DateTime.Now;

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

                string transactionType = transaction.GetValue("TransactionType").AsString;
                DateTime date = transaction.GetValue("Date").ToUniversalTime(); // Ensure we get UTC time

                // Convert the date to local time
                DateTime localDate = date.ToLocalTime(); // Convert from UTC to local time

                // Debug: Log the transaction details to the console
                Console.WriteLine($"Transaction: Amount = {amount}, Type = {transactionType}, Date = {localDate.ToString("MM/dd/yyyy")}");

                // Check if the transaction is within the current month (compare using local date)
                if (localDate >= currentMonthStart && localDate <= currentDate)
                {
                    if (!string.IsNullOrEmpty(transactionType))
                    {
                        transactionType = transactionType.Trim(); // Remove any unwanted spaces

                        if (transactionType.Equals("Expense", StringComparison.OrdinalIgnoreCase))
                        {
                            monthlyExpenses += amount; // Add to monthly expenses if it's an expense
                        }
                        else if (transactionType.Equals("Income", StringComparison.OrdinalIgnoreCase))
                        {
                            monthlyEarnings += amount; // Add to monthly earnings if income
                        }
                    }
                }
            }

            // Calculate the account balance as the difference between earnings and expenses
            decimal accountBalance = monthlyEarnings - monthlyExpenses;

            // Debug: Log the calculated values
            Console.WriteLine($"Monthly Expenses: {monthlyExpenses}, Monthly Earnings: {monthlyEarnings}, Account Balance: {accountBalance}");

            // Update the labels with the calculated values
            labelMonthlyExpenses.Text = $"${monthlyExpenses:F2}"; // Format as currency
            labelEarnedThisMonth.Text = $"${monthlyEarnings:F2}"; // Format as currency
            labelAccountBalance.Text = $"${accountBalance:F2}"; // Format as currency
        }
    }
}
