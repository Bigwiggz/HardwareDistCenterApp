using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Companies
    {
        public long CompaniesID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNAICS { get; set; }
        public string CompanySIC { get; set; }
        public string CorporateEmail { get; set; }
        public string CorporatePhone { get; set; }
        public string CompanyCategory { get; set; }
        public string EIN { get; set; }
        public bool ActiveStatus { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsClient { get; set; }
        public DateTime DateCompanyAddedUpdated { get; set; }

    }
}
