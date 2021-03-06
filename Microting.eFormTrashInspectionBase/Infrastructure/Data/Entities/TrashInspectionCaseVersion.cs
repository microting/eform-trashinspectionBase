using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionCaseVersion : BaseEntity
    {                
        public int Status { get; set; }
               
        public int TrashInspectionId { get; set; }
        
        public string SdkCaseId { get; set; }
        
        public int SdkSiteId { get; set; }
        
        [ForeignKey("TrashInspectionCase")]
        public int TrashInspectionCaseId { get; set; }
        
        public int SegmentId { get; set; }
    }
}