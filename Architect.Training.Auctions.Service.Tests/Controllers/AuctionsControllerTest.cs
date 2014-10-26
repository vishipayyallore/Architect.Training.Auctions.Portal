using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Training.Auctions.Service.Controllers;
using Architect.Training.Auctions.Service.DAL;
using Architect.Training.Auctions.Service.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.Training.Auctions.Service.Tests.Controllers
{

    [TestClass]
    public class AuctionsControllerTest
    {

        [TestMethod]
        public void GivenUserIdShouldReturnAllAuctions()
        {

            var serviceDbContext = new AuctionsServiceDbContext();
            var auctionsRepository = new AuctionsRepository(serviceDbContext);
            var auctionsController = new AuctionsController(auctionsRepository);

            var results = auctionsController.GetAllAuctions(string.Empty);
            //GetAllAuctions
        }
    }

}
