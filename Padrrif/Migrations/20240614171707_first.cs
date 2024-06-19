using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Padrrif.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comitee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comitee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnerShipType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerShipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priviliege",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priviliege", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdentityNumber = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentsPaths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ComiteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Comitee_ComiteeId",
                        column: x => x.ComiteeId,
                        principalTable: "Comitee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Damage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VillageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnershipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FamilyMembers = table.Column<int>(type: "int", nullable: false),
                    ChildrenUnderEighteen = table.Column<int>(type: "int", nullable: false),
                    IsOtherProfession = table.Column<bool>(type: "bit", nullable: false),
                    MonthlyIncomeFromAgriculture = table.Column<double>(type: "float", nullable: false),
                    ReliancePercentage = table.Column<double>(type: "float", nullable: false),
                    LandNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionType = table.Column<int>(type: "int", nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractorId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalArea = table.Column<double>(type: "float", nullable: true),
                    DamageRateLastFiveYears = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    IsIsraeliArmyChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsSeparationWallChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsMilitaryZoneChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsMarketClosedChecked = table.Column<bool>(type: "bit", nullable: false),
                    SettlementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyOrFactoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSnowChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsStrongWindChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsHailChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsFloodChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsDroughtChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsFrostChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsExtremeTemperatureDropChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsExtremeTemperatureRiseChecked = table.Column<bool>(type: "bit", nullable: false),
                    OtherTabTwoText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnimalTremblingChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsBirdFluChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsLocustChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsHarmfulWeedsChecked = table.Column<bool>(type: "bit", nullable: false),
                    otherTabThreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationPaths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentsPaths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Damage_EducationLevel_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_OwnerShipType_OwnershipTypeId",
                        column: x => x.OwnershipTypeId,
                        principalTable: "OwnerShipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Damage_Village_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Village",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePrivilieges",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivliegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePrivilieges", x => new { x.EmployeeId, x.PrivliegeId });
                    table.ForeignKey(
                        name: "FK_EmployeePrivilieges_Priviliege_PrivliegeId",
                        column: x => x.PrivliegeId,
                        principalTable: "Priviliege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePrivilieges_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeenAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalDamage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNumber = table.Column<int>(type: "int", nullable: true),
                    AffectedNumber = table.Column<int>(type: "int", nullable: true),
                    ProductionRate = table.Column<double>(type: "float", nullable: true),
                    PriceBeforeDamage = table.Column<double>(type: "float", nullable: true),
                    InsuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalDamage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalDamage_Damage_DamageId",
                        column: x => x.DamageId,
                        principalTable: "Damage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilitiesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageFacilitiesType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAffectedArea = table.Column<double>(type: "float", nullable: true),
                    ActualDamageArea = table.Column<double>(type: "float", nullable: true),
                    LicenseProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmFacilities_Damage_DamageId",
                        column: x => x.DamageId,
                        principalTable: "Damage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FisheryDamage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FishDamageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNumber = table.Column<int>(type: "int", nullable: true),
                    AffectedNumber = table.Column<int>(type: "int", nullable: true),
                    ProductionRate = table.Column<double>(type: "float", nullable: true),
                    PriceBeforeDamage = table.Column<double>(type: "float", nullable: true),
                    InsuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FisheryDamage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FisheryDamage_Damage_DamageId",
                        column: x => x.DamageId,
                        principalTable: "Damage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantDamage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CropType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CropDamage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CropAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IrrigationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IrrigationOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherTextFieldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CropTypeMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CropTypeOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCropTextFieldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAffectedArea = table.Column<double>(type: "float", nullable: true),
                    ActualDamageArea = table.Column<double>(type: "float", nullable: true),
                    PercentageDamage = table.Column<double>(type: "float", nullable: true),
                    EstimatedProductionRate = table.Column<double>(type: "float", nullable: true),
                    EstimatedPrice = table.Column<double>(type: "float", nullable: true),
                    FruitingStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantDamage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantDamage_Damage_DamageId",
                        column: x => x.DamageId,
                        principalTable: "Damage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyWorkHours = table.Column<double>(type: "float", nullable: true),
                    WeeklyWorkHours = table.Column<double>(type: "float", nullable: true),
                    DamageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHours_Damage_DamageId",
                        column: x => x.DamageId,
                        principalTable: "Damage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalDamage_DamageId",
                table: "AnimalDamage",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_DocumentId",
                table: "Damage",
                column: "DocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Damage_EducationLevelId",
                table: "Damage",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_EmployeeId",
                table: "Damage",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_OwnershipTypeId",
                table: "Damage",
                column: "OwnershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_VillageId",
                table: "Damage",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePrivilieges_PrivliegeId",
                table: "EmployeePrivilieges",
                column: "PrivliegeId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmFacilities_DamageId",
                table: "FarmFacilities",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_FisheryDamage_DamageId",
                table: "FisheryDamage",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifaction_UserId",
                table: "Notifaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantDamage_DamageId",
                table: "PlantDamage",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ComiteeId",
                table: "User",
                column: "ComiteeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_GovernorateId",
                table: "User",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHours_DamageId",
                table: "WorkHours",
                column: "DamageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalDamage");

            migrationBuilder.DropTable(
                name: "EmployeePrivilieges");

            migrationBuilder.DropTable(
                name: "FarmFacilities");

            migrationBuilder.DropTable(
                name: "FisheryDamage");

            migrationBuilder.DropTable(
                name: "Notifaction");

            migrationBuilder.DropTable(
                name: "PlantDamage");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "Priviliege");

            migrationBuilder.DropTable(
                name: "Damage");

            migrationBuilder.DropTable(
                name: "EducationLevel");

            migrationBuilder.DropTable(
                name: "OwnerShipType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropTable(
                name: "Comitee");

            migrationBuilder.DropTable(
                name: "Governorate");
        }
    }
}
