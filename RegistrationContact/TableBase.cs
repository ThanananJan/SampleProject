using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationContact
{
    public interface TableBase
    {
        string Cuser { get; set; }
        string MUser { get; set; }
        DateTime CDate { get; set; }
        DateTime MDate { get; set; }
        string flag { get; set; }
    }
}
