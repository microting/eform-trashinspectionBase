using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using eFormShared;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Installation : BaseTrashInspectionEntity
    {
        public Installation()
        {
            this.InstallationSites = new HashSet<InstallationSite>();
        }
        
        public int Version { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<InstallationSite> InstallationSites { get; set; }

        public void Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.Installations.Add(this);
            dbContext.SaveChanges();

            dbContext.InstallationVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public void Update(TrashInspectionPnDbContext dbContext)
        {
            Installation installation = dbContext.Installations.FirstOrDefault(x => x.Id == Id);

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

                dbContext.InstallationVersions.Add(MapVersions(this));
                dbContext.SaveChanges();
            }  
        }

        public void Delete(TrashInspectionPnDbContext dbContext)
        {
            Installation installation = dbContext.Installations.FirstOrDefault(x => x.Id == Id);

            if (installation == null)
            {
                throw new NullReferenceException($"Could not find installation with id {Id}");
            }

            installation.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                installation.UpdatedAt = DateTime.UtcNow;
                installation.Version += 1;

                dbContext.InstallationVersions.Add(MapVersions(this));
                dbContext.SaveChanges();
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