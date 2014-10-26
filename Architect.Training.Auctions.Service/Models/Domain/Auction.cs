using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architect.Training.Auctions.Service.Models.Domain
{

    public class Auction
    {

        public Auction()
        {
        }

        public Int64 Id { get; set; }
        public Int64 BuyerId { get; set; }
        public String ItemName { get; set; }
        public String Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }

}