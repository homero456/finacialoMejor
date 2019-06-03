using SM.CrossCutting.Models.Models;
using System;

namespace SM.Core.DeleteCompaign.Interfaces
{
    public interface IDeleteCompaign
    {
        int Delete(Compaign campaign);
    }
}
