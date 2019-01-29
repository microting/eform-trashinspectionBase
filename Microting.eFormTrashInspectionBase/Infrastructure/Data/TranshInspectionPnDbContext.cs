using Microsoft.EntityFrameworkCore;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories
{
    public class TrashInspectionPnDbContext : DbContext
    {

        public TrashInspectionPnDbContext() { }

        public TrashInspectionPnDbContext(DbContextOptions<TrashInspectionPnDbContext> options) : base(options)
        {

        }

        public DbSet<Installation> Installations { get; set; }
        public DbSet<InstallationVersion> InstallationVersions { get; set;}
        public DbSet<InstallationSite> InstallationSites { get; set; }
        public DbSet<InstallationSiteVersion> InstallationSiteVersions { get; set; }
        public DbSet<TrashInspection> TrashInspections { get; set; }
        public DbSet<TrashInspectionVersion> TrashInspectionVersions { get; set; }
        public DbSet<TrashInspectionPnSetting> TrashInspectionPnSettings { get; set; }
        public DbSet<TrashInspectionPnSettingVersion> TrashInspectionPnSettingVersions { get; set; }
        public DbSet<TrashInspectionCase> TrashInspectionCases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}