using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
}