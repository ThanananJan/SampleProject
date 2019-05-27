using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationContact
{
    public class Photo : ObjectValidate,TableBase
    {
        public int id { get; set; }

        private string content;

        public string imagebase64
        {
            get { return getPhoto(); }
            set => content = value;
        }
        [ForeignKey("id")]
        public int customer_id { get; set; }
        public string cUser { get; set; }
        public string mUser { get; set; }
        public DateTime cDate { get; set; } = DateTime.Now;
        public DateTime mDate { get; set; } = DateTime.Now;
        public string flag { get; set; } = "A";
        public string getPhoto()
        {
           return content.StartsWith("data:image") ? content :
                 $"data:image/png;base64,{content}";
        }

        public override bool Validation()
        {
          return  Validation(this);

        }

        private bool Validation(Photo obj)
        {
            if (isNull(obj.content)) return false;
            else return true;
        }
    }
}
