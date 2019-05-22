using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RegistrationContact;
using RegistrationDB;

namespace RegistrationDBTest
{
   public class PhotoRepoTest
    {
        string dbTest;

        [SetUp]
        public void Setup() {

            dbTest = "D:/SampleProjectTestRela.db";
            addcustomer_id_1();
        } 
        public void addcustomer_id_1()
        {
            var obj = new Customer()
            {
                code = "000001",
                firstName = "ชื่อทดสอบ",
                lastName = "นามสกุลทดสอบ",
                DOB = new System.DateTime(1990, 1, 1),
                ziticenID = "1234567891011",
                Email = "test1@gmail.com",
                password = "1234"

            };
            var cusRepo = new CustomerRepository(new CustomerDbcontext(dbTest));
            var cust_id_1 = cusRepo.GetByID(1);
            if (cust_id_1==null)
            {
                cusRepo.Create(obj);
            }

        }
        [Test]
        public void add_photo_should_get_new_photo()
        {
            byte[] img_byte = new byte[]{ 1, 2, 34, 2, 1 };
            var obj = new Photo()
            {
                imagebase64 = Convert.ToBase64String(img_byte),
                customer_id = 1
            };

            var photoRepo = new PhotoRepository(new CustomerDbcontext(dbTest));
            var result = photoRepo.create(obj);
            Assert.True(result.imagebase64.Equals(obj.imagebase64));

        }
        [Test]
        public void add_photo_without_customer_id_should_not_add()
        {
            byte[] img_byte = new byte[] { 1, 2, 34, 2, 1 };
            var obj = new Photo()
            {
                imagebase64 = Convert.ToBase64String(img_byte),
            };
            Exception error = null;

            var photoRepo = new PhotoRepository(new CustomerDbcontext(dbTest));
           
            try
            {
                var result = photoRepo.create(obj);
            }
            catch(Exception ex)
            {
                error = ex;
            }
           
            Assert.False(error==null);
        }

        [Test]
        public void update_photo_should_show_update_content()
        {
            byte[] img_byte = new byte[] { 1, 2, 34, 2, 1,1 };
            var obj = new Photo()
            {
                imagebase64 = Convert.ToBase64String(img_byte),
                customer_id = 1
            };
            string update_content = Convert.ToBase64String(new byte[] { 2, 3, 4, 5, 6 });

            var photoRepo = new PhotoRepository(new CustomerDbcontext(dbTest));
            var photo_create = photoRepo.create(obj);
            photo_create.imagebase64 = update_content;
            var result = photoRepo.Update(photo_create);

            Assert.True(result.imagebase64.Contains(update_content)&&result.customer_id == obj.customer_id);
        }
        [Test]
        public void delete_photo_should_get_delete_flag()
        {
            byte[] img_byte = new byte[] { 1, 2, 34, 2, 1 };
            var obj = new Photo()
            {
                imagebase64 = Convert.ToBase64String(img_byte),
                customer_id = 1
            };

            var photoRepo = new PhotoRepository(new CustomerDbcontext(dbTest));
            var photo_create = photoRepo.create(obj);
            var result = photoRepo.Delete(photo_create.id);

            Assert.True(result.flag == statusFlag.Delete);
        }
        [Test]
        public void get_photo_by_customer_id_should_not_null()
        {
            byte[] img_byte = new byte[] { 1, 2, 34, 2, 1 };
            var obj = new Photo()
            {
                imagebase64 = Convert.ToBase64String(img_byte),
                customer_id = 1
            };

            var photoRepo = new PhotoRepository(new CustomerDbcontext(dbTest));
            var photo_create = photoRepo.create(obj);
            var result = photoRepo.GetPhotoByCustomerId(photo_create.customer_id);

            Assert.True(result!=null);
        }
    }
}
