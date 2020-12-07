﻿// <auto-generated />
using System;
using InmobiliariaDashboard.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InmobiliariaDashboard.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CardNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CostId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GainId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LossId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CostId");

                    b.HasIndex("GainId");

                    b.HasIndex("LossId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressExt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cellphone")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Zip")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressExt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cellphone")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("SuffixName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Zip")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Commission")
                        .HasColumnType("REAL");

                    b.Property<string>("CommissionType")
                        .HasColumnType("TEXT");

                    b.Property<int>("CostTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CostTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.CostType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CostTypes");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Gain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("GainTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("GainTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Gains");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.GainType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GainTypes");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Loss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Commission")
                        .HasColumnType("REAL");

                    b.Property<string>("CommissionType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("LossTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("LossTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Losses");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.LossType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LossTypes");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Account", b =>
                {
                    b.HasOne("InmobiliariaDashboard.Server.Models.Client", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Attachment", b =>
                {
                    b.HasOne("InmobiliariaDashboard.Server.Models.Cost", "Cost")
                        .WithMany("Attachments")
                        .HasForeignKey("CostId");

                    b.HasOne("InmobiliariaDashboard.Server.Models.Gain", "Gain")
                        .WithMany("Attachments")
                        .HasForeignKey("GainId");

                    b.HasOne("InmobiliariaDashboard.Server.Models.Loss", "Loss")
                        .WithMany("Attachments")
                        .HasForeignKey("LossId");

                    b.Navigation("Cost");

                    b.Navigation("Gain");

                    b.Navigation("Loss");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Contact", b =>
                {
                    b.HasOne("InmobiliariaDashboard.Server.Models.Client", "Client")
                        .WithMany("Contacts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Cost", b =>
                {
                    b.HasOne("InmobiliariaDashboard.Server.Models.Account", "Account")
                        .WithMany("Costs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InmobiliariaDashboard.Server.Models.CostType", "CostType")
                        .WithMany("Costs")
                        .HasForeignKey("CostTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InmobiliariaDashboard.Server.Models.Project", "Project")
                        .WithMany("Costs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("CostType");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Gain", b =>
                {
                    b.HasOne("InmobiliariaDashboard.Server.Models.Account", "Account")
                        .WithMany("Gains")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InmobiliariaDashboard.Server.Models.GainType", "GainType")
                        .WithMany("Gains")
                        .HasForeignKey("GainTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InmobiliariaDashboard.Server.Models.Project", "Project")
                        .WithMany("Gains")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("GainType");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Loss", b =>
                {
                    b.HasOne("InmobiliariaDashboard.Server.Models.Account", "Account")
                        .WithMany("Losses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InmobiliariaDashboard.Server.Models.LossType", "LossType")
                        .WithMany("Losses")
                        .HasForeignKey("LossTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InmobiliariaDashboard.Server.Models.Project", "Project")
                        .WithMany("Losses")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("LossType");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Project", b =>
                {
                    b.HasOne("InmobiliariaDashboard.Server.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Account", b =>
                {
                    b.Navigation("Costs");

                    b.Navigation("Gains");

                    b.Navigation("Losses");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Client", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Contacts");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Cost", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.CostType", b =>
                {
                    b.Navigation("Costs");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Gain", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.GainType", b =>
                {
                    b.Navigation("Gains");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Loss", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.LossType", b =>
                {
                    b.Navigation("Losses");
                });

            modelBuilder.Entity("InmobiliariaDashboard.Server.Models.Project", b =>
                {
                    b.Navigation("Costs");

                    b.Navigation("Gains");

                    b.Navigation("Losses");
                });
#pragma warning restore 612, 618
        }
    }
}
