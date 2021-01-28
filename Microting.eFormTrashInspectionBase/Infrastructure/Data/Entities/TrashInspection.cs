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

    public class TrashInspection : PnBase
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

        public string EakCode { get; set; }

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

        public bool ResponseSendToCallBackUrl { get; set; }

        public string SuccessMessageFromCallBack { get; set; }
    }
}