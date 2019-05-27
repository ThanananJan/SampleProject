using NUnit.Framework;
using RegistrationContact;
using RegistrationDB;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class CustomerLogic
    {
        string dbTest;
        [SetUp]
        public void Setup()
        {
            dbTest = "D:/SampleProjectTestLogic.db";
            var db = new CustomerDbcontext(dbTest);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        [Test]
        // add customer
        public void add_customer_should_get_new_customer()
        {
            var obj = new Customer()
            {
                code = "00001",
                firstName = "first",
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };

            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db),new AddressRepository(db),new PhotoRepository(db));

            var result = cuslogic.AddCustomer(obj);

            Assert.True(result.id>0);

        }
        [Test]
        // add customer with address null photo
        public void add_customer_with_address_without_photo_should_get_customer_with_addrList_and_photo()
        {
            var obj = new Customer()
            {
                code = "00001",
                firstName = "first",
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };
            var adr1 =
                new Address()
                {
                    line1 = "line1",
                    line2 = "line2",
                    line3 = "line3",
                    tambon="tambon",
                    amphur = "amphur",
                    province = "province",
                    zipcode = "01212"
                };
            obj.address = new List<Address>();
            obj.address.Add(adr1);
            
            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));
            var result = cuslogic.AddCustomer(obj);
            Assert.True(result.id > 0 && result.address.Count > 0);

        }
        [Test]
        // add cusotomer with add and photo
        public void add_customer_with_photo_without_address_should_get_customer_with_photo()
        {
            var obj = new Customer()
            {
                code = "00001",
                firstName = "first",
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };
            byte[] img_byte = new byte[] { 1, 2, 34, 2, 1 };
           
            obj.photo = new Photo()
            {
                imagebase64 = Convert.ToBase64String(img_byte)
            };

            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));

            var result = cuslogic.AddCustomer(obj);

            Assert.True(result.id > 0 && result.photo.id>0&&result.photo.customer_id==result.id);
        }
        [Test]
        // add customer without name 
        public void add_customer_without_name_and_should_can_not_add_customer()
        {
            var obj = new Customer()
            {
                code = "00001",         
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };
            

            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));

            Exception error = null;
            try
            {
                var result = cuslogic.AddCustomer(obj);
            }
            catch (Exception ex)
            {
                error = ex;
            }

            Assert.True(error != null);
        }
        [Test]
        // add customer without DOB
        public void add_customer_without_DOB_should_can_not_add_customer()
        {
            var obj = new Customer()
            {
                code = "00001",
                firstName = "first",
                lastName = "last",
                password = "1234",
                Email = "a@a.com"
            };


            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));

            Exception error = null;
            try
            {
                var result = cuslogic.AddCustomer(obj);
            }
            catch (Exception ex)
            {
                error = ex;
            }

            Assert.True(error != null);
        }
        [Test]
        // add customer with address more than one 
        public void add_customer_with_2_address_should_get_address_list_with_2_item()
        {
            var obj = new Customer()
            {
                code = "00001",
                firstName = "first",
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };
            var adr1 =
                new Address()
                {
                    line1 = "line1",
                    line2 = "line2",
                    line3 = "line3",
                    tambon = "tambon",
                    amphur = "amphur",
                    province = "province",
                    zipcode = "01212"
                };
            var adr2 = new Address()
            {
                line1 = "line1",
                line2 = "line2",
                line3 = "line3",
                tambon = "tambon",
                amphur = "amphur",
                province = "province",
                zipcode = "01212"
            };
            obj.address = new List<Address>();
            obj.address.Add(adr1);
            obj.address.Add(adr2);

            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));
            var result = cuslogic.AddCustomer(obj);
            Assert.True(result.id > 0 && result.address.Count ==2);
        }
        [Test]
        // add customer with invalid address and invalid photo
        public void add_customer_with_address_zipcode_is_null_should_can_not_add_customer()
        {
            var obj = new Customer()
            {
                code = "00001",
                firstName = "first",
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };
            var adr1 =
                new Address()
                {
                    line1 = "line1",
                    line2 = "line2",
                    line3 = "line3",
                    tambon = "tambon",
                    amphur = "amphur",
                    province = "province",
                    zipcode = "010000212"
                };
          
            obj.address = new List<Address>();
            obj.address.Add(adr1);
            obj.photo = new Photo();

            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));
            Exception error = null;
            try
            {
                var result = cuslogic.AddCustomer(obj);
            }
            catch (Exception ex)
            {
                error = ex;
            }

            Assert.True(error != null);
        }
        [Test]
        // search customer with code that exist
        public void search_customer_with_code_exist_should_get_customer()
        {
            var obj = new Customer()
            {
                code = "00003",
                firstName = "first",
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };
   

            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));
            obj = cuslogic.AddCustomer(obj);
            var result = cuslogic.GetCustomerByCustomerCode(obj.code);
            Assert.True(result.id > 0);
        }
        [Test]
        // search customer with code not in system
        public void search_customer_with_code_not_exist_should_get_null()
        {
            var code = "000123";
            var db = new CustomerDbcontext(dbTest);
            var cuslogic = new RegistrationLogic.CustomerManagement(new RegistrationDB.CustomerRepository(db), new AddressRepository(db), new PhotoRepository(db));
            var result = cuslogic.GetCustomerByCustomerCode(code);
            Assert.True(result==null);
        }
        [Test]
        // search customer with code is deleted
        public void search_customer_with_code_that_deleted_should_get_null()
        {
            var obj = new Customer()
            {
                code = "00003",
                firstName = "first",
                lastName = "last",
                DOB = new System.DateTime(2011, 1, 1),
                password = "1234",
                Email = "a@a.com"
            };


            var db = new CustomerDbcontext(dbTest);
            var cusrepo = new CustomerRepository(db);
            var cuslogic = new RegistrationLogic.CustomerManagement(cusrepo, new AddressRepository(db), new PhotoRepository(db));
            obj = cuslogic.AddCustomer(obj);
            cusrepo.Delete(obj.id);
            
            var result = cuslogic.GetCustomerByCustomerCode(obj.code);
            Assert.True(result==null);
        }

    }
}