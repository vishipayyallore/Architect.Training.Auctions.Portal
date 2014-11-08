using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Training.Auctions.Service.Controllers;
using Architect.Training.Auctions.Service.DAL;
using Architect.Training.Auctions.Service.Data;
using Architect.Training.Auctions.Service.Models.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.Training.Auctions.Service.Tests.Controllers
{

    [TestClass]
    public class AuctionsControllerTest
    {



        [TestMethod]
        public void GivenUserIdShouldReturnAllAuctions()
        {

            var serviceDbContext = AuctionsServiceDbContext.Create();
            var auctionsRepository = new AuctionsRepository(serviceDbContext);
            var auctionsController = new AuctionsController(auctionsRepository);

            var results = auctionsController.GetAllAuctions(string.Empty);
            //GetAllAuctions
        }

        [TestMethod]
        public void GivenValidAuctionDetailsSentShouldPersistInDb()
        {
            var serviceDbContext = AuctionsServiceDbContext.Create();
            var auctionsRepository = new AuctionsRepository(serviceDbContext);
            var auctionsController = new AuctionsController(auctionsRepository);
            var currentAuction = new AuctionDto
            {
                BuyerId = 1,
                ItemName = "ASP.Net Consultancy",
                Description = "10 hours",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddDays(10),
            };

            var results = auctionsController.PostAuction(currentAuction);
        }

        [TestMethod]
        public void GivenValidBidDetailsSentShouldPersistInDb()
        {
            var serviceDbContext = AuctionsServiceDbContext.Create();
            var auctionsRepository = new AuctionsRepository(serviceDbContext);
            var auctionsController = new AuctionsController(auctionsRepository);
            
            var currentBid = new BidDto
            {
                AuctionId = 1,
                SupplierId = 3,
                Amount = 10.34M
            };

            var results = auctionsController.PostBid(currentBid);
        }
    }

}
