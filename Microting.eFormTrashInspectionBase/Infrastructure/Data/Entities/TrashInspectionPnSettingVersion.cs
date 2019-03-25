using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionPnSettingVersion : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }

        [ForeignKey("TrashInspectionPnSetting")]
        public int TrashInspectionPnSettingId { get; set; }
    }
}