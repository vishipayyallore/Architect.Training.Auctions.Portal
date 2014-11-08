using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.Training.Auctions.Service.Models.DTO
{
    public class BidDto
    {
        public Int64 Id { get; set; }
        public Int64 AuctionId { get; set; }
        public Int64 SupplierId { get; set; }
        public Decimal Amount { get; set; }
    }
}