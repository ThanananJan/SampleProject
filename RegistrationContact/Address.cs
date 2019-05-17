using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistrationContact
{
    public class Address : TableBase
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string tambon { get; set; }
        public string amphur { get; set; }
        public string province { get; set; }
        [MaxLength(5)]
        public string zipcode { get; set; }
        public string Cuser { get; set; }
        public string MUser { get; set; }
        public DateTime CDate {get;set;}
        public DateTime MDate {get;set;}
        public string flag{ get; set; }
        public int person_id { get; set; }
    }
}
