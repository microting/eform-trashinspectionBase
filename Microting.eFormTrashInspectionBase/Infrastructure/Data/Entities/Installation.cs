using System.Collections.Generic;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Installation : BaseEntity
    {
        public Installation()
        {
            this.InstallationSites = new HashSet<InstallationSite>();
        }

        public string Name { get; set; }
        
        public virtual ICollection<InstallationSite> InstallationSites { get; set; }
    }
}