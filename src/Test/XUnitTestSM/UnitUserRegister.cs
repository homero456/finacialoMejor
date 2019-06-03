using FM.Core.UserRegister.Implementation;
using FM.Core.UserRegister.Interfaces;
using Microsoft.EntityFrameworkCore;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSM
{
    public class UnitUserRegister
    {

        private SMContext _SMContext;
        private  IUserRegister _IUserRegister;
        private  void CreateService()
        {

            var builder = new DbContextOptionsBuilder<SMContext>().UseSqlServer("Server=.\\SQLEXPRESS;Database=MariaDB;Trusted_Connection=True;");
            _SMContext = new SMContext(builder.Options);
            _IUserRegister = new UserRegister(_SMContext); 
            
        }




        

        [Fact(DisplayName = "Test register user")]
        public void Test1()
        {
            CreateService();

            var user = new User
            {
                IdUser = "1",
                Email = "test1@hot.com",
                Name = "test1",
                DateCreated = DateTime.Now
            };

            var value = _IUserRegister.Register(user);
            Assert.True(value > 0, "The value greater than 0");
        }
    }
}
