using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationContact;
using RegistrationDB;
using RegistrationLogic;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerManagement cust;
        public CustomerController(CustomerRepository customerRepository, AddressRepository addressRepository, PhotoRepository photoRepository)
        {
            cust = new CustomerManagement(customerRepository, addressRepository, photoRepository);
        }

        [HttpGet("{code}")]
        public JsonResult Get(string code)
        {
            return new JsonResult(cust.GetCustomerByCustomerCode(code));

        }
        [HttpPost]
        public JsonResult Post([FromBody]Customer obj)
        {
            return new JsonResult(cust.AddCustomer(obj));
        }

    }
}