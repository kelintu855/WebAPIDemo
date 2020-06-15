using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.Json;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values

        public void Post(JsonProperty jsonInput)
        {
            var department = System.Text.Json.JsonSerializer.Deserialize<Department>(jsonInput.ToString());
            string insertNewRowQuery = @"INSERT INTO Department (Name,DepartmentId) Values ('"
                                       + department.Name + "','" + department.DepartmentId + "')";
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|/test2.db3"))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    conn.Open();                            
                    com.CommandText = insertNewRowQuery;     
                    com.ExecuteNonQuery();                  

                    conn.Close();       
                }
            }

        }
 

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
