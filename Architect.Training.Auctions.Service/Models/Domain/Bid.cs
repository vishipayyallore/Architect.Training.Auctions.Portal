using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.Training.Auctions.Service.Models.Domain
{
    public class Bid
    {
        public Int64 Id { get; set; }

        public Int64 AuctionId { get; set; }

        public Int64 SupplierId { get; set; }

        public Decimal Amount { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}