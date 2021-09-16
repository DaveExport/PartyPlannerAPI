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
    public class PartiesController : ApiController
    {
        // GET: api/Parties
        public HttpResponseMessage Get()
        {
            try
            {
                string sql = "GetParties";

                DataTable dt = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyPlannerAPIContext"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
//                Dictionary<string, DataTable> output = new Dictionary<string, DataTable>();
//                output.Add("parties", dt);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/Parties/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Parties
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Parties/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Parties/5
        public void Delete(int id)
        {
        }
    }
}
