using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class FractionVersion : BaseEntity
    {
        [ForeignKey("Fraction")]
        public int FractionId { get; set; }
        
        public int Version { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int eFormId { get; set; }
        
        public string ItemNumber { get; set; }
        
        public string LocationCode { get; set; }
        
    }
}