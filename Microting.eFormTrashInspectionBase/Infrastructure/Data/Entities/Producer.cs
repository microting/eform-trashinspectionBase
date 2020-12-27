using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Producer : PnBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ForeignId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

        public string ContactPerson { get; set; }
    }
}