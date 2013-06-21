using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public class ComStats
    {
        public int txBytes {get;set;}
        public int rxBytes { get; set; }
        public int txObjectBytes { get; set; }
        public int rxObjectBytes { get; set; }
        public int rxObjects { get; set; }
        public int txObjects { get; set; }
        public int txErrors { get; set; }
        public int rxErrors { get; set; }
    }
}
