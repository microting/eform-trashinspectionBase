using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionCase : PnBase
    {
        public int Status { get; set; }

        [ForeignKey("TrashInspection")]
        public int TrashInspectionId { get; set; }

        public string SdkCaseId { get; set; }

        public int SdkSiteId { get; set; }

        [ForeignKey("Segment")]
        public int SegmentId { get; set; }
    }
}