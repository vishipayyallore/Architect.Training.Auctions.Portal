using System;
using Architect.Training.Auctions.Service.DAL;
using Architect.Training.Auctions.Service.Models.Domain;
using Architect.Training.Auctions.Service.Models.DTO;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.Training.Auctions.Service.Controllers
{
    public class AuctionsController : ApiController
    {

        #region Variables.
        private readonly IAuctionsRepository _auctionsRepository;
        #endregion

        public AuctionsController(IAuctionsRepository auctionsRepository)
        {
            _auctionsRepository = auctionsRepository;
        }

        #region Api Methods.
        /// <summary>
        /// Returns the List of Acutions for the Given User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ResponseType(typeof(AuctionsListDto))]
        public async Task<IHttpActionResult> GetAllAuctions(String userId)
        {
            
            //TODO: [Query] How can I convert this in Async?
            //TODO: [Query] What is the difference between Task<IHttpActionResult> And IQueryable<BookDTO>

            //TODO: Remove this if condition
            if (String.IsNullOrEmpty(userId))
            {
                userId = "b54b869c-127d-4b17-9d46-67f077105415";
            }
            
            var auctions = _auctionsRepository.GetAllAuctions(userId);
            
            if (auctions == null)
            {
                return NotFound();
            }
            return Ok(auctions);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentAuctionDto"></param>
        /// <returns></returns>
        [ResponseType(typeof(AuctionDto))]
        public async Task<IHttpActionResult> PostAuction(AuctionDto currentAuctionDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO: Need to write the Auto Mapper Stuff
            /*TODO: Remove CreatedDateTime assignment and make change in Database.*/
            var currentAuction = new Auction()
            {
                BuyerId = currentAuctionDto.BuyerId,
                ItemName = currentAuctionDto.ItemName,
                Description = currentAuctionDto.Description,
                StartDateTime = currentAuctionDto.StartDateTime,
                EndDateTime = currentAuctionDto.EndDateTime,
            };

            await _auctionsRepository.AddAuction(currentAuction);

            //Store the Id back into DTO object
            currentAuctionDto.Id = currentAuction.Id;

            return CreatedAtRoute("DefaultApi", new { id = currentAuctionDto.Id }, currentAuctionDto);
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

            await _auctionsRepository.AddBid(currentBid);

            //Store the Id back into DTO object
            currentBidDto.Id = currentBid.Id;

            return CreatedAtRoute("DefaultApi", new { id = currentBidDto.Id }, currentBidDto);
        }
        #endregion

    }
}