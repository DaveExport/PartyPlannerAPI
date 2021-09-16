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
    public class GuestsController : ApiController
    {
        // GET: api/Guests
        public HttpResponseMessage Get()
        {
            try
            {
                string sql = "GetGuests";

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
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        // GET: api/Guests/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Guests
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Guests/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Guests/5
        public void Delete(int id)
        {
        }
    }
}
