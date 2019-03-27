using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Installation : BaseTrashInspectionEntity
    {
        public Installation()
        {
            this.InstallationSites = new HashSet<InstallationSite>();
        }
        
        public int Version { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<InstallationSite> InstallationSites { get; set; }
    }
}