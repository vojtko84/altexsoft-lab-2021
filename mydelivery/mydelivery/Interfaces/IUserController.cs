using Mydelivery.Models;

namespace Mydelivery.Interfaces
{
    public interface IUserController
    {
        IUser User { get; set; }

        IUser SelectUser(string selectedUser);
    }
}