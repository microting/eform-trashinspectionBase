using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;


namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class SegmentVersion : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public int SdkFolderId { get; set; }
        
        [ForeignKey("Segment")]
        public int SegmentId { get; set; }
        
    }
}