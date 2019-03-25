using System.ComponentModel.DataAnnotations;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionPnSetting : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}