using RegistrationContact;
using RegistrationDB;
using System;

namespace RegistrationLogic
{
    public class CustomerManagement
    {
        CustomerRepository custRepo;
        AddressRepository addrRepo;
        PhotoRepository photoRepo;
        public CustomerManagement(CustomerRepository customerRepository,AddressRepository addressRepository, PhotoRepository photoRepository)
        {
            custRepo = customerRepository;
            addrRepo = addressRepository;
            photoRepo = photoRepository;
        }
        public Customer GetCustomerByCustomerCode(string customer_code)
        {
            var obj = custRepo.GetByCode(customer_code);
            if (obj == null) return obj;
            obj.address = addrRepo.GetAddressByCustomerID(obj.id);
            obj.photo = photoRepo.GetPhotoByCustomerId(obj.id);
            return obj;
        }
        public Customer AddCustomer(Customer obj)
        {
            if (!obj.Validation()) throw new Exception("Invalid Customer");
            custRepo.Create(obj);
            AddAddress(obj);
            AddPhoto(obj);
            return obj;
        }

        private void AddPhoto(Customer obj)
        {
            if (obj.photo != null)
            {
                obj.photo.customer_id = obj.id;
                photoRepo.create(obj.photo);
            }
        }

        private void AddAddress(Customer obj)
        {
            if (obj.address != null)
            {
                foreach (var i in obj.address)
                {
                    i.customer_id = obj.id;
                    addrRepo.Create(i);
                }
            }
        }
    }
}
