using System.Collections.Generic;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Installation : PnBase
    {
        public string Name { get; set; }

        public virtual List<InstallationSite> InstallationSites { get; set; }
            = new List<InstallationSite>();
    }
}