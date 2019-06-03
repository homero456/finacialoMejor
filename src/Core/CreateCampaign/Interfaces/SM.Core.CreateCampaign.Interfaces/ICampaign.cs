using SM.CrossCutting.Models.Models;
using System;

namespace SM.Core.CreateCampaign.Interfaces
{
    public interface ICampaign
    {
        int Register(Compaign campaign);
    }
}
