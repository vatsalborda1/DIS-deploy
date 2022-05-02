using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FBIApplication.Models;

namespace FBIApplication.Data
{
    public class FBIApplicationContext : DbContext
    {
        public FBIApplicationContext (DbContextOptions<FBIApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FBIApplication.Models.ParticipationModel> ParticipationModel { get; set; }

        public DbSet<FBIApplication.Models.Result> Result { get; set; }

        public DbSet<FBIApplication.Models.PoliceModel> PoliceModel { get; set; }
    }
}
