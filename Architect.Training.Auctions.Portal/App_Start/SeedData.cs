using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Architect.Training.Auctions.Portal.Data;
using Architect.Training.Auctions.Portal.DependencyResolution.Tasks;

namespace Architect.Training.Auctions.Portal.App_Start
{
    public class SeedData : IRunAtStartup
    {
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Execute()
        {
            //TODO: Need to Initialize the database in future
        }

    }
}