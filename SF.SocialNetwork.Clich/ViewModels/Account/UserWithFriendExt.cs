﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SF.SocialNetwork.Clich.Models.Users;

namespace SF.SocialNetwork.Clich.ViewModels.Account
{
    public class UserWithFriendExt : User
    {
        public bool IsFriendWithCurrent { get; set; }
    }
}
