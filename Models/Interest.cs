using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestManager.Models
{
    public class Interest
    {
        public int interest_id { get; set; }
        public string ins_code { get; set; }
        public decimal interest_rate { get; set; }
        public DateTime effective_date { get; set; }
        public int status_id { get; set; }

        public Interest(int Interest_id, string Ins_code, decimal Interest_rate, DateTime Effective_date, int Status_id)
        {
            interest_id = Interest_id;
            ins_code = Ins_code;
            interest_rate = Interest_rate;
            effective_date = Effective_date;
            status_id = Status_id;
        }
    }
}
