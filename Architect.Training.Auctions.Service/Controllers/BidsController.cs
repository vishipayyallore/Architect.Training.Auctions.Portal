using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Architect.Training.Auctions.Service.DAL;
using Architect.Training.Auctions.Service.Models.Domain;
using Architect.Training.Auctions.Service.Models.DTO;

namespace Architect.Training.Auctions.Service.Controllers
{
    public class BidsController : ApiController
    {

        #region Variables.
        private readonly IBidsRepository _bidsRepository;
        #endregion

        public BidsController(IBidsRepository bidsRepository)
        {
            _bidsRepository = bidsRepository;
        }


        public async Task<IHttpActionResult> PostBid(BidDto currentBidDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO: Need to write the Auto Mapper Stuff
            var currentBid = new Bid()
            {
                AuctionId = currentBidDto.AuctionId,
                SupplierId = currentBidDto.SupplierId,
                Amount = currentBidDto.Amount
            };

            await _bidsRepository.AddBid(currentBid);

            //Store the Id back into DTO object
            currentBidDto.Id = currentBid.Id;

            return CreatedAtRoute("DefaultApi", new { id = currentBidDto.Id }, currentBidDto);
        }
    }
}