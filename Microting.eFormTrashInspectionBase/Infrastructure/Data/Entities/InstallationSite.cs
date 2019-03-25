using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class InstallationSite : BaseEntity
    {
        [ForeignKey("Installation")]
        public int InstallationId { get; set; }

        public int SDKSiteId { get; set; }
    }
}