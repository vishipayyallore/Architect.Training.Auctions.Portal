﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/Architect.Training.Auctions.Service/");
                responseMessage = await client.GetAsync("api/Auctions/?userId=" + _currentUser.User.Id);
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                dynamic outputData = await responseMessage.Content.ReadAsAsync<object>();
            }

            return View();
        }


        public ActionResult CreateNewAuction()
        {
           

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, Log("Created new Auction")]
        public async Task<ActionResult> CreateNewAuction(AuctionForm auctionDetails)
        {
            HttpResponseMessage responseMessage;
            //HttpClient client;
            //TODO: Uncomment the ModelState.IsValid condition.
            if (!ModelState.IsValid)
            {
                //TODO: Error handling
                //return 
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/Architect.Training.Auctions.Service/");
                responseMessage = await client.PostAsJsonAsync("api/Auctions", auctionDetails);
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    } 

}