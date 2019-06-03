using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FM.Core.ExportExcel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SM.CrossCutting.Models.Models;

namespace ApiExportExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportExcelController : ControllerBase
    {


        private readonly IExportExcel _IExportExcel;
        public ExportExcelController(IExportExcel iExportExcel)
        {
            _IExportExcel = iExportExcel;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] FileExport file)
        {

            byte[] fileContents = _IExportExcel.ToBytes(file.List);
            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: file.FileName
            );
        }


       

       
    }
}
