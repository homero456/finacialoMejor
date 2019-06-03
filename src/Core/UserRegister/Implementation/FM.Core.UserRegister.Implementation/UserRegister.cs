using FM.Core.UserRegister.Interfaces;
using SM.Core.Crosscutting.Utils;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Linq;

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
            var keyHash = "keyTest";
            string IdUserEncrypt = SecurityMD5.Encrypt(user.Email, keyHash, true);
            user.IdUser = IdUserEncrypt;
            var userExist = _SMContext.Users.Where(x => x.IdUser == IdUserEncrypt).FirstOrDefault();
            if (userExist == null)
            {
                user.Password= SecurityMD5.Encrypt(user.Password, keyHash, true);
                _SMContext.Users.Add(user);
                var data = _SMContext.SaveChanges();
                return data;
            }
            else
            {
                throw new Exception("Usuario ya existe");
            }            
        }
    }
}
