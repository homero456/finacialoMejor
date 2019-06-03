using FM.Core.ExportExcel.Interfaces;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;

namespace FM.Core.ExportExcel.Implentation
{
    public class ExportExcel : IExportExcel
    {
        public byte[] ToBytes(string list)
        {

            byte[] fileContents;

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Sheet1");
                JArray array = JArray.Parse(list);
                foreach (JObject content in array.Children<JObject>())
                {
                    int i = 1;
                    foreach (JProperty prop in content.Properties())
                    {
                        sheet.Cells[1, i].Value = prop.Name;
                        sheet.Cells[1, i].Style.Font.Bold = true;
                        i++;
                    }
                }
                int j = 2;
                foreach (JObject content in array.Children<JObject>())
                {
                    int i = 1;
                    foreach (JProperty prop in content.Properties())
                    {
                        sheet.Cells[j, i].Value = prop.Value.ToString();
                        i++;
                    }
                    j++;
                }
                fileContents = package.GetAsByteArray();
            }           
            return fileContents;
        }
    }
}
