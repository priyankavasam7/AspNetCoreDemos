using SmartPhones.API.Models;

namespace SmartPhones.API.Repository
{
    public interface ISmartPhoneRepository
    {
        public IEnumerable<SmartPhone> GetAllSmartPhones();
        public SmartPhone GetSmartPhoneById(int id);
        public bool AddSmartPhone(SmartPhone smartPhone);
        public bool DeleteSmartPhone(int id);
        public SmartPhone UpdateSmartPhone(int id, SmartPhone smartPhone);
        public string GetMinAndAvgPrice();
        public IEnumerable<SmartPhone> FilterByLaunchDateAndPrice(double Price);

    }
}
