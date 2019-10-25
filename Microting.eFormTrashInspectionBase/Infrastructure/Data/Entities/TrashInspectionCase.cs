using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionCase : BaseEntity
    {                
        public int Status { get; set; }
        
        [ForeignKey("TrashInspection")]
        public int TrashInspectionId { get; set; }
        
        public string SdkCaseId { get; set; }
        
        public int SdkSiteId { get; set; }
        
        [ForeignKey("Segment")]
        public int SegmentId { get; set; }
        
        public async Task Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            await dbContext.TrashInspectionCases.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.TrashInspectionCaseVersions.AddAsync(MapVersions(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TrashInspectionPnDbContext dbContext)
        {
            TrashInspectionCase trashInspection = await dbContext.TrashInspectionCases.FirstOrDefaultAsync(x => x.Id == Id);

            if (trashInspection == null)
            {
                throw new NullReferenceException($"Could not find TrashInspectionCase with id: {Id}");
            }

            trashInspection.Status = Status;
            trashInspection.TrashInspectionId = TrashInspectionId;
            trashInspection.SdkCaseId = SdkCaseId;
            trashInspection.SdkSiteId = SdkSiteId;
            trashInspection.Version = Version;
            trashInspection.SegmentId = SegmentId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                trashInspection.UpdatedAt = DateTime.UtcNow;
                trashInspection.Version += 1;

                await dbContext.TrashInspectionCaseVersions.AddAsync(MapVersions(trashInspection));
                await dbContext.SaveChangesAsync();
            }                       
        }

        public async Task Delete(TrashInspectionPnDbContext dbContext)
        {
            TrashInspectionCase trashInspection = await dbContext.TrashInspectionCases.FirstOrDefaultAsync(x => x.Id == Id);

            if (trashInspection == null)
            {
                throw new NullReferenceException($"Could not find TrashInspectionCase with id: {Id}");
            }

            trashInspection.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                trashInspection.UpdatedAt = DateTime.UtcNow;
                trashInspection.Version += 1;

                await dbContext.TrashInspectionCaseVersions.AddAsync(MapVersions(trashInspection));
                await dbContext.SaveChangesAsync();
            }  
        }

        private TrashInspectionCaseVersion MapVersions(TrashInspectionCase trashInspectionCase)
        {
            TrashInspectionCaseVersion trashInspectionVersion = new TrashInspectionCaseVersion
            {
                Status = trashInspectionCase.Status,
                TrashInspectionId = trashInspectionCase.TrashInspectionId,
                SdkCaseId = trashInspectionCase.SdkCaseId,
                SdkSiteId = trashInspectionCase.SdkSiteId,
                Version = trashInspectionCase.Version,
                SegmentId = trashInspectionCase.SegmentId,
                UpdatedAt = trashInspectionCase.UpdatedAt,
                UpdatedByUserId = trashInspectionCase.UpdatedByUserId,
                CreatedAt = trashInspectionCase.CreatedAt,
                CreatedByUserId = trashInspectionCase.CreatedByUserId,
                WorkflowState = trashInspectionCase.WorkflowState,
                TrashInspectionCaseId = trashInspectionCase.Id
            };

            return trashInspectionVersion;
        }
    }
}