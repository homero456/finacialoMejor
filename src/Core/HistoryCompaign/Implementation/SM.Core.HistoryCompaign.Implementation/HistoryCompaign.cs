using SM.Core.HistoryCompaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Core.HistoryCompaign.Implementation
{
    public class HistoryCompaign : IHistoryCompaign
    {

        private readonly SMContext _SMContext;
        public HistoryCompaign(SMContext sMContext)
        {
            _SMContext = sMContext;
        }

        public List<Compaign> GetHistoryCompaigns(string idUser)
        {
            return _SMContext.Compaigns.Where(x => x.IdUser == idUser).OrderBy(f=>f.DateCreated).ToList();
        }
    }
}
