using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Fraction : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public int eFormId { get; set; }
        
        public string ItemNumber { get; set; }
        
        public string LocationCode { get; set; }
        
        public int eFormIdExtendedInspection { get; set; }

        public async Task Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            await dbContext.Fractions.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.FractionVersions.AddAsync(MapVersions(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TrashInspectionPnDbContext dbContext)
        {
            Fraction fraction = await dbContext.Fractions.FirstOrDefaultAsync(x => x.Id == Id);

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

                await dbContext.FractionVersions.AddAsync(MapVersions(fraction));
                await dbContext.SaveChangesAsync();
            }   
        }

        public async Task Delete(TrashInspectionPnDbContext dbContext)
        {
            Fraction fraction = await dbContext.Fractions.FirstOrDefaultAsync(x => x.Id == Id);

            if (fraction == null)
            {
                throw new NullReferenceException($"Could not find fraction with id {Id}");
            }

            fraction.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                fraction.UpdatedAt = DateTime.UtcNow;
                fraction.Version += 1;

                await dbContext.FractionVersions.AddAsync(MapVersions(fraction));
                await dbContext.SaveChangesAsync();
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
                WorkflowState = fraction.WorkflowState,
                FractionId = fraction.Id
            };

            return fractionVersion;
        }
    }
}