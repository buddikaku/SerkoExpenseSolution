using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerkoExpense.Api.Controllers;
using SerkoExpense.Business;
using SerkoExpense.Common;
using SerkoExpense.Parser;
using System.Web.Http.Results;

namespace SerkoExpense.Api.Test
{
    [TestClass]
    public class ExpenseApiTest
    {
        private ExpenseController expenseController = null;


        [TestInitialize]
        public void TestInitialize()
        {
            IParser parser = new XmlParser();
            IService service = new ExpenseService(parser);
            this.expenseController = new ExpenseController(service);
        }

        [TestMethod]
        public void ImportData_ShouldRejectIfTotalTagIsMissing()
        {
            //missing <total>
            string emailContent = @"Hi Yvaine,
                                Please create an expense claim for the below. Relevant details are marked up as
                                requested…
                                <expense><cost_centre> DEV002 </cost_centre>
                                <payment_method> personal card </payment_method>
                                </expense>
                                From: Ivan Castle
                                Sent: Friday, 16 February 2018 10:32 AM
                                To: Antoine Lloyd < Antoine.Lloyd@example.com >
                                Subject: test
                                Hi Antoine,
                                Please create a reservation at the <vendor> Viaduct Steakhouse </vendor> our
                                <description> development team’s project end celebration dinner </description> on
                                <date> Tuesday 27 April 2017 </date>.We expect to arrive around
                                7.15pm.Approximately 12 people but I’ll confirm exact numbers closer to the day.
                                Regards,
                                Ivan";

            var response = this.expenseController.ImportData(emailContent) as OkNegotiatedContentResult<ImportResponse>;
            Assert.AreEqual(false, response.Content.Success);
            Assert.AreEqual("Required tag missing", response.Content.Message);
        }

        [TestMethod]
        public void ImportData_ShouldRejectIfCorrespondingClosingTagIsMissing()
        {
            //missing </cost_centre>
            string emailContent = @"Hi Yvaine,
                                Please create an expense claim for the below. Relevant details are marked up as
                                requested…
                                <expense><cost_centre> DEV002 
                                <total> 1024.01 </total><payment_method> personal card </payment_method>
                                </expense>
                                From: Ivan Castle
                                Sent: Friday, 16 February 2018 10:32 AM
                                To: Antoine Lloyd < Antoine.Lloyd@example.com >
                                Subject: test
                                Hi Antoine,
                                Please create a reservation at the <vendor> Viaduct Steakhouse </vendor> our
                                <description> development team’s project end celebration dinner </description> on
                                <date> Tuesday 27 April 2017 </date>.We expect to arrive around
                                7.15pm.Approximately 12 people but I’ll confirm exact numbers closer to the day.
                                Regards,
                                Ivan";

            var response = this.expenseController.ImportData(emailContent) as OkNegotiatedContentResult<ImportResponse>;
            Assert.AreEqual(false, response.Content.Success);
            Assert.AreEqual("XML Formatting Error:Opening tag does not have a corresponding closing tag", response.Content.Message);
        }

        [TestMethod]
        public void ImportData_ShouldReciveUnknowForEmptyCostCenter()
        {
            //missing <cost_centre>
            string emailContent = @"Hi Yvaine,
                                Please create an expense claim for the below. Relevant details are marked up as
                                requested…
                                <expense>
                                <total> 1024.01 </total><payment_method> personal card </payment_method>
                                </expense>
                                From: Ivan Castle
                                Sent: Friday, 16 February 2018 10:32 AM
                                To: Antoine Lloyd < Antoine.Lloyd@example.com >
                                Subject: test
                                Hi Antoine,
                                Please create a reservation at the <vendor> Viaduct Steakhouse </vendor> our
                                <description> development team’s project end celebration dinner </description> on
                                <date> Tuesday 27 April 2017 </date>.We expect to arrive around
                                7.15pm.Approximately 12 people but I’ll confirm exact numbers closer to the day.
                                Regards,
                                Ivan";

            var response = this.expenseController.ImportData(emailContent) as OkNegotiatedContentResult<ImportResponse>;
            Assert.AreEqual(true, response.Content.Success);
            Assert.AreEqual("UNKNOWN", response.Content.Reservation.Expense.CostCenter);
        }

        [TestMethod]
        public void ImportData_ShouldReturnExtractedAndCalculatedDataWhenXMLIsValied()
        {
            //Valid XML
            string emailContent = @"Hi Yvaine,
                                Please create an expense claim for the below. Relevant details are marked up as
                                requested…
                                <expense><cost_centre> DEV002 </cost_centre>
                                <total> 1024.01 </total>
                                <payment_method> personal card </payment_method>
                                </expense>
                                From: Ivan Castle
                                Sent: Friday, 16 February 2018 10:32 AM
                                To: Antoine Lloyd < Antoine.Lloyd@example.com >
                                Subject: test
                                Hi Antoine,
                                Please create a reservation at the <vendor> Viaduct Steakhouse </vendor> our
                                <description> development team’s project end celebration dinner </description> on
                                <date> Tuesday 27 April 2017 </date>.We expect to arrive around
                                7.15pm.Approximately 12 people but I’ll confirm exact numbers closer to the day.
                                Regards,
                                Ivan";

            var response = this.expenseController.ImportData(emailContent) as OkNegotiatedContentResult<ImportResponse>;
            Assert.AreEqual(true, response.Content.Success);
            Assert.AreEqual("DEV002", response.Content.Reservation.Expense.CostCenter);
            Assert.AreEqual(1024.01, response.Content.Reservation.Expense.Total);
            Assert.AreEqual(153.6015, response.Content.Reservation.Expense.GST);
            Assert.AreEqual(870.4085, response.Content.Reservation.Expense.TotalExcludingGST);
            Assert.AreEqual("Viaduct Steakhouse", response.Content.Reservation.Vendor);
            Assert.AreEqual("development team’s project end celebration dinner", response.Content.Reservation.Description);
            Assert.AreEqual("Tuesday 27 April 2017", response.Content.Reservation.Date);
        }
    }
}
