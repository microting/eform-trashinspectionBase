using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Producer : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ForeignId { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string ZipCode { get; set; }
        
        public string Phone { get; set; }
        
        public string ContactPerson { get; set; }

        public async Task Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            await dbContext.Producers.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.ProducerVersions.AddAsync(MapVersions(dbContext, this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TrashInspectionPnDbContext dbContext)
        {
            Producer producer = await dbContext.Producers.FirstOrDefaultAsync(x => x.Id == Id);

            if (producer == null)
            {
                throw new NullReferenceException($"Could not find producer with id: {Id}");
            }

            producer.Name = Name;
            producer.Description = Description;
            producer.ForeignId = ForeignId;
            producer.Address = Address;
            producer.City = City;
            producer.ZipCode = ZipCode;
            producer.Phone = Phone;
            producer.ContactPerson = ContactPerson;

            if (dbContext.ChangeTracker.HasChanges())
            {
                producer.UpdatedAt = DateTime.UtcNow;
                producer.Version += 1;
                await dbContext.SaveChangesAsync();

                await dbContext.ProducerVersions.AddAsync(MapVersions(dbContext, producer));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(TrashInspectionPnDbContext dbContext)
        {
            Producer producer = await dbContext.Producers.FirstOrDefaultAsync(x => x.Id == Id);

            if (producer == null)
            {
                throw new NullReferenceException($"Could not find producer with id: {Id}");
            }

            producer.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                producer.UpdatedAt = DateTime.UtcNow;
                producer.Version += 1;
                await dbContext.SaveChangesAsync();
                
                await dbContext.ProducerVersions.AddAsync(MapVersions(dbContext, producer));
                await dbContext.SaveChangesAsync();
            }
        }
        public ProducerVersion MapVersions(TrashInspectionPnDbContext _dbContext, Producer producer)
        {
            ProducerVersion producerVersion = new ProducerVersion
            {
                Name = producer.Name,
                Description = producer.Description,
                ForeignId = producer.ForeignId,
                Address = producer.Address,
                City = producer.City,
                ZipCode = producer.ZipCode,
                Phone = producer.Phone,
                ContactPerson = producer.ContactPerson,
                Version = producer.Version,
                CreatedAt = producer.CreatedAt,
                UpdatedAt = producer.UpdatedAt,
                CreatedByUserId = producer.CreatedByUserId,
                UpdatedByUserId = producer.UpdatedByUserId,
                WorkflowState = producer.WorkflowState,
                ProducerId = producer.Id
            };

            return producerVersion;
        }
    }
}