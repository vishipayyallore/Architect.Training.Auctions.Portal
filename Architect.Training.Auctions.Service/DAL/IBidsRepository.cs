using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Training.Auctions.Service.Models.Domain;

namespace Architect.Training.Auctions.Service.DAL
{
    public interface IBidsRepository : IDisposable
    {
        Task<Int64> AddBid(Bid currentBid);
    }

}
