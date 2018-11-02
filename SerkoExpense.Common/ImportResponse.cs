namespace SerkoExpense.Common
{
    /// <summary>
    /// Class: ImportResponse
    /// Returning object from API service 
    /// </summary>
    public class ImportResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether import is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the reservation.
        /// </summary>
        /// <value>
        /// The reservation.
        /// </value>
        public Reservation Reservation { get; set; }
    }
}
