using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class InstallationSiteVersion : BaseEntity
    {
        public int Version { get; set; }
     
        public int InstallationId { get; set; }

        public int SDKSiteId { get; set; }

        [ForeignKey("InstallationSite")]
        public int InstallationSiteId { get; set; }
    }
}