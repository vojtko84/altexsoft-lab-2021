using MyDelivery.Models;

namespace MyDelivery.Interfaces
{
    public interface IUserController
    {
        User User { get; set; }

        User SelectUserType(string selectedUser);
    }
}