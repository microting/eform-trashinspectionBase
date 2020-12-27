using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Installation : PnBase
    {
        public Installation()
        {
            this.InstallationSites = new HashSet<InstallationSite>();
        }

        public string Name { get; set; }

        public virtual ICollection<InstallationSite> InstallationSites { get; set; }
    }
}