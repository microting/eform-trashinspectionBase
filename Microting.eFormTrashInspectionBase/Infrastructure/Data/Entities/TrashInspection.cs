using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using eFormShared;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class TrashInspection : BaseTrashInspectionEntity
    {

        public TrashInspection()
        {
            TrashInspectionCases = new HashSet<TrashInspectionCase>();
        }

        public int Version { get; set; }

        public string WeighingNumber { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string RegistrationNumber { get; set; }

        public string TrashFraction { get; set; }
        
        [ForeignKey("Fraction")]
        public int? FractionId { get; set; }

        public string Eak_Code { get; set; }

        public string Producer { get; set; }

        public string Transporter { get; set; }
        
        [ForeignKey("Installation")]
        public int? InstallationId { get; set; }

        public bool MustBeInspected { get; set; }
        
        public int Status { get; set; }
        
        [ForeignKey("Segment")]
        public int? SegmentId { get; set; }
        
        public bool ExtendedInspection { get; set; }
        
        public bool InspectionDone { get; set; }
        
        public virtual ICollection<TrashInspectionCase> TrashInspectionCases { get; set; }
        
        public bool IsApproved { get; set; }
        
        public string ApprovedValue { get; set; }
        
        public string Comment { get; set; }
        
        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        
        [ForeignKey("Transporter")]
        public int? TransporterId { get; set; }

        public void Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.TrashInspections.Add(this);
            dbContext.SaveChanges();

            dbContext.TrashInspectionVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public void Update(TrashInspectionPnDbContext dbContext)
        {
            TrashInspection trashInspection = dbContext.TrashInspections.FirstOrDefault(x => x.Id == Id);

            if (trashInspection == null)
            {
                throw new NullReferenceException($"Could not find trashInspection with id: {Id}");
            }

            trashInspection.Status = Status;
            trashInspection.ProducerId = ProducerId;
            trashInspection.TransporterId = TransporterId;
            trashInspection.FractionId = FractionId;
            trashInspection.SegmentId = SegmentId;
            trashInspection.InstallationId = InstallationId;
            trashInspection.Comment = Comment;
            trashInspection.IsApproved = IsApproved;
            trashInspection.ApprovedValue = ApprovedValue;
            trashInspection.InspectionDone = InspectionDone;

            if (dbContext.ChangeTracker.HasChanges())
            {
                trashInspection.UpdatedAt = DateTime.UtcNow;
                trashInspection.Version += 1;

                dbContext.TrashInspectionVersions.Add(MapVersions(trashInspection));
                dbContext.SaveChanges();
            }                       
        }

        public void Delete(TrashInspectionPnDbContext dbContext)
        {
            TrashInspection trashInspection = dbContext.TrashInspections.FirstOrDefault(x => x.Id == Id);

            if (trashInspection == null)
            {
                throw new NullReferenceException($"Could not find trashInspection with id: {Id}");
            }

            trashInspection.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                trashInspection.UpdatedAt = DateTime.UtcNow;
                trashInspection.Version += 1;

                dbContext.TrashInspectionVersions.Add(MapVersions(trashInspection));
                dbContext.SaveChanges();
            }  
        }

        private TrashInspectionVersion MapVersions(TrashInspection trashInspection)
        {
            TrashInspectionVersion trashInspectionVersion = new TrashInspectionVersion
            {
                Version = trashInspection.Version,
                WeighingNumber = trashInspection.WeighingNumber,
                Date = trashInspection.Date,
                Time = trashInspection.Time,
                ApprovedValue = trashInspection.ApprovedValue,
                Comment = trashInspection.Comment,
                CreatedAt = trashInspection.CreatedAt,
                CreatedByUserId = trashInspection.CreatedByUserId,
                EakCode = trashInspection.Eak_Code,
                ExtendedInspection = trashInspection.ExtendedInspection,
                RegistrationNumber = trashInspection.RegistrationNumber,
                TrashFraction = trashInspection.TrashFraction,
                FractionId = trashInspection.FractionId,
                Producer = trashInspection.Producer,
                Transporter = trashInspection.Transporter,
                InstallationId = trashInspection.InstallationId,
                MustBeInspected = trashInspection.MustBeInspected,
                Status = trashInspection.Status,
                SegmentId = trashInspection.SegmentId,
                InspectionDone = trashInspection.InspectionDone,
                IsApproved = trashInspection.IsApproved,
                ProducerId = trashInspection.ProducerId,
                TransporterId = trashInspection.TransporterId
            };

            return trashInspectionVersion;
        }
    }
}