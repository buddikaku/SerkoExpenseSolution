using SerkoExpense.Common;
using SerkoExpense.XmlParser;
using System;
using System.Configuration;

namespace SerkoExpense.Business
{
    /// <summary>
    /// Class: ExpenseService 
    /// </summary>
    public class ExpenseService
    {
        #region Public Method

        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <param name="textInput">The text input.</param>
        /// <param name="taxRate">The tax rate.</param>
        /// <returns>ImportResponse</returns>
        public ImportResponse ImportData(string emailInput)
        {
            /// Send the email content to xml parser and extract xml data.
            var parserRespose = new XmlParser.XmlParser(emailInput).Parse();

            /// If XML parsing is failed, return the failed response with error message
            if (parserRespose.Status != Status.Success)
            {
                return new ImportResponse
                {
                    Success = false,
                    Message = GetErrorMessage(parserRespose.Status)
                };
            }

            /// If XML parsing is succeeded, Then return response object with extracted and calculated data.
            double gstRate;
            if (double.TryParse(ConfigurationManager.AppSettings[Constants.AppSettings.Gst], out gstRate))
            {
                return GenerateResponse(parserRespose, gstRate);
            }

            /// Throw new exception when GST rate in not defined or unsupported.
            throw new Exception(Constants.ExceptionMassages.GstRateError);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generates the response.
        /// </summary>
        /// <param name="parserResponse">The parser response.</param>
        /// <param name="gstRate">The GST rate.</param>
        /// <returns>The Response Object</returns>
        private ImportResponse GenerateResponse(ParserResponse parserResponse, double gstRate)
        {
            /// Map response date and return. 
            return new ImportResponse
            {
                Success = true,
                Reservation = new Reservation
                {
                    Date = parserResponse.ReservationDTO.Date.Trim(),
                    Description = parserResponse.ReservationDTO.Description.Trim(),
                    Vendor = parserResponse.ReservationDTO.Vendor.Trim(),
                    Expense = GenerateExpense(parserResponse, gstRate)
                }
            };
        }

        /// <summary>
        /// Generates the expense.
        /// </summary>
        /// <param name="parserResponse">The parser response.</param>
        /// <param name="gstRate">The GST rate.</param>
        /// <returns>The Expense Object</returns>
        private Expense GenerateExpense(ParserResponse parserResponse, double gstRate)
        {
            /// Map expense data and return
            var gst = parserResponse.ReservationDTO.Total * gstRate;
            return new Expense
            {
                CostCenter = parserResponse.ReservationDTO.CostCenter.Trim(),
                GST = gst,
                PaymentMethod = parserResponse.ReservationDTO.PaymentMethod.Trim(),
                Total = parserResponse.ReservationDTO.Total,
                TotalExcludingGST = parserResponse.ReservationDTO.Total - gst,
            };
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="parserRespose">The parser response.</param>
        /// <returns>The Error Message</returns>
        private string GetErrorMessage(Status parserResponse)
        {
            /// Find out corresponding error message. 
            switch (parserResponse)
            {
                case Status.MissingRequired:
                    return Constants.Messages.MissingRequiredError;
                case Status.FormattingError:
                    return Constants.Messages.FormattingError;
                case Status.InvalidValue:
                    return Constants.Messages.InvalidValueError;
                default:
                    return string.Empty;
            }
        }

        #endregion
    }
}
