using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class InstallationSite : BaseEntity
    {
        [ForeignKey("Installation")]
        public int InstallationId { get; set; }

        public int SDKSiteId { get; set; }

        public async Task Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            await dbContext.InstallationSites.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.InstallationSiteVersions.AddAsync(MapVersions(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TrashInspectionPnDbContext dbContext)
        {
            InstallationSite installationSite = await dbContext.InstallationSites.FirstOrDefaultAsync(x => x.Id == Id);

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

                await dbContext.InstallationSiteVersions.AddAsync(MapVersions(this));
                await dbContext.SaveChangesAsync();
            }  
            
        }

        public async Task Delete(TrashInspectionPnDbContext dbContext)
        {
            InstallationSite installationSite = await dbContext.InstallationSites.FirstOrDefaultAsync(x => x.Id == Id);

            if (installationSite == null)
            {
                throw new NullReferenceException($"Could not find installationSite with id {Id}");
            }

            installationSite.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                installationSite.UpdatedAt = DateTime.UtcNow;
                installationSite.Version += 1; 
                await dbContext.InstallationSiteVersions.AddAsync(MapVersions(this));
                await dbContext.SaveChangesAsync();
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