using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Models
{
    public class process
    {
        public string idprocess { get; set; }
        public string idapply { get; set; }
        public string idmodel { get; set; }
        public int processer { get; set; }
        public string comment { get; set; }
        public DateTime time { get; set; }
        public int status { get; set; }

    }
}
