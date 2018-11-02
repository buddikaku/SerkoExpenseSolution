using SerkoExpense.Common;
using System.Xml.Serialization;

namespace SerkoExpense.XmlParser
{
    /// <summary>
    /// class: ReservationDataDTO
    /// </summary>
    [XmlRootAttribute("reservation")]
    public class ReservationDTO
    {

        #region Private Property
        private string costCenter; 
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the cost center.
        /// </summary>
        /// <value>
        /// The cost center.
        /// </value>
        [XmlElementAttribute("cost_centre")]
        public string CostCenter
        {
            get
            {
                if (string.IsNullOrEmpty(this.costCenter))
                {
                    this.costCenter = Constants.DefaultValues.Unknown;
                }
                return this.costCenter;
            }
            set { this.costCenter = value; }
        }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        [XmlElementAttribute("total")]
        public double Total { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>
        /// The payment method.
        /// </value>
        [XmlElementAttribute("payment_method")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the vendor.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        [XmlElementAttribute("vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [XmlElementAttribute("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [XmlElementAttribute("date")]
        public string Date { get; set; }

        #endregion
    }
}
