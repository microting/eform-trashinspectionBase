using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionPnSettingVersion : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public string value { get; set; }

        [ForeignKey("TrashInspectionPnSetting")]
        public int TrashInspectionPnSettingId { get; set; }
    }
}