using SM.Core.EmailSends.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Core.EmailSends.Implementation
{
    public class SendMail : ISendMail
    {
        private readonly SMContext _SMContext;
        public SendMail(SMContext sMContext)
        {
            _SMContext = sMContext;
        }


        public IEnumerable<object> GetCompaigns(string idUser)
        {            

            var lista = _SMContext.Compaigns.Where(x => ((x.IdUser == idUser &&  !string.IsNullOrEmpty(idUser) ) || (string.IsNullOrEmpty(idUser)))  && x.Status).OrderBy(f => f.DateCreated).ToList();
            var tmp = from x in lista
                      group x by x.IdUser;
            var result = from y in tmp
                         select new
                         {
                             IdUser = y.Key,
                             Suma = y.Count()
                         };
            return result;


        }
    }
}
