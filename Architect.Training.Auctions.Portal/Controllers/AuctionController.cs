using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architect.Training.Auctions.Portal.Data;
using Architect.Training.Auctions.Portal.Filters;
using Architect.Training.Auctions.Portal.Infrastructure;
using Architect.Training.Auctions.Portal.Models;

namespace Architect.Training.Auctions.Portal.Controllers
{

    public class AuctionController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ICurrentUser _currentUser;


        public AuctionController(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateNewAuction()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, Log("Created new Auction")]
        public ActionResult CreateNewAuction(AuctionForm auctionDetails)
        {
            
            //TODO: Uncomment the ModelState.IsValid condition.
            if (!ModelState.IsValid)
            {
                //return 
            }


            return View();
        }
    }

}