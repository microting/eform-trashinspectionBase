using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class InstallationVersion : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("Installation")]
        public int InstallationId { get; set; }
    }
}