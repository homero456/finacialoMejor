using FM.Core.UserRegister.Implementation;
using FM.Core.UserRegister.Interfaces;
using Microsoft.EntityFrameworkCore;
using SM.Core.CreateCampaign.Implementation;
using SM.Core.CreateCampaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSM
{
    public class UnitCampaignRegister
    {

        private SMContext _SMContext;
        private ICampaign _ICampaign;
        private  void CreateService()
        {

            var builder = new DbContextOptionsBuilder<SMContext>().UseSqlServer("Server=.\\SQLEXPRESS;Database=MariaDB;Trusted_Connection=True;");
            _SMContext = new SMContext(builder.Options);
            _ICampaign = new CreateCampaign(_SMContext); 
            
        }




        

        [Fact(DisplayName = "Test register campaign")]
        public void Test1()
        {
            CreateService();

            var compaing = new Compaign
            {
                IdUser = "1",
                NumberOfRecipients = 2,
                Status = true,
                Subject="Asunto",
                DateCreated = DateTime.Now
            };

            var value = _ICampaign.Register(compaing);
            Assert.True(value > 0, "The value greater than 0");
        }
    }
}
