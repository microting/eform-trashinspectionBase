using System;
using System.Linq;
using eFormShared;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Producer : BaseTrashInspectionEntity, IDataAccessObject<TrashInspectionPnDbContext>
    {        
        public int Version { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ForeignId { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string ZipCode { get; set; }
        
        public string Phone { get; set; }
        
        public string ContactPerson { get; set; }

        public void Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.Producers.Add(this);
            dbContext.SaveChanges();

            dbContext.ProducerVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();

            Id = Id;
        }

        public void Update(TrashInspectionPnDbContext dbContext)
        {
            Producer producer = dbContext.Producers.FirstOrDefault(x => x.Id == Id);

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
                dbContext.SaveChanges();

                dbContext.ProducerVersions.Add(MapVersions(dbContext, producer));
                dbContext.SaveChanges();
            }
        }

        public void Delete(TrashInspectionPnDbContext dbContext)
        {
            Producer producer = dbContext.Producers.FirstOrDefault(x => x.Id == Id);

            if (producer == null)
            {
                throw new NullReferenceException($"Could not find producer with id: {Id}");
            }

            producer.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                                producer.UpdatedAt = DateTime.UtcNow;
                                producer.Version += 1;
                                dbContext.SaveChanges();
                
                                dbContext.ProducerVersions.Add(MapVersions(dbContext, producer));
                                dbContext.SaveChanges();
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