using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CompanyContacts
    {
        public long CompanyContactsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public bool ActiveStatus { get; set; }
        public long fkStoreLocationsID { get; set; }
        public string ContactEmail { get; set; }

    }
}
