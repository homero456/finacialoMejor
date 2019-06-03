using FM.Core.UserRegister.Implementation;
using FM.Core.UserRegister.Interfaces;
using Microsoft.EntityFrameworkCore;
using SM.Core.CreateCampaign.Implementation;
using SM.Core.CreateCampaign.Interfaces;
using SM.Core.DeleteCompaign.Implementation;
using SM.Core.DeleteCompaign.Interfaces;
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
    public class UnitCampaignHistory
    {

        private SMContext _SMContext;
        private IHistoryCompaign _ICampaign;
        private  void CreateService()
        {

            var builder = new DbContextOptionsBuilder<SMContext>().UseSqlServer("Server=.\\SQLEXPRESS;Database=MariaDB;Trusted_Connection=True;");
            _SMContext = new SMContext(builder.Options);
            _ICampaign = new HistoryCompaign(_SMContext); 
            
        }
                     
        

        [Fact(DisplayName = "Test history campaign")]
        public void Test1()
        {
            CreateService();

            var idUser = "1";

            var compaigns = _ICampaign.GetHistoryCompaigns(idUser);
            Assert.True(compaigns.Count > 0, "The value greater than 0");
        }
    }
}
