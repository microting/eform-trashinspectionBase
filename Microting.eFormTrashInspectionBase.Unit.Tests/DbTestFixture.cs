using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microting.eFormTrashInspectionBase.Infrastructure.Data;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories;
using NUnit.Framework;

namespace Microting.eFormTrashInspectionBase.Unit.Tests
{
    using System.Runtime.InteropServices;

    [TestFixture]
    public abstract class DbTestFixture
    {
        protected TrashInspectionPnDbContext DbContext;
        private string _connectionString;
        private string _path;
        private const string NameDb = "trash-inspection-pn-tests";

        private void GetContext(string connectionStr)
        {
            var contextFactory = new TrashInspectionPnContextFactory();
            DbContext = contextFactory.CreateDbContext(new[] {connectionStr});

            DbContext.Database.Migrate();
            DbContext.Database.EnsureCreated();
        }

        [SetUp]
        public void Setup()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _connectionString = $@"data source=(LocalDb)\SharedInstance;Initial catalog={NameDb};Integrated Security=true";
            }
            else
            {
                _connectionString = $@"Server = localhost; port = 3306; Database = {NameDb}; user = root; password = secretpassword; Convert Zero Datetime = true;";
            }

            GetContext(_connectionString);


            DbContext.Database.SetCommandTimeout(300);

            try
            {
                ClearDb();
            }
            catch
            {
                DbContext.Database.Migrate();
            }
            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {
            ClearDb();

            ClearFile();

            DbContext.Dispose();
        }

        private void ClearDb()
        {
            var modelNames = new List<string>
            {
                "TrashInspectionVersions",
                "TrashInspections",
                "Installations",
                "InstallationVersions",
                "InstallationSites",
                "InstallationSiteVersions",
                "FractionVersions",
                "Fractions",
                "SegmentVersions",
                "Segments",
                "ProducerVersions",
                "Producers",
                "TransporterVersions",
                "Transporters",
                "PluginConfigurationValues",
                "PluginConfigurationValueVersions"
            };

            var firstRunNotDone = true;

            foreach (var modelName in modelNames)
            {
                try
                {
                    if (firstRunNotDone)
                    {
                        DbContext.Database.ExecuteSqlRaw(
                            $"SET FOREIGN_KEY_CHECKS = 0;TRUNCATE `{NameDb}`.`{modelName}`");
                    
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == $"Unknown database '{NameDb}'")
                    {
                        firstRunNotDone = false;
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void ClearFile()
        {
            _path = Assembly.GetExecutingAssembly().CodeBase;
            _path = Path.GetDirectoryName(_path)?.Replace(@"file:\", "");

            var picturePath = _path + @"\output\dataFolder\picture\Deleted";

            var diPic = new DirectoryInfo(picturePath);

            try
            {
                foreach (var file in diPic.GetFiles())
                {
                    file.Delete();
                }
            }
            catch
            {
                // ignored
            }
        }

        protected virtual void DoSetup() { }
    }
}