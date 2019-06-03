using System;

namespace SM.Core.InitSesion.Interfaces.IInitSesion
{
    public interface ISesion
    {
        object Validar(string user, string password);
    }
}
