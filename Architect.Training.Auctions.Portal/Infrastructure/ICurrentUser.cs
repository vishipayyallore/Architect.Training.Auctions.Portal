using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Training.Auctions.Portal.Models;

namespace Architect.Training.Auctions.Portal.Infrastructure
{
    
    public interface ICurrentUser
    {
        ApplicationUser User { get; }
    }

}
