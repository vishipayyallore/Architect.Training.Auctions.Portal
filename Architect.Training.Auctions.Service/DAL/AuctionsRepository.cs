using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Architect.Training.Auctions.Service.Data;
using Architect.Training.Auctions.Service.Models;
using Architect.Training.Auctions.Service.Models.Domain;
using Architect.Training.Auctions.Service.Models.DTO;

namespace Architect.Training.Auctions.Service.DAL
{

    /// <summary>
    /// 
    /// </summary>
    public class AuctionsRepository : IAuctionsRepository
    {

        #region Variables.
        private bool _disposed = false;
        private readonly AuctionsServiceDbContext _auctionsDbContext;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auctionsDbContext"></param>
        public AuctionsRepository(AuctionsServiceDbContext auctionsDbContext)
        {
            _auctionsDbContext = auctionsDbContext;
        }

        #region Auctions Repository Methods.
        public async Task<AuctionsListDto> GetAllAuctions(string userId)
        {
            //Variables.
            var auctionsList = new AuctionsListDto();
            auctionsList.CurrentAuctions = new List<AuctionItem>();

            auctionsList.CurrentUser = _auctionsDbContext.RegisteredUsers.SingleOrDefault(user => (user.UserId == userId));
            if (auctionsList.CurrentUser == null)
            {
                return auctionsList;
            }

            var auctionRows = from auction in _auctionsDbContext.Auctions
                              where auction.BuyerId == auctionsList.CurrentUser.Id
                              select auction;

            foreach (var auctionRow in auctionRows)
            {
                var auctionItem = new AuctionItem
                {
                    CurrentBids =
                        (from bid in _auctionsDbContext.Bids 
                         orderby bid.Amount ascending 
                         where bid.AuctionId == auctionRow.Id 
                         select bid).ToList(),
                    CurrentAuction = auctionRow
                };
                auctionsList.CurrentAuctions.Add(auctionItem);
            }

            return auctionsList;
        }

        //public async Task<IHttpActionResult> GetAllAuctions(string userId)
        //{
            

        //    ////Retrieving the User Information.
        //    ////await _auctionsDbContext.Set<RegisteredUser>().SingleOrDefault(user => user.UserId == userId);
        //    //var currentUser = _auctionsDbContext.RegisteredUsers.SingleOrDefault(user => (user.UserId == userId));
        //    //if (currentUser == null)
        //    //{
        //    //    //TODO: Throw exception
        //    //    //return NotFound();
        //    //}

        //    throw new NotImplementedException();
        //}

        public async Task<IHttpActionResult> AddAuction(AuctionDto currentAuctionDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Disposing Logic
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _auctionsDbContext.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion


    }
}


//public AuctionsRepository(AuctionsEntities auctionsDbContext)
//{
//    this.auctionsDbContext = auctionsDbContext;
//}

//#region Methods
//public AuctionsViewModel GetUserAuctions(string userEmail)
//{
//    //TODO: Remove this if block
//    if (string.IsNullOrEmpty(userEmail))
//    {
//        userEmail = "shiva.sai@citigroup.com";
//    }

//    var auctionsData = new AuctionsViewModel();
//    var userInfo = new User();
//    var auctionItemsList = new List<AuctionItemViewModel>();
//    var bidsList = new List<BidViewModel>();

//    //Retrieving the information from ASP.Net Table.
//    var loginUser = auctionsDbContext.AspNetUsers.SingleOrDefault(user => (user.Email == userEmail));
//    if (loginUser == null) return auctionsData;

//    //Retrieving the Registered Users information.
//    var userData = auctionsDbContext.RegisteredUsers.SingleOrDefault(user => (user.UserId == loginUser.Id));
//    if (userData == null) return auctionsData;
//    userInfo.UserId = userData.Id;
//    userInfo.FirstName = userData.FirstName;
//    userInfo.LastName = userData.LastName;
//    userInfo.Email = userEmail;
//    auctionsData.UserInfo = userInfo;

//    var auctionItems = auctionsDbContext.AuctionItems.ToList().Where(auction => (auction.BuyerId == userData.Id)).ToList();
//    foreach (var auctionItem in auctionItems)
//    {
//        var auction = new AuctionItemViewModel()
//        {
//            Id = auctionItem.Id,
//            BuyerId = auctionItem.BuyerId,
//            ItemName = auctionItem.ItemName,
//            Description = auctionItem.Description,
//            AuctionStatus = auctionItem.AuctionStatus,
//            StartDateTime = auctionItem.StartTime,
//            EndDateTime = auctionItem.EndTime
//        };

//        foreach (var currentBid in auctionItem.Bids.Select(bid => new BidViewModel()
//        {
//            Id = bid.Id,
//            AuctionId = bid.AuctionId,
//            SupplierId = bid.SupplierId,
//            Amount = bid.Amount
//        }))
//        {
//            bidsList.Add(currentBid);
//        }
//        auction.CurrentBids = bidsList;

//        auction.LowestBid = auction.CurrentBids.OrderBy(bid => bid.Amount).FirstOrDefault();

//        auctionItemsList.Add(auction);
//    }

//    auctionsData.AuctionItems = auctionItemsList;

//    return auctionsData;
//}
//#endregion
