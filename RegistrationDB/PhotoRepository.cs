using RegistrationContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationDB
{
    
   public class PhotoRepository
    {
        CustomerDbcontext cusDb;
        
        public PhotoRepository(CustomerDbcontext customerDbcontext)
        {
            cusDb = customerDbcontext;
            cusDb.Database.EnsureCreated();
        }
        public Photo create(Photo photo)
        {
            if (photo.customer_id <= 0) throw new Exception("customer_id can't be null ");
            if (cusDb.photo.Count(p => p.customer_id == photo.customer_id) > 0)
            {
                cusDb.photo.Update(photo);
            }
            else
            {
                cusDb.photo.Add(photo);
            }
           
            cusDb.SaveChanges();
            return cusDb.photo.FirstOrDefault(x => x.customer_id == photo.customer_id&&x.flag==statusFlag.Active);
        }
        public Photo Delete(int id)
        {
            var obj = cusDb.photo.Find(id);
            if (obj != null)
            {
                obj.flag = statusFlag.Delete;
                cusDb.Update(obj);
                cusDb.SaveChanges();
            }
            return cusDb.photo.FirstOrDefault(x => x.id == id);
        }
        public Photo Update(Photo photo)
        {
            cusDb.Update(photo);
            cusDb.SaveChanges();
            return cusDb.photo.Find(photo.id);
        }
        public Photo GetPhotoByCustomerId(int customer_id)
        {
           return cusDb.photo.FirstOrDefault(p => p.customer_id == customer_id);

        }
    }
}
