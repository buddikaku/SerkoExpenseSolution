using log4net;
using SerkoExpense.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Filters;

namespace SerkoExpense.Api.Filters
{
    /// <summary>
    /// Class: ExceptionFilter - Custom Exception filter
    /// </summary>
    /// <seealso cref="System.Web.Http.Filters.ExceptionFilterAttribute" />
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Raises the exception event.
        /// </summary>
        /// <param name="actionExecutedContext">The context for the action.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            /// Get exception message.
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }

            /// Log the exception. 
            ILog _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(exceptionMessage, actionExecutedContext.Exception);

            /// Handling the exception and return custom message
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(Constants.ExceptionMassages.GeneralError),
                ReasonPhrase = Constants.ExceptionMassages.DetailGeneralError
            };
            actionExecutedContext.Response = response;
        }
    }
}