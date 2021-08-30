using MyDelivery.Interfaces;
using MyDelivery.Models;

namespace MyDelivery.Controllers
{
    public class UserService : IUserService
    {
        public User User { get; set; }

        public User SelectUserType(string selectedUser)
        {
            return selectedUser switch
            {
                "1" => this.User = new Buyer(),
                "2" => this.User = new Seller(),
                "3" => this.User = new Admin(),
                _ => this.User = null,
            };
        }
    }
}