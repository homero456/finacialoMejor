using FM.Core.UserRegister.Implementation;
using FM.Core.UserRegister.Interfaces;
using Microsoft.EntityFrameworkCore;
using SM.Core.CreateCampaign.Implementation;
using SM.Core.CreateCampaign.Interfaces;
using SM.Core.DeleteCompaign.Implementation;
using SM.Core.DeleteCompaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSM
{
    public class UnitCampaignDelete
    {

        private SMContext _SMContext;
        private IDeleteCompaign _ICampaign;
        private  void CreateService()
        {

            var builder = new DbContextOptionsBuilder<SMContext>().UseSqlServer("Server=.\\SQLEXPRESS;Database=MariaDB;Trusted_Connection=True;");
            _SMContext = new SMContext(builder.Options);
            _ICampaign = new DeleteCompaign(_SMContext); 
            
        }




        

        [Fact(DisplayName = "Test delete campaign")]
        public void Test1()
        {
            CreateService();

            var compaing = new Compaign
            {
                IdCompaign=1,
                IdUser = "1",
                NumberOfRecipients = 2,
                Status = true,
                Subject="Asunto",
                DateCreated = DateTime.Now
            };

            var value = _ICampaign.Delete(compaing);
            Assert.True(value > 0, "The value greater than 0");
        }
    }
}
