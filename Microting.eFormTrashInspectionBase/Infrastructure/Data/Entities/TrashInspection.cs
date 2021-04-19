using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class TrashInspection : PnBase
    {
        public string WeighingNumber { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string RegistrationNumber { get; set; }

        public string TrashFraction { get; set; }

        public int? FractionId { get; set; }

        public virtual Fraction Fraction { get; set; }

        public string EakCode { get; set; }

        public string Transporter { get; set; }

        public int? InstallationId { get; set; }

        public virtual Installation Installation { get; set; }

        public bool MustBeInspected { get; set; }
        
        public int Status { get; set; }

        public int? SegmentId { get; set; }

        public virtual Segment Segment { get; set; }

        public bool ExtendedInspection { get; set; }
        
        public bool InspectionDone { get; set; }

        public virtual List<TrashInspectionCase> TrashInspectionCases { get; set; }
            = new List<TrashInspectionCase>();

        public bool IsApproved { get; set; }
        
        public string ApprovedValue { get; set; }
        
        public bool ConditionalApproved { get; set; }
        
        public string Comment { get; set; }
        
        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }

        public string Producer { get; set; }

        [ForeignKey("Transporter")]
        public int? TransporterId { get; set; }
        
        public int? FirstWeight { get; set; }
        
        public int? SecondWeight { get; set; }
        
        public string ErrorFromCallBack { get; set; }
        
        public bool ResponseSendToCallBackUrl { get; set; }

        public string SuccessMessageFromCallBack { get; set; }

    }
}