using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgrammersBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Teyfik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Callsite = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Exception = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MakinaTipi = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderType = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    DayTarget = table.Column<int>(type: "int", nullable: false),
                    KesimOran = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    GorevlerId = table.Column<int>(type: "int", nullable: false),
                    PersonCart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Gorevler_GorevlerId",
                        column: x => x.GorevlerId,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    WorkHoursId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTargets_WorkHours_WorkHoursId",
                        column: x => x.WorkHoursId,
                        principalTable: "WorkHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderOperations",
                columns: table => new
                {
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OperationTarget = table.Column<int>(type: "int", nullable: false),
                    ConnectOperationId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOperations", x => new { x.OrderId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_OrderOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderOperations_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderSizes",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    SizeTarget = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSizes", x => new { x.OrderId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_OrderSizes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPerformance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TasksCompleted = table.Column<int>(type: "int", nullable: false),
                    DailyTargetId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPerformance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPerformance_DailyTargets_DailyTargetId",
                        column: x => x.DailyTargetId,
                        principalTable: "DailyTargets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    WorkType = table.Column<int>(type: "int", nullable: false),
                    OrderOperationOrderId = table.Column<int>(type: "int", nullable: false),
                    OrderOperationOperationId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonWorks_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonWorks_OrderOperations_OrderOperationOrderId_OrderOperationOperationId",
                        columns: x => new { x.OrderOperationOrderId, x.OrderOperationOperationId },
                        principalTable: "OrderOperations",
                        principalColumns: new[] { "OrderId", "OperationId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonWorks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonWorks_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4010), null, true, false, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4011), "Makina Arızası", null },
                    { 2, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4018), null, true, false, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4019), "Elektrik Kesintisi", null },
                    { 3, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4024), null, true, false, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4025), "Jeneratör Arızası", null },
                    { 4, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4029), null, true, false, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4031), "Personel istifa", null },
                    { 5, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4035), null, true, false, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4036), "Personel Münakaşa", null },
                    { 6, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4041), null, true, false, "Admin", new DateTime(2024, 8, 12, 21, 39, 1, 497, DateTimeKind.Local).AddTicks(4052), "iş Yok", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, true, false, "Dikim Bölümü" },
                    { 2, null, true, false, "Ütü Bölümü" },
                    { 3, null, true, false, "Poşet Bölümü" }
                });

            migrationBuilder.InsertData(
                table: "Gorevler",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, true, false, "Makinacı" },
                    { 2, null, true, false, "Ütücü" },
                    { 3, null, true, false, "Ayakcı" },
                    { 4, null, true, false, "Ayakcı Makinacı" },
                    { 5, null, true, false, "İp Temizlemeci" }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "MakinaTipi", "OperationName" },
                values: new object[,]
                {
                    { 1, null, true, false, "", "Bant Giriş" },
                    { 2, null, true, false, "", "Çevirme" },
                    { 3, null, true, false, "", "Çevirme Beden" },
                    { 4, null, true, false, "", "Ense Biye" },
                    { 5, null, true, false, "", "Etek Reçme" },
                    { 6, null, true, false, "", "Etiket Hazırlama" },
                    { 7, null, true, false, "", "Kalite" },
                    { 8, null, true, false, "", "Kol Reçme" },
                    { 9, null, true, false, "", "Kol Takma" },
                    { 10, null, true, false, "", "Omuz Çatma" },
                    { 11, null, true, false, "", "Tela Yapıştırma" },
                    { 12, null, true, false, "", "Ütü" },
                    { 13, null, true, false, "", "Yaka Basma 1.Et(Beden)" },
                    { 14, null, true, false, "", "Yaka Çıma" },
                    { 15, null, true, false, "", "Yaka iç Dikiş" },
                    { 16, null, true, false, "", "Yaka Takma" },
                    { 17, null, true, false, "", "Yaka Tıktık" },
                    { 18, null, true, false, "", "Yan Kapama" },
                    { 19, null, true, false, "", "Yıkama Kapama" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "544680f3-b801-461b-8778-cab161e5d979", "Category.Create", "CATEGORY.CREATE" },
                    { 2, "ce10f859-01c9-4334-aae1-074e97257872", "Category.Read", "CATEGORY.READ" },
                    { 3, "b4fe3bac-ae44-4300-b5bf-c407661ea5a6", "Category.Update", "CATEGORY.UPDATE" },
                    { 4, "4cf5e652-8f89-48e9-9892-3265b5d553f8", "Category.Delete", "CATEGORY.DELETE" },
                    { 5, "62f89eaa-ee99-4fc0-8210-e768616dde61", "Article.Create", "ARTICLE.CREATE" },
                    { 6, "3558361e-a778-4e46-85e4-3f94930b01fe", "Article.Read", "ARTICLE.READ" },
                    { 7, "30d469db-74c5-4dfe-8b12-34fd36335324", "Article.Update", "ARTICLE.UPDATE" },
                    { 8, "4d7f0c4a-7122-4bdb-8cb7-72105675159e", "Article.Delete", "ARTICLE.DELETE" },
                    { 9, "bc708047-c8c4-445b-a58e-8644af28b3bf", "User.Create", "USER.CREATE" },
                    { 10, "11ee0ed3-9742-4ef6-8e36-84278d2a704b", "User.Read", "USER.READ" },
                    { 11, "efff1fae-8dd4-41f5-8481-fc8ab5ac7888", "User.Update", "USER.UPDATE" },
                    { 12, "20c1dbc9-c5be-41c7-a022-654cc8676679", "User.Delete", "USER.DELETE" },
                    { 13, "6b963485-5252-4e6e-9920-f06db4566cdd", "Role.Create", "ROLE.CREATE" },
                    { 14, "a6311586-6654-4d23-8914-a0fded04b910", "Role.Read", "ROLE.READ" },
                    { 15, "0fba5422-c1db-46cb-9a01-0199452e85f0", "Role.Update", "ROLE.UPDATE" },
                    { 16, "a32ca96c-610a-4ca1-b162-6b8b43f32625", "Role.Delete", "ROLE.DELETE" },
                    { 17, "75a977ec-2855-4a98-8380-37c2477efe31", "Comment.Create", "COMMENT.CREATE" },
                    { 18, "f2b9cced-fa2b-4821-b759-f3eb12b93904", "Comment.Read", "COMMENT.READ" },
                    { 19, "891a70a3-08d3-418e-9a96-bb35b6ad705e", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "5286247f-9972-4c2f-8d49-d2f210833a72", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "f120902a-a817-4888-b466-e06102c4ca31", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 22, "133e933d-a49c-43e7-83dc-0ca921308b9d", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "SizeName" },
                values: new object[,]
                {
                    { 1, null, true, false, "L" },
                    { 2, null, true, false, "XL" },
                    { 3, null, true, false, "XXL" },
                    { 4, null, true, false, "XXXL" },
                    { 5, null, true, false, "S" },
                    { 6, null, true, false, "M" },
                    { 7, null, true, false, "XS" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, "Admin User of ProgrammersBlog", 0, "ceb02028-6643-453a-a965-e87f80520bef", "adminuser@gmail.com", true, "Admin", "User", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAIAAYagAAAAEGMhjcDhGrYkjGSfjxywNOQItUMBebd9a1CcesUf6Htpbxp9DiONRezbhdNM3g6HdA==", "+905555555555", true, "/userImages/defaultUser.png", "a163f7c0-4b51-42f7-8946-0c01cc12934a", false, "adminuser" },
                    { 2, "Editor User of ProgrammersBlog", 0, "1528dec8-89c5-453b-b0bf-706524ac64ac", "editoruser@gmail.com", true, "Admin", "User", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAIAAYagAAAAENYZcD0pW2m8+aM/yULmW/5JbwYPUPXtzcm9vcyFL7SBjH1yprNq9dZRMe3RJaAMSg==", "+905555555555", true, "/userImages/defaultUser.png", "c9c4937f-4376-44a4-bdd8-36d050ad782d", false, "editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DepartmentId", "Description", "FirstName", "GorevlerId", "IsActive", "IsDeleted", "PersonCart" },
                values: new object[,]
                {
                    { 1, 1, null, "Ayşe ADADA", 1, true, false, "53 EE CC 0E" },
                    { 2, 2, null, "Ayşe ALTUN", 2, true, false, "93 F6 A5 A5" },
                    { 3, 3, null, "Ayşenur YETER", 3, true, false, "C3 17 12 AD" },
                    { 4, 1, null, "Baise KURTULDU", 4, true, false, "B3 DB A7 15" },
                    { 5, 2, null, "Begüm DURMAZ", 5, true, false, "" },
                    { 6, 3, null, "Beyzanur ERTÜRK", 2, true, false, "" },
                    { 7, 1, null, "Derya KESKİN", 2, true, false, "" },
                    { 8, 2, null, "Ebru CANSU", 3, true, false, "03 EB 6A 1A" },
                    { 9, 3, null, "Emine BAYRAM", 4, true, false, "" },
                    { 10, 1, null, "Emine GAPAYLAR", 5, true, false, "" },
                    { 11, 2, null, "Emine PİŞKİN", 1, true, false, "" },
                    { 12, 2, null, "Esra DURSUN", 2, true, false, "" },
                    { 13, 3, null, "Fadime SAATCİ", 3, true, false, "" },
                    { 14, 1, null, "Hazime AVCI", 4, true, false, "" },
                    { 15, 2, null, "Hayal ŞENER", 5, true, false, "" },
                    { 16, 3, null, "Fatma BALCI", 1, true, false, "" },
                    { 17, 2, null, "Fatma KIZILTAN", 2, true, false, "" },
                    { 18, 1, null, "Faruk BİÇER", 3, true, false, "" },
                    { 19, 1, null, "Gülcan MUHTANCI", 4, true, false, "" },
                    { 20, 2, null, "Güler SAĞCAN", 5, true, false, "" },
                    { 21, 2, null, "Hanife BOZKURT", 1, true, false, "" },
                    { 22, 2, null, "Hatice ÖZDİL", 1, true, false, "" },
                    { 23, 2, null, "Hava SUBAŞI", 1, true, false, "" },
                    { 24, 2, null, "Hayal ŞENER", 1, true, false, "" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 17, 2 },
                    { 18, 2 },
                    { 19, 2 },
                    { 20, 2 },
                    { 21, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTargets_WorkHoursId",
                table: "DailyTargets",
                column: "WorkHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOperations_OperationId",
                table: "OrderOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSizes_SizeId",
                table: "OrderSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPerformance_DailyTargetId",
                table: "PersonPerformance",
                column: "DailyTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DepartmentId",
                table: "Persons",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GorevlerId",
                table: "Persons",
                column: "GorevlerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorks_OperationId",
                table: "PersonWorks",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorks_OrderId",
                table: "PersonWorks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorks_OrderOperationOrderId_OrderOperationOperationId",
                table: "PersonWorks",
                columns: new[] { "OrderOperationOrderId", "OrderOperationOperationId" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorks_PersonId",
                table: "PersonWorks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "OrderSizes");

            migrationBuilder.DropTable(
                name: "PersonPerformance");

            migrationBuilder.DropTable(
                name: "PersonWorks");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "DailyTargets");

            migrationBuilder.DropTable(
                name: "OrderOperations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
