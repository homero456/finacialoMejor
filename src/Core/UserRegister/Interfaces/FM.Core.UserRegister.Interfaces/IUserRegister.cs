using SM.CrossCutting.Models.Models;
using System;

namespace FM.Core.UserRegister.Interfaces
{
    public interface IUserRegister
    {
        int Register(User user);
    }
}
