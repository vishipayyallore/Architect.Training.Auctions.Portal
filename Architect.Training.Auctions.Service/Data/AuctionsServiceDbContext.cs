using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Architect.Training.Auctions.Service.Models;
using Architect.Training.Auctions.Service.Models.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Architect.Training.Auctions.Service.Data
{

    public class AuctionsServiceDbContext : IdentityDbContext<ApplicationUser>
    {

        private const string DefaultDatabaseConnection = "Server=LORDKRISHNA-PC;Database=Auctions;User Id=sa;Password=sample123$; MultipleActiveResultSets=True;";

        //base("DefaultConnection", throwIfV1Schema: false)

        //TODO: Replace with "DefaultConnection" string.
        public AuctionsServiceDbContext()
            : base(DefaultDatabaseConnection, throwIfV1Schema: false)
        {
        }

        public static AuctionsServiceDbContext Create()
        {
            return new AuctionsServiceDbContext();
        }

        #region Tables
        /// <summary>
        /// Log Table
        /// </summary>
        public DbSet<LogAction> Logs { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

}