using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Models.UserCredentials
{
    public class UserCredentials
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public string UserAssignmentId { get; set; }
    }
}
