using System;
using System.Linq;
using eFormShared;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Fraction : BaseTrashInspectionEntity
    {        
        public int Version { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int eFormId { get; set; }
        
        public string ItemNumber { get; set; }
        
        public string LocationCode { get; set; }
        
        public int eFormIdExtendedInspection { get; set; }

        public void Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.Fractions.Add(this);
            dbContext.SaveChanges();

            dbContext.FractionVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public void Update(TrashInspectionPnDbContext dbContext)
        {
            Fraction fraction = dbContext.Fractions.FirstOrDefault(x => x.Id == Id);

            if (fraction == null)
            {
                throw new NullReferenceException($"Could not find fraction with id {Id}");
            }

            fraction.Version = Version;
            fraction.Name = Name;
            fraction.Description = Description;
            fraction.eFormId = eFormId;
            fraction.ItemNumber = ItemNumber;
            fraction.LocationCode = LocationCode;
            fraction.eFormIdExtendedInspection = eFormIdExtendedInspection;
            fraction.CreatedAt = CreatedAt;
            fraction.UpdatedAt = UpdatedAt;
            fraction.CreatedByUserId = CreatedByUserId;
            fraction.UpdatedByUserId = UpdatedByUserId;
            fraction.WorkflowState = WorkflowState;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                fraction.UpdatedAt = DateTime.UtcNow;
                fraction.Version += 1;

                dbContext.FractionVersions.Add(MapVersions(fraction));
                dbContext.SaveChanges();
            }   
        }

        public void Delete(TrashInspectionPnDbContext dbContext)
        {
            Fraction fraction = dbContext.Fractions.FirstOrDefault(x => x.Id == Id);

            if (fraction == null)
            {
                throw new NullReferenceException($"Could not find fraction with id {Id}");
            }

            fraction.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                fraction.UpdatedAt = DateTime.UtcNow;
                fraction.Version += 1;

                dbContext.FractionVersions.Add(MapVersions(fraction));
                dbContext.SaveChanges();
            }  
        }

        private FractionVersion MapVersions(Fraction fraction)
        {
            FractionVersion fractionVersion = new FractionVersion
            {
                Version = fraction.Version,
                Name = fraction.Name,
                Description = fraction.Description,
                eFormId = fraction.eFormId,
                ItemNumber = fraction.ItemNumber,
                LocationCode = fraction.LocationCode,
                eFormIdExtendedInspection = fraction.eFormIdExtendedInspection,
                CreatedAt = fraction.CreatedAt,
                UpdatedAt = fraction.UpdatedAt,
                CreatedByUserId = fraction.CreatedByUserId,
                UpdatedByUserId = fraction.UpdatedByUserId,
                WorkflowState = fraction.WorkflowState
            };

            return fractionVersion;
        }
    }
}