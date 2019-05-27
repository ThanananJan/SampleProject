using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationContact
{
    public interface TableBase
    {
        int id { get; set; }
        string cUser { get; set; }
        string mUser { get; set; }
        DateTime cDate { get; set; }
        DateTime mDate { get; set; }
        string flag { get; set; }
    }
    public abstract class ObjectValidate 
    {
        public abstract bool Validation();
      
        public  bool isNull(string obj)
        {
            if (string.IsNullOrEmpty(obj)) return true;
            else return false;
        }
        public bool isNull(DateTime obj)
        {
            if (obj == DateTime.MinValue) return true;
            else return false;
        }
    }
}
