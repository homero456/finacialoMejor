using SM.CrossCutting.Models.Models;
using System;
using System.Collections.Generic;

namespace SM.Core.EmailSends.Interfaces
{
    public interface ISendMail
    {
        IEnumerable<object> GetCompaigns(string idUser);
    }
}
