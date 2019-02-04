using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Factories;

namespace Microting.eFormTrashInspectionBase.Infrastructure
{
    public class SqlController
    {
        
        eFormShared.Tools t = new eFormShared.Tools();

        object _writeLock = new object();

        string connectionStr;

        
        #region con
        public SqlController(string connectionString)
        {
            connectionStr = connectionString;          

            #region migrate if needed
            try
            {
                using (var db = GetContext())
                {
                    //TODO! THIS part need to be redone in some form in EF Core!
                   
                    db.Database.Migrate();
                    db.Database.EnsureCreated();

                    var match = db.TrashInspectionPnSettings.Count();
                }
            }
            catch
            {
                //TODO! THIS part need to be redone in some form in EF Core!
            }
            #endregion

            if (SettingCheckAll().Count > 0)
                SettingCreateDefaults();
        }

        private TrashInspectionPnDbContext GetContext()
        {

            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();

            if (connectionStr.ToLower().Contains("convert zero datetime"))
            {
                dbContextOptionsBuilder.UseMySql(connectionStr);
            }
            else
            {
                dbContextOptionsBuilder.UseSqlServer(connectionStr);
            }
            dbContextOptionsBuilder.UseLazyLoadingProxies(true);
            return new TrashInspectionPnDbContext(dbContextOptionsBuilder.Options);

        }
        #endregion
        
        
        #region public setting
        public bool SettingCreateDefaults()
        {
            SettingCreate(Settings.SdkConnectionString);
            SettingCreate(Settings.LogLevel);
            SettingCreate(Settings.LogLimit);
            SettingCreate(Settings.MaxParallelism);
            SettingCreate(Settings.NumberOfWorkers);

            return true;
        }

        public bool SettingCreate(Settings name)
        {
            using (var db = GetContext())
            {
                #region id = settings.name
                int id = -1;
                string defaultValue = "default";
                switch (name)
                {
                    case Settings.SdkConnectionString: defaultValue = "..."; break;
                    case Settings.LogLevel: defaultValue = "4"; break;
                    case Settings.LogLimit: defaultValue = "25000"; break;
                    case Settings.MaxParallelism: defaultValue = "1"; break;
                    case Settings.NumberOfWorkers: defaultValue = "1"; break;
                    
                    default:
                        throw new IndexOutOfRangeException(name.ToString() + " is not a known/mapped Settings type");
                }
                #endregion

                TrashInspectionPnSetting matchId = db.TrashInspectionPnSettings.SingleOrDefault(x => x.Id == id);
                TrashInspectionPnSetting matchName = db.TrashInspectionPnSettings.SingleOrDefault(x => x.name == name.ToString());

                if (matchName == null)
                {
                    if (matchId != null)
                    {
                        #region there is already a setting with that id but different name
                        //the old setting data is copied, and new is added
                        TrashInspectionPnSetting newSettingBasedOnOld = new TrashInspectionPnSetting();
                        newSettingBasedOnOld.Id = (db.TrashInspectionPnSettings.Select(x => (int?)x.Id).Max() ?? 0) + 1;
                        newSettingBasedOnOld.name = matchId.name.ToString();
                        newSettingBasedOnOld.value = matchId.value;

                        db.TrashInspectionPnSettings.Add(newSettingBasedOnOld);

                        matchId.name = name.ToString();
                        matchId.value = defaultValue;

                        db.SaveChanges();
                        #endregion
                    }
                    else
                    {
                        //its a new setting
                        TrashInspectionPnSetting newSetting = new TrashInspectionPnSetting();
                        newSetting.Id = id;
                        newSetting.name = name.ToString();
                        newSetting.value = defaultValue;

                        db.TrashInspectionPnSettings.Add(newSetting);
                    }
                    db.SaveChanges();
                }
                else
                    if (string.IsNullOrEmpty(matchName.value))
                    matchName.value = defaultValue;
            }

            return true;
        }

        public string SettingRead(Settings name)
        {
            try
            {
                using (var db = GetContext())
                {
                    TrashInspectionPnSetting match = db.TrashInspectionPnSettings.Single(x => x.name == name.ToString());

                    if (match.value == null)
                        return "";

                    return match.value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(t.GetMethodName("SQLController") + " failed", ex);
            }
        }

        public void SettingUpdate(Settings name, string newValue)
        {
            try
            {
                using (var db = GetContext())
                {
                    TrashInspectionPnSetting match = db.TrashInspectionPnSettings.SingleOrDefault(x => x.name == name.ToString());

                    if (match == null)
                    {
                        SettingCreate(name);
                        match = db.TrashInspectionPnSettings.Single(x => x.name == name.ToString());
                    }

                    match.value = newValue;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(t.GetMethodName("SQLController") + " failed", ex);
            }
        }

        public List<string> SettingCheckAll()
        {
            List<string> result = new List<string>();
            try
            {
                using (var db = GetContext())
                {
                    

                    int countVal = db.TrashInspectionPnSettings.Count(x => x.value == "");
                    int countSet = db.TrashInspectionPnSettings.Count();

                    if (countSet == 0)
                    {
                        result.Add("NO SETTINGS PRESENT, NEEDS PRIMING!");
                        return result;
                    }

                    foreach (var setting in Enum.GetValues(typeof(Settings)))
                    {
                        try
                        {
                            string readSetting = SettingRead((Settings)setting);
                            if (string.IsNullOrEmpty(readSetting))
                                result.Add(setting.ToString() + " has an empty value!");
                        }
                        catch
                        {
                            result.Add("There is no setting for " + setting + "! You need to add one");
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(t.GetMethodName("SQLController") + " failed", ex);
            }
        }
        #endregion
        
        public enum Settings
        {
            LogLevel,
            LogLimit,
            SdkConnectionString,
            MaxParallelism,
            NumberOfWorkers
        }
    }
}