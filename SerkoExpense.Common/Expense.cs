namespace SerkoExpense.Common
{
    /// <summary>
    /// Class: Expense
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// Gets or sets the cost center.
        /// </summary>
        /// <value>
        /// The cost center.
        /// </value>
        public string CostCenter { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public double Total { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>
        /// The payment method.
        /// </value>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the GST.
        /// </summary>
        /// <value>
        /// The GST.
        /// </value>
        public double GST { get; set; }

        /// <summary>
        /// Gets or sets the total excluding GST.
        /// </summary>
        /// <value>
        /// The total excluding GST.
        /// </value>
        public double TotalExcludingGST { get; set; }
    }
}
