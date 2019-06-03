using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FM.Core.ExportExcel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SM.Core.HistoryCompaign.Interfaces;
using SM.CrossCutting.Models.Models;
using SM.Data.Providers.Sql;

namespace ApiHistoryCampaign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryCompaignController : ControllerBase
    {
        private readonly SMContext _SMContext;
        private readonly IHistoryCompaign _IHistoryCampaign;
        private readonly IExportExcel _IExportExcel;
        public HistoryCompaignController(IHistoryCompaign iHistoryCampaign, IExportExcel iExportExcel, SMContext sMContext)
        {
            _IHistoryCampaign = iHistoryCampaign;
            _IExportExcel = iExportExcel;
            _SMContext = sMContext;
        }


        // POST api/HistoryCompaign/
        [HttpPost()]
        public IActionResult Post([FromBody] User user)
        {
            var lista = _IHistoryCampaign.GetHistoryCompaigns(user.IdUser);
                        
            var json = JsonConvert.SerializeObject(lista);
            //Invocamos la libreria que se encarga de gestionar la data para exportar a excel
            byte[] fileContents = _IExportExcel.ToBytes(json.ToString());
            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "historyCompaign.xlsx"
            );

            
        }

        
    }
}
