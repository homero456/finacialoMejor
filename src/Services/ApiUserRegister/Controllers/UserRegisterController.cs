using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FM.Core.UserRegister.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;

namespace ApiUserRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly SMContext _SMContext;
        private readonly IUserRegister _IUserRegister;
        public UserRegisterController(IUserRegister iUserRegister, SMContext sMContext)
        {
            _IUserRegister = iUserRegister;
            _SMContext = sMContext;
        }


        // POST api/userregister
        [HttpPost]
        public ActionResult<int> Post([FromBody] User user)
        {
            try
            {
               return _IUserRegister.Register(user);
            }
            catch (Exception ex)
            {
                return BadRequest("{\"error\":\"" + ex.Message + "");
            }
        }

        
    }
}
