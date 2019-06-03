using SM.Core.CreateCampaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;

namespace SM.Core.CreateCampaign.Implementation
{
    public class CreateCampaign : ICampaign
    {
        private readonly SMContext _SMContext;
        public CreateCampaign(SMContext sMContext)
        {
            _SMContext = sMContext;
        }      


        public int Register(Compaign campaign)
        {
            campaign.DateCreated = DateTime.Now;
            _SMContext.Compaigns.Add(campaign);
            var data = _SMContext.SaveChanges();
            return data;
        }
    }
}
