using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistrationContact
{

    public  class Customer :TableBase
    {
        
        public int id { get; set; }
        [Required]
        public string code { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public DateTime DOB { get; set; } 
        public string ziticenID { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        [Required]
        public string password { get; set; }
        
        public ICollection<Address> address { get; set; }
        public Photo photo { get; set; }
        public string cUser { get; set; }
        public string mUser { get; set; }
        public DateTime cDate { get; set; } = DateTime.Now;
        public DateTime mDate { get; set; } = DateTime.Now;
        public string flag { get; set; } = "A";
    }
}
