using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartyPlannerAPI.Controllers
{
    public class PartyGuestController : ApiController
    {
        // GET: api/PartyGuest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PartyGuest/5
        [HttpGet]
        public HttpResponseMessage Get(int partyId)
        {
            try
            {
                string sql = "GetPartyGuests";

                DataTable dt = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyPlannerAPIContext"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter
                        {
                            ParameterName = "@PartyID",
                            SqlDbType = SqlDbType.Int,
                            Value = partyId,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                Dictionary<string, DataTable> output = new Dictionary<string, DataTable>();
                output.Add("partyGuests", dt);
                return Request.CreateResponse(HttpStatusCode.OK, output);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST: api/PartyGuest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PartyGuest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PartyGuest/5
        public void Delete(int id)
        {
        }
    }
}
