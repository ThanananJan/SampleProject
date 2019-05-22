using Microsoft.EntityFrameworkCore;
using RegistrationContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationDB
{
    public class CustomerRepository
    {
        // create 
        // get by id
        // update 
        // delete
        CustomerDbcontext custDB;
        public CustomerRepository(CustomerDbcontext customerDbcontext)
        {
        
            custDB = customerDbcontext;
            custDB.Database.EnsureCreated();
        }
        public Customer Create(Customer customer)
        {
            custDB.customer.Add(customer);
            custDB.SaveChanges();
          return custDB.customer.FirstOrDefault(x => x.firstName == customer.firstName && x.lastName == customer.lastName&&x.flag=="A");
        }
        public Customer Update(Customer customer)
        {
            custDB.Update(customer);
            custDB.SaveChanges();
            return custDB.customer.FirstOrDefault(x => x.id == customer.id);
        }
        public Customer GetByID(int id)
        {
            return custDB.customer.FirstOrDefault(x => x.id == id);
        }
        public Customer Delete(int id)
        {
            var obj = custDB.customer.First(x => x.id == id);
            if (obj!=null) {
                obj.flag = statusFlag.Delete;
                custDB.Update(obj);
                custDB.SaveChanges();
               
            }
            return custDB.customer.FirstOrDefault(x => x.id == id);
        }
        public Customer GetByCode(string code)
        {
            return custDB.customer.Where(x => x.code == code).OrderByDescending(x=>x.id).FirstOrDefault();
        }
    }
}
