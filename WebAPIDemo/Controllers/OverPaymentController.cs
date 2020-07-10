using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SQLite;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models.Request;

namespace WebAPIDemo.Controllers
{
    public class OverPaymentController : ApiController
    {
        [HttpPost]
        [Route("api/overpayment/post")]
        public void PostOverPaymentDetail(OverPaymentDetailRequest overPaymentDetailRequest)
        {
            var conn = new System.Data.SQLite.SQLiteConnection("data source=C:/Users/colintu/source/repos/WebAPIDemo/OverPaymentDetailsDB.db");
            using (var cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = "INSERT INTO OverPaymentDetails(OverPaymentID, ClaimNumber, MemberId, BalanceAmt, OverPaymentAmt) Values("
                    + overPaymentDetailRequest.OverPyamentID.ToString() + ", " + overPaymentDetailRequest.ClaimNumber.ToString() + ", " + overPaymentDetailRequest.MemberId.ToString() + ", " + overPaymentDetailRequest.BalanceAmt.ToString() + ", " + overPaymentDetailRequest.OverPaymentAmt.ToString() + ")";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
