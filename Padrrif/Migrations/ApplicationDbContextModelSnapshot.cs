﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Padrrif;

#nullable disable

namespace Padrrif.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Padrrif.AnimalDamage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AffectedNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("DamageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DamageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("PriceBeforeDamage")
                        .HasColumnType("float");

                    b.Property<double?>("ProductionRate")
                        .HasColumnType("float");

                    b.Property<int?>("TotalNumber")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DamageId");

                    b.ToTable("AnimalDamage");
                });

            modelBuilder.Entity("Padrrif.Comitee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Comitee");
                });

            modelBuilder.Entity("Padrrif.Damage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BasinNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChildrenUnderEighteen")
                        .HasColumnType("int");

                    b.Property<string>("CompanyOrFactoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContractorId")
                        .HasColumnType("int");

                    b.Property<string>("ContractorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<double?>("DamageRateLastFiveYears")
                        .HasColumnType("float");

                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentsPaths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EducationLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamilyMembers")
                        .HasColumnType("int");

                    b.Property<Guid>("FarmerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAnimalTremblingChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBirdFluChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDroughtChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExtremeTemperatureDropChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExtremeTemperatureRiseChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFloodChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFrostChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHailChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHarmfulWeedsChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsIsraeliArmyChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLocustChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMarketClosedChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMilitaryZoneChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOtherProfession")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSeparationWallChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSnowChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStrongWindChecked")
                        .HasColumnType("bit");

                    b.Property<string>("LandNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("LocationPaths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<double>("MonthlyIncomeFromAgriculture")
                        .HasColumnType("float");

                    b.Property<string>("OtherTabTwoText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnershipTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RegionType")
                        .HasColumnType("int");

                    b.Property<double>("ReliancePercentage")
                        .HasColumnType("float");

                    b.Property<string>("SettlementName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TotalArea")
                        .HasColumnType("float");

                    b.Property<Guid>("VillageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("otherTabThreeText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId")
                        .IsUnique();

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OwnershipTypeId");

                    b.HasIndex("VillageId");

                    b.ToTable("Damage");
                });

            modelBuilder.Entity("Padrrif.EducationLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EducationLevel");
                });

            modelBuilder.Entity("Padrrif.EmployeePrivilieges", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrivliegeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeId", "PrivliegeId");

                    b.HasIndex("PrivliegeId");

                    b.ToTable("EmployeePrivilieges");
                });

            modelBuilder.Entity("Padrrif.Entities.Priviliege", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Priviliege");
                });

            modelBuilder.Entity("Padrrif.FarmFacilities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("ActualDamageArea")
                        .HasColumnType("float");

                    b.Property<string>("CategoryFacilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DamageFacilitiesType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DamageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FacilitiesType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceFacilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LicenseFacilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TotalAffectedArea")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DamageId");

                    b.ToTable("FarmFacilities");
                });

            modelBuilder.Entity("Padrrif.FisheryDamage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AffectedNumber")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DamageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FishDamageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double?>("PriceBeforeDamage")
                        .HasColumnType("float");

                    b.Property<double?>("ProductionRate")
                        .HasColumnType("float");

                    b.Property<int?>("TotalNumber")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DamageId");

                    b.ToTable("FisheryDamage");
                });

            modelBuilder.Entity("Padrrif.Governorate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Governorate");
                });

            modelBuilder.Entity("Padrrif.Notifaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("SeenAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifaction");
                });

            modelBuilder.Entity("Padrrif.OwnerShipType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("OwnerShipType");
                });

            modelBuilder.Entity("Padrrif.PlantDamage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("ActualDamageArea")
                        .HasColumnType("float");

                    b.Property<string>("CropAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CropDamage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CropType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CropTypeMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CropTypeOption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DamageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("EstimatedPrice")
                        .HasColumnType("float");

                    b.Property<double?>("EstimatedProductionRate")
                        .HasColumnType("float");

                    b.Property<string>("FruitingStage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insurance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IrrigationMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IrrigationOption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OtherCropTextFieldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherTextFieldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PercentageDamage")
                        .HasColumnType("float");

                    b.Property<double?>("TotalAffectedArea")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DamageId");

                    b.ToTable("PlantDamage");
                });

            modelBuilder.Entity("Padrrif.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ComiteeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentsPaths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("GovernorateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdentityNumber")
                        .HasMaxLength(9)
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MobilePhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComiteeId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GovernorateId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Padrrif.Village", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Village");
                });

            modelBuilder.Entity("Padrrif.WorkHours", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("DailyWorkHours")
                        .HasColumnType("float");

                    b.Property<Guid>("DamageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("WeeklyWorkHours")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DamageId");

                    b.ToTable("WorkHours");
                });

            modelBuilder.Entity("Padrrif.AnimalDamage", b =>
                {
                    b.HasOne("Padrrif.Damage", "Damage")
                        .WithMany("AnimalDamages")
                        .HasForeignKey("DamageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Damage");
                });

            modelBuilder.Entity("Padrrif.Damage", b =>
                {
                    b.HasOne("Padrrif.EducationLevel", "EducationLevel")
                        .WithMany("Damages")
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Padrrif.User", "Employee")
                        .WithMany("Damages")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Padrrif.OwnerShipType", "OwnerShipType")
                        .WithMany("Damages")
                        .HasForeignKey("OwnershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Padrrif.Village", "Village")
                        .WithMany("Damages")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationLevel");

                    b.Navigation("Employee");

                    b.Navigation("OwnerShipType");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Padrrif.EmployeePrivilieges", b =>
                {
                    b.HasOne("Padrrif.User", "User")
                        .WithMany("EmployeePrivilieges")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Padrrif.Entities.Priviliege", "Priviliege")
                        .WithMany("EmployeePrivilieges")
                        .HasForeignKey("PrivliegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Priviliege");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Padrrif.FarmFacilities", b =>
                {
                    b.HasOne("Padrrif.Damage", "Damage")
                        .WithMany("FarmFacilities")
                        .HasForeignKey("DamageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Damage");
                });

            modelBuilder.Entity("Padrrif.FisheryDamage", b =>
                {
                    b.HasOne("Padrrif.Damage", "Damage")
                        .WithMany("FisheryDamages")
                        .HasForeignKey("DamageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Damage");
                });

            modelBuilder.Entity("Padrrif.Notifaction", b =>
                {
                    b.HasOne("Padrrif.User", "User")
                        .WithMany("Notifactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Padrrif.PlantDamage", b =>
                {
                    b.HasOne("Padrrif.Damage", "Damage")
                        .WithMany("PlantDamages")
                        .HasForeignKey("DamageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Damage");
                });

            modelBuilder.Entity("Padrrif.User", b =>
                {
                    b.HasOne("Padrrif.Comitee", "Comittee")
                        .WithMany("Employees")
                        .HasForeignKey("ComiteeId");

                    b.HasOne("Padrrif.Governorate", "Governorate")
                        .WithMany("Users")
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comittee");

                    b.Navigation("Governorate");
                });

            modelBuilder.Entity("Padrrif.WorkHours", b =>
                {
                    b.HasOne("Padrrif.Damage", "Damage")
                        .WithMany("WorkHours")
                        .HasForeignKey("DamageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Damage");
                });

            modelBuilder.Entity("Padrrif.Comitee", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Padrrif.Damage", b =>
                {
                    b.Navigation("AnimalDamages");

                    b.Navigation("FarmFacilities");

                    b.Navigation("FisheryDamages");

                    b.Navigation("PlantDamages");

                    b.Navigation("WorkHours");
                });

            modelBuilder.Entity("Padrrif.EducationLevel", b =>
                {
                    b.Navigation("Damages");
                });

            modelBuilder.Entity("Padrrif.Entities.Priviliege", b =>
                {
                    b.Navigation("EmployeePrivilieges");
                });

            modelBuilder.Entity("Padrrif.Governorate", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Padrrif.OwnerShipType", b =>
                {
                    b.Navigation("Damages");
                });

            modelBuilder.Entity("Padrrif.User", b =>
                {
                    b.Navigation("Damages");

                    b.Navigation("EmployeePrivilieges");

                    b.Navigation("Notifactions");
                });

            modelBuilder.Entity("Padrrif.Village", b =>
                {
                    b.Navigation("Damages");
                });
#pragma warning restore 612, 618
        }
    }
}
