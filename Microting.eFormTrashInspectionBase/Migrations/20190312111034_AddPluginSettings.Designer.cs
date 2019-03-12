﻿/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 microting

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microting.eFormTrashInspectionBase.Infrastructure.Data;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    [DbContext(typeof(TrashInspectionPnDbContext))]
    [Migration("20190312111034_AddPluginSettings")]
    partial class AddPluginSettings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            string autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;
            if (DbConfig.IsMySQL)
            {
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValue", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("PluginConfigurationValues");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationVersion", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Id", "Version")
                        .IsUnique();

                    b.ToTable("PluginConfigurationVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Fraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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

                    b.HasKey("Id");

                    b.ToTable("Fractions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.FractionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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

                    b.HasKey("Id");

                    b.ToTable("FractionVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Installation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.Segment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Eak_Code");

                    b.Property<bool>("ExtendedInspection");

                    b.Property<int?>("FractionId");

                    b.Property<bool>("InspectionDone");

                    b.Property<int?>("InstallationId");

                    b.Property<bool>("MustBeInspected");

                    b.Property<string>("Producer");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int?>("SegmentId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Transporter");

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
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

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

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspectionPnSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("TrashInspectionPnSettings");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspectionPnSettingVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TrashInspectionPnSettingId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("TrashInspectionPnSettingVersions");
                });

            modelBuilder.Entity("Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspectionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("EakCode");

                    b.Property<bool>("ExtendedInspection");

                    b.Property<int?>("FractionId");

                    b.Property<bool>("InspectionDone");

                    b.Property<int?>("InstallationId");

                    b.Property<bool>("MustBeInspected");

                    b.Property<string>("Producer");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int?>("SegmentId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Transporter");

                    b.Property<string>("TrashFraction");

                    b.Property<int>("TrashInspctionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WeighingNumber");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("TrashInspectionVersions");
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
