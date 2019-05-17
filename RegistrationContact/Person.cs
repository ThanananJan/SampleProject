using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationContact
{
    [Serializable]
    public  class Person :TableBase
    {
        
        public int id { get; set; }
        public string code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; } 
        public string ziticenID { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Cuser { get; set; }
        public string MUser { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public DateTime MDate { get; set; } = DateTime.Now;
        public string flag { get; set; } = "A";
    }
}
