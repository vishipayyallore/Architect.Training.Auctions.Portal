using System;
using Architect.Training.Auctions.Service.DAL;
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

            //TODO: Remove this if condition
            if (String.IsNullOrEmpty(userId))
            {
                userId = "b54b869c-127d-4b17-9d46-67f077105415";
            }
            
            var auctions = await _auctionsRepository.GetAllAuctions(userId);
            
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

            //TODO: Uncomment this after code is working.
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            await _auctionsRepository.AddAuction(currentAuctionDto);

            return CreatedAtRoute("DefaultApi", new { id = currentAuctionDto.Id }, currentAuctionDto);
        }
        #endregion

    }
}