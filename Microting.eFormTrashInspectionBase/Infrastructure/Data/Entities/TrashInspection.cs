using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class TrashInspection : BaseEntity
    {

        public TrashInspection()
        {
            TrashInspectionCases = new HashSet<TrashInspectionCase>();
        }
        
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
        
        public bool ConditionalApproved { get; set; }
        
        public string Comment { get; set; }
        
        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        
        [ForeignKey("Transporter")]
        public int? TransporterId { get; set; }
        
        public int? FirstWeight { get; set; }
        
        public int? SecondWeight { get; set; }
        
        public string ErrorFromCallBack { get; set; }

        public async Task Create(TrashInspectionPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            await dbContext.TrashInspections.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.TrashInspectionVersions.AddAsync(MapVersions(this));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TrashInspectionPnDbContext dbContext)
        {
            TrashInspection trashInspection = await dbContext.TrashInspections.FirstOrDefaultAsync(x => x.Id == Id);

            if (trashInspection == null)
            {
                throw new NullReferenceException($"Could not find trashInspection with id: {Id}");
            }

            trashInspection.WeighingNumber = WeighingNumber;
            trashInspection.Date = Date;
            trashInspection.Time = Time;
            trashInspection.ApprovedValue = ApprovedValue;
            trashInspection.ConditionalApproved = ConditionalApproved;
            trashInspection.Comment = Comment;
            trashInspection.Eak_Code = Eak_Code;
            trashInspection.ExtendedInspection = ExtendedInspection;
            trashInspection.RegistrationNumber = RegistrationNumber;
            trashInspection.TrashFraction = TrashFraction;
            trashInspection.FractionId = FractionId;
            trashInspection.Producer = Producer;
            trashInspection.Transporter = Transporter;
            trashInspection.InstallationId = InstallationId;
            trashInspection.MustBeInspected = MustBeInspected;
            trashInspection.Status = Status;
            trashInspection.SegmentId = SegmentId;
            trashInspection.InspectionDone = InspectionDone;
            trashInspection.IsApproved = IsApproved;
            trashInspection.ProducerId = ProducerId;
            trashInspection.TransporterId = TransporterId;
            trashInspection.FirstWeight = FirstWeight;
            trashInspection.SecondWeight = SecondWeight;

            if (dbContext.ChangeTracker.HasChanges())
            {
                trashInspection.UpdatedAt = DateTime.UtcNow;
                trashInspection.Version += 1;

                await dbContext.TrashInspectionVersions.AddAsync(MapVersions(trashInspection));
                await dbContext.SaveChangesAsync();
            }                       
        }

        public async Task Delete(TrashInspectionPnDbContext dbContext)
        {
            TrashInspection trashInspection = await dbContext.TrashInspections.FirstOrDefaultAsync(x => x.Id == Id);

            if (trashInspection == null)
            {
                throw new NullReferenceException($"Could not find trashInspection with id: {Id}");
            }

            trashInspection.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                trashInspection.UpdatedAt = DateTime.UtcNow;
                trashInspection.Version += 1;

                await dbContext.TrashInspectionVersions.AddAsync(MapVersions(trashInspection));
                await dbContext.SaveChangesAsync();
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
                ConditionalApproved = trashInspection.ConditionalApproved,
                Comment = trashInspection.Comment,
                CreatedAt = trashInspection.CreatedAt,
                CreatedByUserId = trashInspection.CreatedByUserId,
                UpdatedAt = trashInspection.UpdatedAt,
                UpdatedByUserId = trashInspection.UpdatedByUserId,
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
                TransporterId = trashInspection.TransporterId,
                FirstWeight = trashInspection.FirstWeight,
                SecondWeight = trashInspection.SecondWeight,
                TrashInspectionId = trashInspection.Id,
                WorkflowState = trashInspection.WorkflowState
            };

            return trashInspectionVersion;
        }
    }
}