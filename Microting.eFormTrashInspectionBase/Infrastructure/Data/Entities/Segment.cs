using System;
using System.Linq;
using System.Threading.Tasks;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Segment : PnBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int SdkFolderId { get; set; }
    }
}