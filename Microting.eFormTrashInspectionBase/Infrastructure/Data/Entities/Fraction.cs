namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Fraction : BaseEntity
    {        
        public int Version { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public int eFormId { get; set; }
        
    }
}