using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CPIIndex
    {
        public long CPIIndexID { get; set; }
        public DateTime ProductCPIDateEntry { get; set; }
        public decimal CPIIndexValue {get;set;}
        public bool ActiveStatus { get; set; }

    }
}
