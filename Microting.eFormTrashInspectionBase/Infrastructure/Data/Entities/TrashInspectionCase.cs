namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionCase :  PnBase
    {                
        public int Status { get; set; }

        public int TrashInspectionId { get; set; }

        public virtual TrashInspection TrashInspection { get; set; }

        public string SdkCaseId { get; set; }
        
        public int SdkSiteId { get; set; }

        public int SegmentId { get; set; }

        public virtual Segment Segment { get; set; }
    }
}