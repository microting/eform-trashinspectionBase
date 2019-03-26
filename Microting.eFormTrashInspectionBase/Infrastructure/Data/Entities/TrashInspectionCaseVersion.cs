using System.ComponentModel.DataAnnotations.Schema;

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
        
        public int Version { get; set; }  
        
        public int SegmentId { get; set; }
    }
}