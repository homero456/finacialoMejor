using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SM.Core.CreateCampaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;

namespace ApiCreateCampaign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterCompaignController : ControllerBase
    {

        private readonly SMContext _SMContext;
        private readonly ICampaign _ICampaign;
        public RegisterCompaignController(ICampaign iCampaign, SMContext sMContext)
        {
            _ICampaign = iCampaign;
            _SMContext = sMContext;
        }

        // POST api/RegisterCompaign
        [HttpPost]
        public ActionResult<int> Post([FromBody] Compaign compaign)
        {

            try
            {
                return _ICampaign.Register(compaign);
            }
            catch (Exception ex)
            {
                return BadRequest("{\"error\":\"" + ex.Message + "");
            }
        }

       
    }
}
