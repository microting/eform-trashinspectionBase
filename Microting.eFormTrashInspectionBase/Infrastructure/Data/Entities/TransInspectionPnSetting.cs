using System.ComponentModel.DataAnnotations;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionPnSetting : BaseTrashInspectionEntity
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }
        
        public int Version { get; set; }
    }
}