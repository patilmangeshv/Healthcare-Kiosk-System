﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server_api.Data;

namespace server_api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210518163717_Add_up_GetBoxServiceIPTV")]
    partial class Add_up_GetBoxServiceIPTV
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("server_api.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserLevel")
                        .HasMaxLength(1)
                        .HasColumnType("char(1)")
                        .HasComment("Super Admin:S, Admin: A, Desk User: U, Doctor User: D, Light Users: L");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("server_api.Entities.Box", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BoxId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoxName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BoxNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblBox");
                });

            modelBuilder.Entity("server_api.Entities.BoxService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BoxServiceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoxId")
                        .HasColumnType("int");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("SubServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.HasIndex("DeskId");

                    b.HasIndex("ServiceId");

                    b.ToTable("tblBoxService");
                });

            modelBuilder.Entity("server_api.Entities.BoxServiceIPTV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BoxServiceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoxId")
                        .HasColumnType("int");

                    b.Property<string>("BoxNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeskCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BoxServicesIPTV");
                });

            modelBuilder.Entity("server_api.Entities.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CouponId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoxId")
                        .HasColumnType("int");

                    b.Property<int?>("BoxUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CallingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CompletionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CouponGenerationDate")
                        .HasColumnType("datetime2")
                        .HasComment("Only stores DD/MM/YYYY. Used for generation CouponNo on daily basis.");

                    b.Property<DateTime>("CouponGenerationDateTime")
                        .HasColumnType("datetime2")
                        .HasComment("Stores complete coupon generation datetime.");

                    b.Property<int>("CouponNo")
                        .HasColumnType("int");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAbsent")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsInProgress")
                        .HasColumnType("bit");

                    b.Property<int>("KioskId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("SubServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblCoupon");
                });

            modelBuilder.Entity("server_api.Entities.Desk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeskId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeskCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("DeskName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblDesk");
                });

            modelBuilder.Entity("server_api.Entities.DeskService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeskServiceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeskId");

                    b.HasIndex("ServiceId");

                    b.ToTable("tblDeskService");
                });

            modelBuilder.Entity("server_api.Entities.GeneratedCouponDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CouponId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CouponGenerationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CouponNo")
                        .HasColumnType("int");

                    b.Property<string>("DeskCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubServiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneratedCouponDetails");
                });

            modelBuilder.Entity("server_api.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GroupId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GroupNameArabic")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GroupNameFrench")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblGroup");
                });

            modelBuilder.Entity("server_api.Entities.IPTVMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IPTVId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IPTVName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IPTVNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MacAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeskId");

                    b.HasIndex(new[] { "MacAddress" }, "UK_tblIPTV_MacAddress")
                        .IsUnique()
                        .HasFilter("[MacAddress] IS NOT NULL");

                    b.ToTable("tblIPTV");
                });

            modelBuilder.Entity("server_api.Entities.KioskMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KioskId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("KioskName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KioskNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MacAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MacAddress" }, "UK_tblKiosk_MacAddress")
                        .IsUnique();

                    b.ToTable("tblKiosk");
                });

            modelBuilder.Entity("server_api.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LocationId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("tblLocation");
                });

            modelBuilder.Entity("server_api.Entities.NextPendingCoupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CouponId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CouponNo")
                        .HasColumnType("int");

                    b.Property<string>("ServiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubServiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubServiceId")
                        .HasColumnType("int");

                    b.Property<string>("SubServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalCoupons")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NextPendingCoupons");
                });

            modelBuilder.Entity("server_api.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ServiceName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ServiceNameArabic")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ServiceNameFrench")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("LocationId");

                    b.HasIndex(new[] { "ServiceCode" }, "UK_tblService_ServiceCode")
                        .IsUnique()
                        .HasFilter("[ServiceCode] IS NOT NULL");

                    b.ToTable("tblService");
                });

            modelBuilder.Entity("server_api.Entities.SubService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SubServiceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("SubServiceCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SubServiceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubServiceNameArabic")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SubServiceNameFrench")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("tblSubService");
                });

            modelBuilder.Entity("server_api.Entities.ValidateDeskBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BoxServiceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoxId")
                        .HasColumnType("int");

                    b.Property<string>("BoxNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeskCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("SubServiceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ValidateDeskBoxes");
                });

            modelBuilder.Entity("server_api.Entities.BoxService", b =>
                {
                    b.HasOne("server_api.Entities.Box", "Box")
                        .WithMany()
                        .HasForeignKey("BoxId");

                    b.HasOne("server_api.Entities.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server_api.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Box");

                    b.Navigation("Desk");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("server_api.Entities.DeskService", b =>
                {
                    b.HasOne("server_api.Entities.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server_api.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desk");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("server_api.Entities.IPTVMachine", b =>
                {
                    b.HasOne("server_api.Entities.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desk");
                });

            modelBuilder.Entity("server_api.Entities.Service", b =>
                {
                    b.HasOne("server_api.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server_api.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("server_api.Entities.SubService", b =>
                {
                    b.HasOne("server_api.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });
#pragma warning restore 612, 618
        }
    }
}
