using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Architect.Training.Auctions.Service.Models.Domain;

namespace Architect.Training.Auctions.Service.Models.DTO
{
    public class AuctionsListDto
    {

        public RegisteredUser CurrentUser { get; set; }

        public List<AuctionItem> CurrentAuctions { get; set; }
    }
}