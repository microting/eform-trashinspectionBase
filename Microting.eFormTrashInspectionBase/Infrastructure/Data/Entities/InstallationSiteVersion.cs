using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class InstallationSiteVersion : BaseEntity
    {
        public int InstallationId { get; set; }

        public int SDKSiteId { get; set; }

        [ForeignKey("InstallationSite")]
        public int InstallationSiteId { get; set; }
    }
}