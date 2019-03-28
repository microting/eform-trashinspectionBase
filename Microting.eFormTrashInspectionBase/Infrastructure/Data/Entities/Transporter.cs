namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Transporter : BaseEntity
    {        
        public int Version { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ForeignId { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string ZipCode { get; set; }
        
        public string Phone { get; set; }
        
        public string ContactPerson { get; set; }
    }
}