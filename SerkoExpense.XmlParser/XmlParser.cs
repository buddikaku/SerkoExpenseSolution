using SerkoExpense.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace SerkoExpense.Parser
{
    /// <summary>
    /// class: XmlParser
    /// </summary>
    public class XmlParser: IParser
    {
        #region Private Variables
        /// <summary>
        /// The text content
        /// </summary>
        private string textContent;
        #endregion

        #region Public Method        

        /// <summary>
        /// Parses the specified text content.
        /// </summary>
        /// <param name="textContent">Content of the text.</param>
        /// <returns>ParserResponse</returns>
        public ParserResponse Parse(string textContent)
        {
            this.textContent = textContent;
            ParserResponse response = new ParserResponse();

            Status parserstatus = Status.None;
            ///if xml is valid
            if (ValidateXml(out parserstatus))
            {
                //extract content
                string xmlContent = ExtractXml();
                //set to extracted data to response
                response.ReservationDTO = GetReservationData(xmlContent);
            }
            ///set the response status
            response.Status = parserstatus;
            return response;
        }
        #endregion

        #region PrivateMethods                
        /// <summary>
        /// Validates the XML.
        /// </summary>
        /// <param name="parserStatus">The parser status.</param>
        /// <returns>true if validation passed, false otherwise</returns>
        private bool ValidateXml(out Status parserStatus)
        {
            return ValidateXmlFormat(Constants.XmlElements.Expense, out parserStatus) &&
                  ValidateXmlFormat(Constants.XmlElements.CostCenter, out parserStatus) &&
                  ValidateXmlFormat(Constants.XmlElements.Total, out parserStatus) &&
                  ValidateXmlFormat(Constants.XmlElements.PaymentMethod, out parserStatus) &&
                  ValidateXmlFormat(Constants.XmlElements.Vendor, out parserStatus) &&
                  ValidateXmlFormat(Constants.XmlElements.Description, out parserStatus) &&
                  ValidateXmlFormat(Constants.XmlElements.Date, out parserStatus) &&
                  ValidateRequired(Constants.XmlElements.Total, out parserStatus) &&
                  ValidateValueFormat(Constants.XmlElements.Total, @"\s*\d+(?:\.\d+)?\s*", out parserStatus);
        }

        /// <summary>
        /// Extracts the XML.
        /// </summary>
        /// <returns>extracted xml element</returns>
        private string ExtractXml()
        {
            StringBuilder xmlContent = new StringBuilder();
            xmlContent.Append(ExtractTag(Constants.XmlElements.CostCenter));
            xmlContent.Append(ExtractTag(Constants.XmlElements.Total));
            xmlContent.Append(ExtractTag(Constants.XmlElements.PaymentMethod));
            xmlContent.Append(ExtractTag(Constants.XmlElements.Vendor));
            xmlContent.Append(ExtractTag(Constants.XmlElements.Description));
            xmlContent.Append(ExtractTag(Constants.XmlElements.Date));

            return xmlContent.ToString();
        }

        /// <summary>
        /// Validates the required.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="validationStatus">The validation status.</param>
        /// <returns>true if success,false otherwise</returns>
        private bool ValidateRequired(string element, out Status validationStatus)
        {
            ///check element exist
            if (Regex.Match(this.textContent, $@"<{element}>").Success)
            {
                validationStatus = Status.Success;
                return true;
            }
            validationStatus = Status.MissingRequired;
            return false;
        }

        /// <summary>
        /// Validates the XML format.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="validationStatus">The validation status.</param>
        /// <returns>true if success,false otherwise</returns>
        private bool ValidateXmlFormat(string element, out Status validationStatus)
        {
            ///if opening tag available 
            if (Regex.Match(this.textContent, $@"<{element}>").Success)
            {
                ///check closing tag available
                if (!Regex.Match(this.textContent, $"<{element}>.*</{element}>", RegexOptions.Singleline).Success)
                {
                    validationStatus = Status.FormattingError;
                    return false;
                }
            }
            validationStatus = Status.Success;
            return true;
        }

        /// <summary>
        /// Validates the value format.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="validationStatus">The validation status.</param>
        /// <returns>true if success,false otherwise</returns>
        private bool ValidateValueFormat(string element, string pattern, out Status validationStatus)
        {
            ///check value matches the expected format
            if (Regex.Match(this.textContent, $"<{element}>{pattern}</{element}>", RegexOptions.Singleline).Success)
            {
                validationStatus = Status.Success;
                return true;
            }
            validationStatus = Status.InvalidValue;
            return false;
        }

        /// <summary>
        /// Extracts the tag.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>extracted element</returns>
        private string ExtractTag(string element)
        {
            return Regex.Match(this.textContent, $"<{element}>.*</{element}>", RegexOptions.Singleline).Value;
        }

        /// <summary>
        /// Gets the reservation data.
        /// </summary>
        /// <param name="xmlContent">Content of the XML.</param>
        /// <returns>ReservationDTO</returns>
        private ReservationDTO GetReservationData(string xmlContent)
        {
            ///append root opening and closing tag
            xmlContent = $"<{Constants.XmlElements.Reservation}>{xmlContent}</{ Constants.XmlElements.Reservation}> ";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ReservationDTO));
            using (StringReader reader = new StringReader(xmlContent))
            {
                return (ReservationDTO)xmlSerializer.Deserialize(reader);
            }
        }
        #endregion
    }
}
