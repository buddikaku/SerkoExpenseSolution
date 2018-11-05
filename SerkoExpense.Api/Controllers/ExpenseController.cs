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
        #region Private Variables
        /// <summary>
        /// The expense service
        /// </summary>
        private IService expenseService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseController"/> class.
        /// </summary>
        /// <param name="expenseService">The expense service.</param>
        public ExpenseController(IService expenseService)
        {
            this.expenseService = expenseService;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Imports the data.
        /// </summary>
        /// <param name="textContent">Content of the text.</param>
        /// <returns>IHttpActionResult</returns>
        [Route("ImportData")]
        [HttpPost]
        public IHttpActionResult ImportData([FromBody]string textContent)
        {
            /// Invoke service and return response object
            return Ok(this.expenseService.ImportData(textContent));
        }
        #endregion
    }
}
