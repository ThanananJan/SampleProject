using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RegistrationDB;
using AutoFixture;
using RegistrationContact;

namespace Tests
{
    public class CustomerRepo
    {
        string dbTest;
        [SetUp]
        public void Setup()
        {
            dbTest = "D:/SampleProjectTestRela.db";
        }

        [Test]
        public void customberdb_created (){
           var cusDb = new CustomerDbcontext(dbTest);
           //Assert.IsTrue(cusDb.Database.EnsureCreated());
           //Assert.IsTrue(cusDb.Database.EnsureDeleted());
        }
        [Test]
        public void customer_can_add_new_customer()
        {
            var obj = new Customer()
            {
                code="000001",
                firstName = "ชื่อทดสอบ",
                lastName = "นามสกุลทดสอบ",
                DOB = new System.DateTime(1990, 1, 1),
                ziticenID = "1234567891011",
                Email = "test1@gmail.com",
                password = "1234"

            };

            var cusRepo = new CustomerRepository(new CustomerDbcontext(dbTest));
            var customer = cusRepo.Create(obj);
            Assert.True(customer.ziticenID == obj.ziticenID && customer.id >0);
            
        }
        [Test]
        public void customer_get_cus_by_id_should_got_one()
        {
            var id = 1;
             var cusRepo = new CustomerRepository(new CustomerDbcontext(dbTest));
            var customer = cusRepo.GetByID(id);
            Assert.True(customer.id == id);
        }
        [Test]
        public void customer_get_cus_by_code_should_got_lastest_one() {
            var code = "000001";
            var cusRepo = new CustomerRepository(new CustomerDbcontext(dbTest));
            var customer = cusRepo.GetByCode(code);
            Assert.True(customer.code == code);

        }
        [Test]
        public void customer_delete_by_id_should_get_flag_d()
        {
            var id = 1;
            var cusRepo = new CustomerRepository(new CustomerDbcontext(dbTest));
            var customer = cusRepo.Delete(id);
            Assert.True(customer.flag == statusFlag.Delete);
        }
        [Test]
        public void customer_update_should_set_flag_to_be_a()
        {
            var id = 1;
            var conflag = "U";
            var cusRepo = new CustomerRepository(new CustomerDbcontext(dbTest));
            var obj = cusRepo.GetByID(id);
            obj.flag = conflag;
            var customer = cusRepo.Update(obj);
            Assert.True(customer.flag==conflag);
        }
        [Test]
        public void customer_can_update_with_new_customer()
        {
            var obj = new Customer()
            {
                code = "000002",
                firstName = "ชื่อทดสอบ",
                lastName = "นามสกุลทดสอบ",
                DOB = new System.DateTime(1990, 1, 1),
                ziticenID = "1234567891011",
                Email = "test2@gmail.com",
                password="1234"
            };

            var cusRepo = new CustomerRepository(new CustomerDbcontext(dbTest));
            var customer = cusRepo.Update(obj);
            Assert.True(customer.ziticenID == obj.ziticenID);

        }
    }
}