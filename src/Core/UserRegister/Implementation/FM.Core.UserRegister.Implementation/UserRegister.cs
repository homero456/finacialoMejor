using FM.Core.UserRegister.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;

namespace FM.Core.UserRegister.Implementation
{
    public class UserRegister : IUserRegister
    {
        private readonly SMContext _SMContext;
        public UserRegister(SMContext sMContext)
        {
            _SMContext = sMContext;
        }


        public int Register(User user)
        {
            _SMContext.Add(user);
            var data = _SMContext.SaveChanges();
            return data;
        }
    }
}
