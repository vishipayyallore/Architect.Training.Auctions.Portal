/*
 * Author: Swamy PKV
 * Date: 26-Aug-2014
 * Description: 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Architect.Training.Auctions.Service.Models;
using Architect.Training.Auctions.Service.Models.Domain;
using Architect.Training.Auctions.Service.Models.DTO;

namespace Architect.Training.Auctions.Service.DAL
{

    public interface IAuctionsRepository : IDisposable
    {

        #region Methods
        AuctionsListDto GetAllAuctionsOfAUser(String userId);

        Task<Int64> AddAuction(Auction currentAuction);

        #endregion

    }

}
