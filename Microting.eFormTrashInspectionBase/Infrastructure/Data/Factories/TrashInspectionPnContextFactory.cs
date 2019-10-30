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
            //args = new[]
            //    {"host=localhost;Database=trash-pl;Uid=root;Pwd=111111;port=3306;Convert Zero Datetime = true;SslMode=none;PersistSecurityInfo=true;"};
            //args = new[]
            //    {"Data Source=.\\SQLEXPRESS;Database=trash-pl;Integrated Security=True"};
            var optionsBuilder = new DbContextOptionsBuilder<TrashInspectionPnDbContext>();
            if (args.Any())
            {
                if (args.FirstOrDefault().ToLower().Contains("convert zero datetime"))
                {
                    optionsBuilder.UseMySql(args.FirstOrDefault());
                }
                else
                {
                    optionsBuilder.UseSqlServer(args.FirstOrDefault());
                }
            }
            else
            {
                throw new ArgumentNullException("Connection string not present");
            }
//            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\SharedInstance;Initial catalog=trash-inspection-pn-tests;Integrated Security=True");
//            dotnet ef migrations add InitialCreate --project Microting.eFormTrashInspectionBase --startup-project DBMigrator
            optionsBuilder.UseLazyLoadingProxies(true);
            return new TrashInspectionPnDbContext(optionsBuilder.Options);
        }
    }
}