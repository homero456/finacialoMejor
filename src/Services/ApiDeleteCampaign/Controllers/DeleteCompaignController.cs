using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SM.Core.DeleteCompaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;

namespace ApiDeleteCampaign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCompaignController : ControllerBase
    {

        private readonly SMContext _SMContext;
        private readonly IDeleteCompaign _IDeleteCampaign;
        public DeleteCompaignController(IDeleteCompaign ideleteCampaign, SMContext sMContext)
        {
            _IDeleteCampaign = ideleteCampaign;
            _SMContext = sMContext;
        }

        // POST api/DeleteCompaign
        [HttpPost]
        public ActionResult<int> Post([FromBody] Compaign compaign)
        {
            try
            {
                return _IDeleteCampaign.Delete(compaign);
            }
            catch (Exception ex)
            {
                return BadRequest("{\"error\":\"" + ex.Message + "");
            }
        }

        
    }
}
