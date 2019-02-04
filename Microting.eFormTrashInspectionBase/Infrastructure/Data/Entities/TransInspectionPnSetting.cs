using System.ComponentModel.DataAnnotations;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionPnSetting: BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public string value { get; set; }
    }
}