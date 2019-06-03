using SM.Core.DeleteCompaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Linq;

namespace SM.Core.DeleteCompaign.Implementation
{
    public class DeleteCompaign : IDeleteCompaign
    {

        private readonly SMContext _SMContext;
        public DeleteCompaign(SMContext sMContext)
        {
            _SMContext = sMContext;
        }

        public int Delete(Compaign campaign)
        {
            var item = _SMContext.Compaigns.Where(x => x.IdCompaign == campaign.IdCompaign).FirstOrDefault();
            if (item != null)
            {
                item.Status = false;
                _SMContext.Compaigns.Update(item);
                var data = _SMContext.SaveChanges();
                return data;
            }
            else {
                return 0;
            }            
        }
    }
}
