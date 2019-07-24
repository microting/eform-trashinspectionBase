using System;
using System.Linq;
using Microting.eForm.Infrastructure.Constants;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Segment : BaseTrashInspectionEntity
    {        
        public int Version { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int SdkFolderId { get; set; }

        public void Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.Segments.Add(this);
            dbContext.SaveChanges();

            dbContext.SegmentVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public void Update(TrashInspectionPnDbContext dbContext)
        {
            Segment segment = dbContext.Segments.FirstOrDefault(x => x.Id == Id);

            if (segment == null)
            {
                throw new NullReferenceException($"Could not find segment with id {Id}");
            }

            segment.Version = Version;
            segment.Name = Name;
            segment.Description = Description;
            segment.SdkFolderId = SdkFolderId;
            segment.CreatedAt = CreatedAt;
            segment.UpdatedAt = UpdatedAt;
            segment.CreatedByUserId = CreatedByUserId;
            segment.UpdatedByUserId = UpdatedByUserId;
            segment.WorkflowState = WorkflowState;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                segment.UpdatedAt = DateTime.UtcNow;
                segment.Version += 1;

                dbContext.SegmentVersions.Add(MapVersions(this));
                dbContext.SaveChanges();
            } 
        }

        public void Delete(TrashInspectionPnDbContext dbContext)
        {
            Segment segment = dbContext.Segments.FirstOrDefault(x => x.Id == Id);

            if (segment == null)
            {
                throw new NullReferenceException($"Could not find segment with id {Id}");
            }

            segment.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                segment.UpdatedAt = DateTime.UtcNow;
                segment.Version += 1;

                dbContext.SegmentVersions.Add(MapVersions(this));
                dbContext.SaveChanges();
            }  
        }

        private SegmentVersion MapVersions(Segment segment)
        {
            SegmentVersion segmentVersion = new SegmentVersion
            {
                Version = segment.Version,
                Name = segment.Name,
                Description = segment.Description,
                SdkFolderId = segment.SdkFolderId,
                CreatedAt = segment.CreatedAt,
                UpdatedAt = segment.UpdatedAt,
                CreatedByUserId = segment.CreatedByUserId,
                UpdatedByUserId = segment.UpdatedByUserId,
                WorkflowState = segment.WorkflowState,
                SegmentId = segment.Id
            };

            return segmentVersion;
        }
        
    }
}