using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestManager.Models
{
    public class Instrument
    {
        public string ins_code { get; set; }
        public string description { get; set; }
        public int status_id { get; set; }

        public Instrument(string Ins_code, string Description, int Status_id)
        {
            ins_code = Ins_code;
            description = Description;
            status_id = Status_id;
        }
    }
}
