using FM.Core.UserRegister.Implementation;
using FM.Core.UserRegister.Interfaces;
using Microsoft.EntityFrameworkCore;
using SM.Core.CreateCampaign.Implementation;
using SM.Core.CreateCampaign.Interfaces;
using SM.Core.DeleteCompaign.Implementation;
using SM.Core.DeleteCompaign.Interfaces;
using SM.Core.EmailSends.Implementation;
using SM.Core.EmailSends.Interfaces;
using SM.Core.HistoryCompaign.Implementation;
using SM.Core.HistoryCompaign.Interfaces;
using SM.Core.InitSesion.Implementation;
using SM.Core.InitSesion.Interfaces.IInitSesion;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSM
{
    public class UnitTestInitSesion
    {

        private SMContext _SMContext;
        private ISesion _ISesion;
        private  void CreateService()
        {

            var builder = new DbContextOptionsBuilder<SMContext>().UseSqlServer("Server=.\\SQLEXPRESS;Database=MariaDB;Trusted_Connection=True;");
            _SMContext = new SMContext(builder.Options);
            _ISesion = new InitSesion(_SMContext); 
            
        }
                     
        

        [Fact(DisplayName = "Test validate user")]
        public void Test1()
        {
            CreateService();

            var idUser = "";

            var data = _ISesion.Validar("test1@hot.com", "123");

            Assert.NotNull(data);
        }
    }
}
