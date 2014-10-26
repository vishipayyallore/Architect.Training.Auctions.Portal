using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.Training.Auctions.Service.Models.Domain
{
    public class AuctionItem
    {

        public Auction CurrentAuction { get; set; }
        
        public TimeSpan TimeRemaining
        {
            get { return (CurrentAuction.EndTime - CurrentAuction.StartTime) - (DateTime.Now - CurrentAuction.StartTime); }
        }

        public Bid LowestBid { get; set; }

        public List<Bid> CurrentBids { get; set; }

    }
}