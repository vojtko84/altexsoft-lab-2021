using MyDelivery.Models;

namespace MyDelivery.Interfaces
{
    public interface IUserService
    {
        User User { get; set; }

        User SelectUserType(string selectedUser);
    }
}