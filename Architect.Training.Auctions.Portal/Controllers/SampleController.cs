using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architect.Training.Auctions.Portal.Data;
using Architect.Training.Auctions.Portal.Filters;

namespace Architect.Training.Auctions.Portal.Controllers
{
    public class SampleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SampleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Log("Just Chill {id}")]
        public ActionResult New()
        {
            return View();
        }

        // GET: Sample
        [ChildActionOnly]
        public ActionResult RetrieveInformation()
        {
            return Content("Data from Sample Controller.");
        }

    }
}