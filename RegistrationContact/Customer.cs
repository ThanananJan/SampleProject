using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistrationContact
{
    [Serializable]
    public  class Customer : ObjectValidate,TableBase
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
         public override bool Validation()
        {
            return Validation(this);
        }
        public bool Validation(Customer obj)
        {
            if (isNull(code) || isNull(firstName) || isNull(lastName) || isNull(password) || isNull(DOB)) return false;
            else return true;
        }
     
    }
}
