using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SM.Core.InitSesion.Interfaces.IInitSesion;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;

namespace ApiInitSesionUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {


        private readonly SMContext _SMContext;
        private readonly ISesion _IISesion;
        
        public SesionController(ISesion iSesion, SMContext sMContext)
        {
            _IISesion = iSesion;
            _SMContext = sMContext;
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Session session)
        {
            try
            {
                var data = _IISesion.Validar(session.Email, session.Password);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("{\"error\":\"" + ex.Message + "");
            }

           
        }

        
    }
}
