using System;
using System.Linq;
using eFormShared;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Transporter : BaseTrashInspectionEntity, IDataAccessObject<TrashInspectionPnDbContext>
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
            
            dbContext.Transporters.Add(this);
            dbContext.SaveChanges();

            dbContext.TransporterVersions.Add(MapVersions(dbContext, this));
            dbContext.SaveChanges();

            Id = Id;
        }

        public void Update(TrashInspectionPnDbContext dbContext)
        {
            Transporter transporter = dbContext.Transporters.FirstOrDefault(x => x.Id == Id);

            if (transporter == null)
            {
                throw new NullReferenceException($"Could not find transprter with id: {Id}");
            }

            transporter.Name = Name;
            transporter.Description = Description;
            transporter.ForeignId = ForeignId;
            transporter.Address = Address;
            transporter.City = City;
            transporter.ZipCode = ZipCode;
            transporter.Phone = Phone;
            transporter.ContactPerson = ContactPerson;

            if (dbContext.ChangeTracker.HasChanges())
            {
                transporter.UpdatedAt = DateTime.UtcNow;
                transporter.Version += 1;
                dbContext.SaveChanges();

                dbContext.TransporterVersions.Add(MapVersions(dbContext, transporter));
                dbContext.SaveChanges();
            }
        }

        public void Delete(TrashInspectionPnDbContext dbContext)
        {
            Transporter transporter = dbContext.Transporters.FirstOrDefault(x => x.Id == Id);

            if (transporter == null)
            {
                throw new NullReferenceException($"Could not find transporter with id: {Id}");
            }

            transporter.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                transporter.UpdatedAt = DateTime.UtcNow;
                transporter.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.TransporterVersions.Add(MapVersions(dbContext, transporter));
                dbContext.SaveChanges();
            }
        }
        
        public TransporterVersion MapVersions(TrashInspectionPnDbContext _dbContext, Transporter transporter)
        {
            TransporterVersion transporterVersion = new TransporterVersion();

            transporterVersion.Name = transporter.Name;
            transporterVersion.Description = transporter.Description;
            transporterVersion.ForeignId = transporter.ForeignId;
            transporterVersion.Address = transporter.Address;
            transporterVersion.City = transporter.City;
            transporterVersion.ZipCode = transporter.ZipCode;
            transporterVersion.Phone = transporter.Phone;
            transporterVersion.ContactPerson = transporter.ContactPerson;
            transporterVersion.Version = transporter.Version;
            transporterVersion.CreatedAt = transporter.CreatedAt;
            transporterVersion.UpdatedAt = transporter.UpdatedAt;
            transporterVersion.CreatedByUserId = transporter.CreatedByUserId;
            transporterVersion.UpdatedByUserId = transporter.UpdatedByUserId;
            transporterVersion.WorkflowState = transporter.WorkflowState;

            transporterVersion.TransporterId = transporter.Id;

            return transporterVersion;
        }
    }
}