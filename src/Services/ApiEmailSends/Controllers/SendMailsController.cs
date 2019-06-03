using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FM.Core.ExportExcel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SM.Core.EmailSends.Interfaces;
using SM.Data.Providers.Sql;

namespace ApiEmailSends.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailsController : ControllerBase
    {
        private readonly SMContext _SMContext;
        private readonly ISendMail _ISendMail;
        private readonly IExportExcel _IExportExcel;
        public SendMailsController(ISendMail iSendMail, IExportExcel iExportExcel, SMContext sMContext)
        {
            _ISendMail = iSendMail;
            _IExportExcel = iExportExcel;
            _SMContext = sMContext;
        }

        // GET api/SendMails/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var lista = _ISendMail.GetCompaigns(id);

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
                fileDownloadName: "sendmails.xlsx"
            );
        }

        
    }
}
