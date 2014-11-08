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
            get { return (CurrentAuction.EndDateTime - CurrentAuction.StartDateTime) - (DateTime.Now - CurrentAuction.StartDateTime); }
        }

        public Bid LowestBid
        {
            get { return CurrentBids.FirstOrDefault(); }
            
        }

        public List<Bid> CurrentBids { get; set; }

    }
}