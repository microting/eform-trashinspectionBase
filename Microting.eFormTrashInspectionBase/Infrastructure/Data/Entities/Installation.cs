using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Installation : BaseEntity
    {
        public Installation()
        {
            this.InstallationSites = new HashSet<InstallationSite>();
        }
        
        public string Name { get; set; }
        
        public virtual ICollection<InstallationSite> InstallationSites { get; set; }

        public async Task Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            await dbContext.Installations.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.InstallationVersions.AddAsync(MapVersions(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TrashInspectionPnDbContext dbContext)
        {
            Installation installation = await dbContext.Installations.FirstOrDefaultAsync(x => x.Id == Id);

            if (installation == null)
            {
                throw new NullReferenceException($"Could not find installation with id {Id}");
            }

            installation.WorkflowState = WorkflowState;
            installation.Name = Name;
            installation.CreatedByUserId = CreatedByUserId;
            installation.UpdatedByUserId = UpdatedByUserId;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                installation.UpdatedAt = DateTime.UtcNow;
                installation.Version += 1;

                await dbContext.InstallationVersions.AddAsync(MapVersions(this));
                await dbContext.SaveChangesAsync();
            }  
        }

        public async Task Delete(TrashInspectionPnDbContext dbContext)
        {
            Installation installation = await dbContext.Installations.FirstOrDefaultAsync(x => x.Id == Id);

            if (installation == null)
            {
                throw new NullReferenceException($"Could not find installation with id {Id}");
            }

            installation.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                installation.UpdatedAt = DateTime.UtcNow;
                installation.Version += 1;

                await dbContext.InstallationVersions.AddAsync(MapVersions(this));
                await dbContext.SaveChangesAsync();
            }  
        }

        private InstallationVersion MapVersions(Installation installation)
        {
            InstallationVersion installationVersion = new InstallationVersion
            {
                Version = installation.Version,
                Name = installation.Name,
                CreatedAt = installation.CreatedAt,
                UpdatedAt = installation.UpdatedAt,
                CreatedByUserId = installation.CreatedByUserId,
                UpdatedByUserId = installation.UpdatedByUserId,
                WorkflowState = installation.WorkflowState,
                InstallationId = installation.Id
            };

            return installationVersion;
        }
    }
}