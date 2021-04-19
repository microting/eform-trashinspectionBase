using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class InstallationSite : PnBase
    {
        public int InstallationId { get; set; }

        public virtual Installation Installation { get; set; }

        public int SDKSiteId { get; set; }
    }
}