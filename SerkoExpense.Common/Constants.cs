namespace SerkoExpense.Common
{
    /// <summary>
    /// Class: Constants
    /// </summary>
    public static class Constants
    {
        #region XmlElements
        /// <summary>
        /// Class: xml Elements
        /// </summary>
        public static class XmlElements
        {
            /// <summary>
            /// The expense
            /// </summary>
            public const string Expense = "expense";

            /// <summary>
            /// The cost center
            /// </summary>
            public const string CostCenter = "cost_centre";

            /// <summary>
            /// The total
            /// </summary>
            public const string Total = "total";

            /// <summary>
            /// The payment method
            /// </summary>
            public const string PaymentMethod = "payment_method";

            /// <summary>
            /// The vendor
            /// </summary>
            public const string Vendor = "vendor";

            /// <summary>
            /// The description
            /// </summary>
            public const string Description = "description";

            /// <summary>
            /// The date
            /// </summary>
            public const string Date = "date";

            /// <summary>
            /// The reservation
            /// </summary>
            public const string Reservation = "reservation";

        }
        #endregion

        #region Messages
        /// <summary>
        /// Messages
        /// </summary>
        public static class Messages
        {
            /// <summary>
            /// The unsupported value
            /// </summary>
            public const string InvalidValueError = "Unsupported value";

            /// <summary>
            /// The missing closing tag
            /// </summary>
            public const string FormattingError = "XML Formatting Error:Opening tag does not have a corresponding closing tag";

            /// <summary>
            /// The missing required tag
            /// </summary>
            public const string MissingRequiredError = "Required tag missing";
        }
        #endregion

        #region ExceptionMassages
        /// <summary>
        /// ExceptionMassages
        /// </summary>
        public static class ExceptionMassages
        {
            /// <summary>
            /// The tax rate error
            /// </summary>
            public const string GstRateError = "GST rate not defined or unsupported";

            /// <summary>
            /// The general error
            /// </summary>
            public const string GeneralError = "Something went wrong...";

            /// <summary>
            /// The detail general error
            /// </summary>
            public const string DetailGeneralError = "Internal Server Error.Please Contact your Administrator.";
        }
        #endregion

        #region AppSettings
        /// <summary>
        /// Class: AppSettings
        /// </summary>
        public static class AppSettings
        {
            /// <summary>
            /// The GST
            /// </summary>
            public const string Gst = "GST";
        }
        #endregion

        #region DefaultValues
        /// <summary>
        /// Class: DefaultValues
        /// </summary>
        public static class DefaultValues
        {
            /// <summary>
            /// The unknown
            /// </summary>
            public const string Unknown = "UNKNOWN";
        }
        #endregion

    }
}
