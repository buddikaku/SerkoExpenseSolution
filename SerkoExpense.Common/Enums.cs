using System.ComponentModel;

namespace SerkoExpense.Common
{
    public enum Status
    {
        /// <summary>
        /// The none
        /// </summary>
        [Description("None")]
        None,

        /// <summary>
        /// The success
        /// </summary>
        [Description("Success")]
        Success,

        /// <summary>
        /// The missing required
        /// </summary>
        [Description("Required tag missing")]
        MissingRequired,

        /// <summary>
        /// The formatting error
        /// </summary>
        [Description("XML Formatting Error:Opening tag does not have a corresponding closing tag")]
        FormattingError,

        /// <summary>
        /// The invalid value
        /// </summary>
        [Description("Invalid value format")]
        InvalidValue
    }

}
