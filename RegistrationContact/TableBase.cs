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
}
