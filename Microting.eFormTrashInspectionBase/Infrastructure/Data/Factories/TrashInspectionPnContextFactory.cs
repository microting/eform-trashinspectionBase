using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories
{
    public class TrashInspectionPnContextFactory : IDesignTimeDbContextFactory<TrashInspectionPnDbContext>
    {
        public TrashInspectionPnDbContext CreateDbContext(string[] args)
        {
            var defaultCs = "Server = localhost; port = 3306; Database = trashinspection-pn; user = root; Convert Zero Datetime = true;";
            var optionsBuilder = new DbContextOptionsBuilder<TrashInspectionPnDbContext>();
            optionsBuilder.UseMySql(args.Any() ? args[0]: defaultCs);
            optionsBuilder.UseLazyLoadingProxies(true);
        
            return new TrashInspectionPnDbContext(optionsBuilder.Options);
            // dotnet ef migrations add InitialCreate --project Microting.eFormTrashInspectionBase --startup-project DBMigrator
        }
    }
}