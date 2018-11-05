using SerkoExpense.Common;

namespace SerkoExpense.Parser
{
    /// <summary>
    /// Class: ParserResponse
    /// </summary>
    public class ParserResponse
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the reservation dto.
        /// </summary>
        /// <value>
        /// The reservation dto.
        /// </value>
        public ReservationDTO ReservationDTO { get; set; }

    }
}
