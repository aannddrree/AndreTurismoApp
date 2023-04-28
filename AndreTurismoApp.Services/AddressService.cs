using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Services
{
    public class AddressService
    {
        public IAddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }

        public bool Insert(Address address)
        {
            return addressRepository.Insert(address);
        }

        public bool Delete(Address address)
        {
            return addressRepository.Delete(address);
        }

        public bool Update(Address address, int id)
        {
            return addressRepository.Update(address, id);
        }

        public List<Address> GetAll()
        {
            return addressRepository.GetAll();
        }
    }
}
