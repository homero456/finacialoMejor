using FM.Core.ExportExcel.Implentation;
using FM.Core.ExportExcel.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SM.CrossCutting.Models.Models;
using System;
using System.Net.Http;
using System.Text;
using Xunit;

namespace XUnitTestSM
{
    public class UnitTestExcel
    {

        private IExportExcel CreateService()
        {
            return new ExportExcel();
        }


        [Fact(DisplayName ="Test Excel convert to bytes")]
        public void Test1()
        {
            var service = CreateService();
            string input = "[{\"FirstName\":\"Hans\",\"LastName\":\"Olo\"},{\"FirstName\":\"Jimmy\",\"LastName\":\"Crackedcorn\"}]";
            var bytes = service.ToBytes(input);
            Assert.NotNull(bytes);
        }


      

    }
}
