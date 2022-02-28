using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Models
{
    public class approval
    {
        public string Idapproval { get; set; }
        public int Idstaff { get; set; }
        public string Header { get; set; }
        public string Note { get; set; }
        public DateTime Create_time { get; set; }
        public int box { get; set; }
        public double Area { get; set; }
        public string Locate { get; set; }
    }
}
