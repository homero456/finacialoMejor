using System;
using System.Collections.Generic;
using System.Text;

namespace SM.CrossCutting.Models.Models
{
    public class Compaign
    {
        public int IdCampaign { get; set; }
        public string IdUser { get; set; }
        public string Subject { get; set; }
        public int NumberOfRecipients { get; set; }
        public bool Status { get; set; }
        public DateTime DatECreated { get; set; }
    }
}
