using System.Collections.Generic;
using SF.SocialNetwork.Clich.Models.Users;

namespace SF.SocialNetwork.Clich.ViewModels.Account
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }

        public List<User> Friends { get; set; }
    }
}
