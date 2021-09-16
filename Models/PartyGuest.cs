using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlannerAPI.Models
{
    public class PartyGuest
    {
        public int ID { get; set; }
        public int PartyID { get; set; }
        public int GuestID { get; set; }
        public string GuestName { get; set; }
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
    }
}