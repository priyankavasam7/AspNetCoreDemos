using Microsoft.EntityFrameworkCore;
using SmartPhones.API.Data;
using SmartPhones.API.Models;

namespace SmartPhones.API.Repository
{
    public class SmartPhoneRepository : ISmartPhoneRepository
    {
        SmartPhoneDbContext _smartPhoneDbContext;
        public SmartPhoneRepository(SmartPhoneDbContext smartPhoneDbContext)
        {
            _smartPhoneDbContext = smartPhoneDbContext;
        }
        public bool AddSmartPhone(SmartPhone smartPhone)
        {
            if (smartPhone == null) return false;
            _smartPhoneDbContext.smartPhones.Add(smartPhone);
            _smartPhoneDbContext.SaveChanges();
            return true;
        }

        public bool DeleteSmartPhone(int id)
        {
            var smartPhone = GetSmartPhoneById(id);
            if(smartPhone == null) return false;
            _smartPhoneDbContext.smartPhones.Remove(smartPhone);
            _smartPhoneDbContext.SaveChanges() ;
            return true;
        }
        public IEnumerable<SmartPhone> GetAllSmartPhones()
        {
            var smartphones = _smartPhoneDbContext.smartPhones;
            if (smartphones == null) return null;
            return smartphones;
        }
        public SmartPhone GetSmartPhoneById(int id)
        {
            var smartPhone = _smartPhoneDbContext.smartPhones.FirstOrDefault(x => x.Id == id);
            if (smartPhone == null) return null;
            return smartPhone;
        }

        public SmartPhone UpdateSmartPhone(int id, SmartPhone smartPhone)
        {
            var existingSmartPhone=GetSmartPhoneById(id);
            if (existingSmartPhone != null)
            {
                existingSmartPhone.Id = id;
                existingSmartPhone.Name = smartPhone.Name;
                existingSmartPhone.Features = smartPhone.Features;
                existingSmartPhone.LaunchDate = smartPhone.LaunchDate;
                existingSmartPhone.Price = smartPhone.Price;
                _smartPhoneDbContext.SaveChanges();
                return existingSmartPhone;
            }
            return null;
        }
        
        public string GetMinAndAvgPrice()
        {
            var smartphones=_smartPhoneDbContext.smartPhones;
            var firstSmartPhone = _smartPhoneDbContext.smartPhones.First();
            double minPrice=firstSmartPhone.Price;
            double totalPrice = 0;
            double avgPrice = 0;
            foreach (SmartPhone smartphone in smartphones)
            {
                if (smartphone.Price < minPrice)
                {
                    minPrice = smartphone.Price;
                }
                totalPrice += smartphone.Price;
            }
            avgPrice= totalPrice/smartphones.Count();
            string message = $"The Minimum Price of a SmartPhone is {minPrice}\n The Average price of a SmartPhone is {avgPrice}";
            return message;
        }

        public IEnumerable<SmartPhone> FilterByLaunchDateAndPrice(double Price)
        {
            List<SmartPhone> filteredSmartPhones= new List<SmartPhone>();
            DateTime currentDate = DateTime.Now;
            var smartPhones= _smartPhoneDbContext.smartPhones;
            foreach(SmartPhone smartphone in smartPhones)
            {
                if(smartphone.LaunchDate > currentDate &&  smartphone.Price <= Price)
                {
                    filteredSmartPhones.Add(smartphone);
                }
            }
            return filteredSmartPhones;

        }

    }
}
