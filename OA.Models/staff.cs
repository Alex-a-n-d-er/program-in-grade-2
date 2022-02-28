using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Models
{
    public class staff
    {
        public int Idstaff { get; set; }
        public int Iddep { get; set; }
        public string Namestaff { get; set; }
        public string Pswstaff { get; set; }
        public string Posstaff { get; set; }
        public string Gender { get; set; }
        public DateTime Create_time { get; set; }
        public string Validity { get; set; }
    }
}
