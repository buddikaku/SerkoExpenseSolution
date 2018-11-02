namespace SerkoExpense.Common
{
    /// <summary>
    /// Class: Reservation
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Gets or sets the vendor.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the expense.
        /// </summary>
        /// <value>
        /// The expense.
        /// </value>
        public Expense Expense { get; set; }
    }
}
