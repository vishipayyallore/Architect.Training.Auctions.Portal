using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Architect.Training.Auctions.Service.Data;
using Architect.Training.Auctions.Service.Models.Domain;

namespace Architect.Training.Auctions.Service.DAL
{
    public class BidsRepository : IBidsRepository
    {

        private bool _disposed = false;
        private readonly AuctionsServiceDbContext _auctionsDbContext;

        public BidsRepository(AuctionsServiceDbContext auctionsDbContext)
        {
            _auctionsDbContext = auctionsDbContext;
        }

        public async Task<Int64> AddBid(Bid currentBid)
        {
            try
            {
                _auctionsDbContext.Bids.Add(currentBid);
                return await _auctionsDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                throw;
            }
            //TODO: [Query] Do we need to log Error information from Web API???
        }

        #region Disposing Logic
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _auctionsDbContext.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion
    }
}