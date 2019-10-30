using Microsoft.EntityFrameworkCore;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data
{
    public class TrashInspectionPnDbContext : DbContext, IPluginDbContext
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
        public DbSet<TrashInspectionCase> TrashInspectionCases { get; set; }
        public DbSet<TrashInspectionCaseVersion> TrashInspectionCaseVersions { get; set; }
        public DbSet<Fraction> Fractions { get; set; }
        public DbSet<FractionVersion> FractionVersions { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<SegmentVersion> SegmentVersions { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<TransporterVersion> TransporterVersions { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProducerVersion> ProducerVersions { get; set; }
        
        
        public virtual Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade ContextDatabase
        {
            get => base.Database;
        }

        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }
        public DbSet<PluginPermission> PluginPermissions { get; set; }
        public DbSet<PluginGroupPermission> PluginGroupPermissions { get; set; }
        public DbSet<PluginGroupPermissionVersion> PluginGroupPermissionVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PluginGroupPermissionVersion>()
                .HasOne(x => x.PluginGroupPermission)
                .WithMany()
                .HasForeignKey("FK_PluginGroupPermissionVersions_PluginGroupPermissionId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}