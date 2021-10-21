using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.DTOs
{
    public class CPIIndexDTO
    {
        public long CPIIndexID { get; set; }
        public DateTime ProductCPIDateEntry { get; set; }
        public decimal CPIIndexValue { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
