using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlannerAPI.Models
{
    public class Party
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}