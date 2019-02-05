using System.ComponentModel.DataAnnotations.Schema;


namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class SegmentVersion : BaseEntity
    {        
        public int Version { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int SdkFolderId { get; set; }
        
        [ForeignKey("Segment")]
        public int SegmentId { get; set; }
        
    }
}