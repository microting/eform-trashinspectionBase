using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class TrashInspectionVersion : BaseEntity
    {
        public int Version { get; set; }

        public string WeighingNumber { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string RegistrationNumber { get; set; }

        public string TrashFraction { get; set; }
        
        public int? FractionId { get; set; }

        public string EakCode { get; set; }

        public string Producer { get; set; }

        public string Transporter { get; set; }

        public int? InstallationId { get; set; }

        public bool MustBeInspected { get; set; }
        
        public int Status { get; set; }

        [ForeignKey("TrashInspection")]
        public int TrashInspctionId { get; set; }
        
        public int? SegmentId { get; set; }
        
        public bool ExtendedInspection { get; set; }
        
        public bool InspectionDone { get; set; }
        
        public bool IsApproved { get; set; }
        
        public string ApprovedValue { get; set; }
        
        public string Comment { get; set; }
    }
}