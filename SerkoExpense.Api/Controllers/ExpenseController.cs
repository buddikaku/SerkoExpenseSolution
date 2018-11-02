using SerkoExpense.Business;
using System.Web.Http;

namespace SerkoExpense.Api.Controllers
{
    /// <summary>
    /// Controller class: ExpenseController
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("Expense")]
    public class ExpenseController : ApiController
    {
        /// <summary>
        /// Imports the data.
        /// </summary>
        /// <param name="emailInput">The email input.</param>
        /// <returns></returns>
        [Route("ImportData")]
        [HttpPost]
        public IHttpActionResult ImportData([FromBody]string emailInput)
        {
            return Ok(new ExpenseService().ImportData(emailInput));
        }
    }
}
