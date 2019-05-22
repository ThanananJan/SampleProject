using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RegistrationDB;
using AutoFixture;
using RegistrationContact;
using System;

namespace Tests
{
    public class addressDbTest
    {
        string dbTest;
        [SetUp]
        public void Setup()
        {
            dbTest = "D:/SampleProjectTestRela.db";
        }

       // add address
       // update address
       // delete address
       // get address by id 
       // get address by customer_id 
       [Test]
       public void add_address_should_get_address_new()
        {
            var obj = new Address()
            {
                line1 = "1",
                line2 = "คุ้มเดิม",
                line3 = "ตำบลในเวียง",
                amphur = "เมือง",
                province = "แพร่",
                zipcode = "54150",
                customer_id = 1
            };

            var result = new AddressRepository(new CustomerDbcontext(dbTest)).Create(obj);

            Assert.True(obj.line1 == result.line1
                && obj.line2 == result.line2
                && obj.line3 == result.line3
                && obj.amphur == result.amphur
                && obj.province == result.province
                && obj.zipcode == result.zipcode
                && obj.customer_id == result.customer_id);
        }
        [Test]
        public void add_address_without_customer_id_should_not_add()
        {
            var obj = new Address()
            {
                line1 = "1",
                line2 = "คุ้มเดิม",
                line3 = "ตำบลในเวียง",
                amphur = "เมือง",
                province = "แพร่",
                zipcode = "54150"
            };
            Exception error = null;
            try
            {
                var result = new AddressRepository(new CustomerDbcontext(dbTest)).Create(obj);

            }
            catch (Exception ex)
            {
                error = ex;
            }
            Assert.True(error!=null);

        }
        [Test]
        public void update_address_should_get_update_obj()
        {
            var update_line2 = "คุ้มใหม่";
            var obj = new Address()
            {
                line1 = "1",
                line2 = "คุ้มเดิม",
                line3 = "ตำบลในเวียง",
                amphur = "เมือง",
                province = "แพร่",
                zipcode = "54150",
                customer_id = 1
            };

            var addrRepo = new AddressRepository(new CustomerDbcontext(dbTest));
            var create_addr = addrRepo.Create(obj);
            create_addr.line2 = update_line2;
            var result = addrRepo.Update(create_addr);    
            
            Assert.True(update_line2 == result.line2);
        }
        public void delete_address_should_get_flag_delete()
        {
            var obj = new Address()
            {
                line1 = "1",
                line2 = "คุ้มเดิม",
                line3 = "ตำบลในเวียง",
                amphur = "เมือง",
                province = "แพร่",
                zipcode = "54150",
                customer_id = 1
            };

            var addrRepo = new AddressRepository(new CustomerDbcontext(dbTest));
            var create_addr = addrRepo.Create(obj);
            var result = addrRepo.Delete(create_addr.id);

            Assert.True(result.flag==statusFlag.Delete);
        }
        public void get_address_by_customer_id_should_get_array_of_address()
        {
            var obj = new Address()
            {
                line1 = "1",
                line2 = "คุ้มเดิม",
                line3 = "ตำบลในเวียง",
                amphur = "เมือง",
                province = "แพร่",
                zipcode = "54150",
                customer_id = 2
            };

            var addrRepo = new AddressRepository(new CustomerDbcontext(dbTest));
            var create_addr = addrRepo.Create(obj);
            var result = addrRepo.GetAddressByCustomerID(create_addr.customer_id);

            Assert.True(result.Length>0);
        }

    }
}