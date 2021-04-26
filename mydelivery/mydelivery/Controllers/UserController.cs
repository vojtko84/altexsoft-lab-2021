using Mydelivery.Models;

namespace Mydelivery.Controllers
{
    public class UserController
    {
        public IUser User { get; set; }

        public IUser SelectUser(string selectedUser)
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