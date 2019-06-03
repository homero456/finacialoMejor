using SM.CrossCutting.Models.Models;
using System;
using System.Collections.Generic;

namespace SM.Core.HistoryCompaign.Interfaces
{
    public interface IHistoryCompaign
    {
        List<Compaign> GetHistoryCompaigns(string idUser);
    }
}
