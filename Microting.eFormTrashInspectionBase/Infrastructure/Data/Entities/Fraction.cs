using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Fraction : BaseEntity
    {        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public int eFormId { get; set; }
        
        public string ItemNumber { get; set; }
        
        public string LocationCode { get; set; }
        
    }
}