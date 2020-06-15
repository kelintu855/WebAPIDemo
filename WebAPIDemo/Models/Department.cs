using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class Department
    {
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("department_id")]
        public int DepartmentId { get; set; }
    }
}