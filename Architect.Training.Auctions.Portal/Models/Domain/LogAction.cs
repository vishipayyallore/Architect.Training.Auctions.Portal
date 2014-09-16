using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.Training.Auctions.Portal.Models.Domain
{

    public class LogAction
    {


        public LogAction(ApplicationUser performedBy, string action, string controller, string description)
        {
            PerformedBy = performedBy;
            Action = action;
            Controller = controller;
            Description = description;
            CreatedDateTime = DateTime.Now;
        }

        public int Id { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }

        public ApplicationUser PerformedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }

}