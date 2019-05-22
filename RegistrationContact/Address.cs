using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationContact
{
    public class Address : TableBase
    {
        public int id { get;set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string tambon { get; set; }
        public string amphur { get; set; }
        public string province { get; set; }
        [MaxLength(5)]
        public string zipcode { get; set; }

        public string cUser { get; set; }
        public string mUser { get; set; }
        public DateTime cDate { get; set; } = DateTime.Now;
        public DateTime mDate { get; set; } = DateTime.Now;
        public string flag { get; set; } = "A";
        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        public Customer customer { get; set; }
      
    }
}
