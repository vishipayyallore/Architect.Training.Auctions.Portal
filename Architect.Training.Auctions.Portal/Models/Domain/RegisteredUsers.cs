using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.Training.Auctions.Portal.Models.Domain
{
    public class RegisteredUsers
    {

        public RegisteredUsers()
        {
        }

        public Int64 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64 OrganizationId { get; set; }
        public String UserId { get; set; }
    }
}