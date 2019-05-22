using RegistrationContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationDB
{
   public class AddressRepository
    {
        CustomerDbcontext custDb;
        public AddressRepository(CustomerDbcontext customerDbcontext)
        {
            custDb = customerDbcontext;
            custDb.Database.EnsureCreated();
        }
        public Address Create(Address addr)
        {
            custDb.address.Add(addr);
            custDb.SaveChanges();
            return addr;
        }
        public Address Update(Address addr)
        {
            custDb.address.Update(addr);
            custDb.SaveChanges();
           return custDb.address.FirstOrDefault(p => p.id == addr.id);
        }
        public Address Delete (int address_id)
        {
            var obj = custDb.address.FirstOrDefault(p => p.id == address_id);
            obj.flag = statusFlag.Delete;
            custDb.address.Update(obj);
            custDb.SaveChanges();
            return custDb.address.FirstOrDefault(p => p.id == address_id);
        }
        public Address[] GetAddressByCustomerID(int customer_id)
        {
            return custDb.address.Where(p => p.customer_id == customer_id &&p.flag ==statusFlag.Active).OrderByDescending(p=>p.id).ToArray();
        }
        public Address GetAddressByID(int address_id)
        {
            return custDb.address.FirstOrDefault(p => p.id ==address_id);
        }
    }
}
