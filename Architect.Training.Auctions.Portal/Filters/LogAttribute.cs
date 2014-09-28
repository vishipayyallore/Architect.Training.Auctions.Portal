using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architect.Training.Auctions.Portal.Data;
using Architect.Training.Auctions.Portal.Infrastructure;
using Architect.Training.Auctions.Portal.Models.Domain;

namespace Architect.Training.Auctions.Portal.Filters
{

    public class LogAttribute : ActionFilterAttribute
    {

        private IDictionary<string, object> _parameters;
        public ApplicationDbContext Context { get; set; }
        public ICurrentUser CurrentUser { get; set; }
        public string Description { get; set; }

        public LogAttribute(string description)
        {
            Description = description;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _parameters = filterContext.ActionParameters;
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var description = Description;

            foreach (var keyValueItem in _parameters)
            {
                description = description.Replace(string.Format("{{0}}", keyValueItem.Key), keyValueItem.Value.ToString());
            }

            //Context.
            Context.Logs.Add(new LogAction(CurrentUser.User, filterContext.ActionDescriptor.ActionName,
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, description));

            Context.SaveChanges();
        }

    }   //end of [LogAttribute] class.

}