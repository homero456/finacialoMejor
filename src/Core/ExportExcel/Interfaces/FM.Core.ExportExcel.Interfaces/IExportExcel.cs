using OfficeOpenXml;
using System;

namespace FM.Core.ExportExcel.Interfaces
{
    public interface IExportExcel
    {
        byte[] ToBytes(string list);
    }
}
