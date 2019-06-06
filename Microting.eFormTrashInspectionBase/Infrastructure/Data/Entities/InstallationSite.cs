using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using eFormShared;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class InstallationSite : BaseTrashInspectionEntity
    {
        public int Version { get; set; }
        
        [ForeignKey("Installation")]
        public int InstallationId { get; set; }

        public int SDKSiteId { get; set; }

        public void Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.InstallationSites.Add(this);
            dbContext.SaveChanges();

            dbContext.InstallationSiteVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public void Update(TrashInspectionPnDbContext dbContext)
        {
            InstallationSite installationSite = dbContext.InstallationSites.FirstOrDefault(x => x.Id == Id);

            if (installationSite == null)
            {
                throw new NullReferenceException($"Could not find installationSite with id {Id}");
            }

            installationSite.WorkflowState = WorkflowState;
            installationSite.InstallationId = InstallationId;
            installationSite.SDKSiteId = SDKSiteId;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                installationSite.UpdatedAt = DateTime.UtcNow;
                installationSite.Version += 1;

                dbContext.InstallationSiteVersions.Add(MapVersions(this));
                dbContext.SaveChanges();
            }  
            
        }

        public void Delete(TrashInspectionPnDbContext dbContext)
        {
            InstallationSite installationSite = dbContext.InstallationSites.FirstOrDefault(x => x.Id == Id);

            if (installationSite == null)
            {
                throw new NullReferenceException($"Could not find installationSite with id {Id}");
            }

            installationSite.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                installationSite.UpdatedAt = DateTime.UtcNow;
                installationSite.Version += 1;

                dbContext.InstallationSiteVersions.Add(MapVersions(this));
                dbContext.SaveChanges();
            }  
        }

        private InstallationSiteVersion MapVersions(InstallationSite installationSite)
        {
            InstallationSiteVersion installationSiteVersion = new InstallationSiteVersion
            {
                Version = installationSite.Version,
                InstallationId = installationSite.InstallationId,
                SDKSiteId = installationSite.SDKSiteId,
                CreatedAt = installationSite.CreatedAt,
                UpdatedAt = installationSite.UpdatedAt,
                CreatedByUserId = installationSite.CreatedByUserId,
                UpdatedByUserId = installationSite.UpdatedByUserId,
                WorkflowState = installationSite.WorkflowState,
                InstallationSiteId = installationSite.Id
            };

            return installationSiteVersion;
        }
    }
}