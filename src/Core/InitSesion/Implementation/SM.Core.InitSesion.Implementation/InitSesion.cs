
using Microsoft.IdentityModel.Tokens;
using SM.Core.Crosscutting.Utils;
using SM.Core.InitSesion.Interfaces.IInitSesion;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SM.Core.InitSesion.Implementation
{
    public class InitSesion : ISesion
    {
        private readonly SMContext _SMContext;
        public InitSesion(SMContext sMContext)
        {
            _SMContext = sMContext;
        }




        public object Validar(string email, string password)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
                {

                    string securityKey = "SecurityKey for token";
                    string siteUrl = "https://financialomejor.com/index.php";
                    string keyHash = "keyTest";
                    string passwordEncrypt = SecurityMD5.Encrypt(password, keyHash, true);
                    //string passwordDecrypt = SecurityMD5.Decrypt(passwordEncrypt, keyHash, true);

                    //string keyEncrypt = "In brightest day, in blackest night, No evil shall escape my sight Let those who worship evil's might, Beware my power...Green Lantern's light!";
                    //string securityKeyEncrypt = SecurityMD5.Encrypt(keyEncrypt, keyHash, true);
                    //string securityKeyDecrypt = SecurityMD5.Decrypt(securityKeyEncrypt, keyHash, true);



                    User user = _SMContext.Users.Where(x => x.Email == email).FirstOrDefault();

                    if (user != null)
                    {
                        // Valida la clave
                        if (!user.Password.Equals(passwordEncrypt))
                        {
                            throw new Exception("The password is not correct.");
                        }


                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("IdUser", user.IdUser));
                        claims.Add(new Claim("Name", user.Name));
                        claims.Add(new Claim(ClaimTypes.Email, user.Email));



                        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            issuer: siteUrl,
                            audience: siteUrl,
                            claims: claims,
                            expires: DateTime.Now.AddHours(8),
                            signingCredentials: creds);

                        var data = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            user = new
                            {
                                Id = user.IdUser,
                                Name = user.Name,
                                Email = user.Email,
                            }
                        };

                        return data;

                    }
                    else
                    {
                        throw new Exception("The email and password could not be verified.");
                    }
                }
                else
                {
                    throw new Exception("The email and password could not be verified.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
        }
    }
}
