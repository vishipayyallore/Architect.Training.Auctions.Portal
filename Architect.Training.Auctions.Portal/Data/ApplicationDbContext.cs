using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Architect.Training.Auctions.Portal.Models;
using Architect.Training.Auctions.Portal.Models.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Architect.Training.Auctions.Portal.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        #region Tables
        public DbSet<LogAction> Logs { get; set; }
        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

}