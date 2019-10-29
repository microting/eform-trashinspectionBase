﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microting.eFormTrashInspectionBase.Infrastructure.Data;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    [DbContext(typeof(TrashInspectionPnDbContext))]
    partial class TrashInspectionPnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            string autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;
            if (DbConfig.IsMySQL)
            {
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }

            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValues");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValueVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValueVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<int>("PluginGroupPermissionId");

                    b.Property<int?>("PluginGroupPermissionId1");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("PluginGroupPermissionId");

                    b.HasIndex("PluginGroupPermissionId1");

                    b.ToTable("PluginGroupPermissionVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("ClaimName");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("PermissionName");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginPermissions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Fraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("LocationCode");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<int>("eFormId");

                    b.Property<int>("eFormIdExtendedInspection");

                    b.HasKey("Id");

                    b.ToTable("Fractions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.FractionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<int>("FractionId");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("LocationCode");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<int>("eFormId");

                    b.Property<int>("eFormIdExtendedInspection");

                    b.HasKey("Id");

                    b.ToTable("FractionVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Installation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Installations");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.InstallationSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("InstallationId");

                    b.Property<int>("SDKSiteId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("InstallationId");

                    b.ToTable("InstallationSites");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.InstallationSiteVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("InstallationId");

                    b.Property<int>("InstallationSiteId");

                    b.Property<int>("SDKSiteId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("InstallationSiteVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.InstallationVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("InstallationId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("InstallationVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("ForeignId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.ProducerVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("ForeignId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("ProducerId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("ProducerVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Segment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("SdkFolderId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.SegmentVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("SdkFolderId");

                    b.Property<int>("SegmentId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SegmentVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Transporter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("ForeignId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Transporters");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TransporterVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<string>("ForeignId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("TransporterId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("TransporterVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("ApprovedValue");

                    b.Property<string>("Comment");

                    b.Property<bool>("ConditionalApproved");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Eak_Code");

                    b.Property<bool>("ExtendedInspection");

                    b.Property<int?>("FirstWeight");

                    b.Property<int?>("FractionId");

                    b.Property<bool>("InspectionDone");

                    b.Property<int?>("InstallationId");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("MustBeInspected");

                    b.Property<string>("Producer");

                    b.Property<int?>("ProducerId");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int?>("SecondWeight");

                    b.Property<int?>("SegmentId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Transporter");

                    b.Property<int?>("TransporterId");

                    b.Property<string>("TrashFraction");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WeighingNumber");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("TrashInspections");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspectionCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("SdkCaseId");

                    b.Property<int>("SdkSiteId");

                    b.Property<int>("SegmentId");

                    b.Property<int>("Status");

                    b.Property<int>("TrashInspectionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("TrashInspectionId");

                    b.ToTable("TrashInspectionCases");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspectionCaseVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("SdkCaseId");

                    b.Property<int>("SdkSiteId");

                    b.Property<int>("SegmentId");

                    b.Property<int>("Status");

                    b.Property<int>("TrashInspectionCaseId");

                    b.Property<int>("TrashInspectionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("TrashInspectionCaseVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspectionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("ApprovedValue");

                    b.Property<string>("Comment");

                    b.Property<bool>("ConditionalApproved");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("EakCode");

                    b.Property<bool>("ExtendedInspection");

                    b.Property<int?>("FirstWeight");

                    b.Property<int?>("FractionId");

                    b.Property<bool>("InspectionDone");

                    b.Property<int?>("InstallationId");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("MustBeInspected");

                    b.Property<string>("Producer");

                    b.Property<int?>("ProducerId");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int?>("SecondWeight");

                    b.Property<int?>("SegmentId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Transporter");

                    b.Property<int?>("TransporterId");

                    b.Property<string>("TrashFraction");

                    b.Property<int>("TrashInspectionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WeighingNumber");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("TrashInspectionVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission")
                        .WithMany()
                        .HasForeignKey("PluginGroupPermissionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", "PluginGroupPermission")
                        .WithMany()
                        .HasForeignKey("PluginGroupPermissionId1");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.InstallationSite", b =>
                {
                    b.HasOne("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Installation")
                        .WithMany("InstallationSites")
                        .HasForeignKey("InstallationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspectionCase", b =>
                {
                    b.HasOne("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection")
                        .WithMany("TrashInspectionCases")
                        .HasForeignKey("TrashInspectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
