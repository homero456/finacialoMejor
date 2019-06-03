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
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSM
{
    public class UnitTestEmailSend
    {

        private SMContext _SMContext;
        private ISendMail _ISendMail;
        private  void CreateService()
        {

            var builder = new DbContextOptionsBuilder<SMContext>().UseSqlServer("Server=.\\SQLEXPRESS;Database=MariaDB;Trusted_Connection=True;");
            _SMContext = new SMContext(builder.Options);
            _ISendMail = new SendMail(_SMContext); 
            
        }
                     
        

        [Fact(DisplayName = "Test send mail")]
        public void Test1()
        {
            CreateService();

            var idUser = "";

            var compaigns = _ISendMail.GetCompaigns(idUser);
            //Assert.True(compaigns > 0, "The value greater than 0");
        }
    }
}
