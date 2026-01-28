using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTaxAssistant.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateClients",
                columns: table => new
                {
                    CorporateClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BusinessNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IncorporationProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FiscalYearStart = table.Column<DateTime>(type: "DATE", nullable: true),
                    FiscalYearEnd = table.Column<DateTime>(type: "DATE", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateClients", x => x.CorporateClientId);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireQuestions",
                columns: table => new
                {
                    QuestionnaireQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReturnType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireQuestions", x => x.QuestionnaireQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "TaxCategories",
                columns: table => new
                {
                    TaxCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReturnType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCategories", x => x.TaxCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Taxpayers",
                columns: table => new
                {
                    TaxpayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SIN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: true),
                    ResidencyProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxpayers", x => x.TaxpayerId);
                });

            migrationBuilder.CreateTable(
                name: "TaxRules",
                columns: table => new
                {
                    TaxRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReturnType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.TaxRuleId);
                });

            migrationBuilder.CreateTable(
                name: "TaxReturns",
                columns: table => new
                {
                    TaxReturnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxpayerId = table.Column<int>(type: "int", nullable: true),
                    CorporateClientId = table.Column<int>(type: "int", nullable: true),
                    TaxYear = table.Column<int>(type: "int", nullable: false),
                    ReturnType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TotalIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalTaxPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstimatedBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReturns", x => x.TaxReturnId);
                    table.ForeignKey(
                        name: "FK_TaxReturns_CorporateClients_CorporateClientId",
                        column: x => x.CorporateClientId,
                        principalTable: "CorporateClients",
                        principalColumn: "CorporateClientId");
                    table.ForeignKey(
                        name: "FK_TaxReturns_Taxpayers_TaxpayerId",
                        column: x => x.TaxpayerId,
                        principalTable: "Taxpayers",
                        principalColumn: "TaxpayerId");
                });

            migrationBuilder.CreateTable(
                name: "PdfDocuments",
                columns: table => new
                {
                    PdfDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxReturnId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OriginalPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfDocuments", x => x.PdfDocumentId);
                    table.ForeignKey(
                        name: "FK_PdfDocuments_TaxReturns_TaxReturnId",
                        column: x => x.TaxReturnId,
                        principalTable: "TaxReturns",
                        principalColumn: "TaxReturnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireAnswers",
                columns: table => new
                {
                    QuestionnaireAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxReturnId = table.Column<int>(type: "int", nullable: false),
                    QuestionnaireQuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireAnswers", x => x.QuestionnaireAnswerId);
                    table.ForeignKey(
                        name: "FK_QuestionnaireAnswers_QuestionnaireQuestions_QuestionnaireQuestionId",
                        column: x => x.QuestionnaireQuestionId,
                        principalTable: "QuestionnaireQuestions",
                        principalColumn: "QuestionnaireQuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionnaireAnswers_TaxReturns_TaxReturnId",
                        column: x => x.TaxReturnId,
                        principalTable: "TaxReturns",
                        principalColumn: "TaxReturnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtractedLineItems",
                columns: table => new
                {
                    ExtractedLineItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdfDocumentId = table.Column<int>(type: "int", nullable: false),
                    RawText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxCategoryId = table.Column<int>(type: "int", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: true),
                    TaxReturnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtractedLineItems", x => x.ExtractedLineItemId);
                    table.ForeignKey(
                        name: "FK_ExtractedLineItems_PdfDocuments_PdfDocumentId",
                        column: x => x.PdfDocumentId,
                        principalTable: "PdfDocuments",
                        principalColumn: "PdfDocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtractedLineItems_TaxCategories_TaxCategoryId",
                        column: x => x.TaxCategoryId,
                        principalTable: "TaxCategories",
                        principalColumn: "TaxCategoryId");
                    table.ForeignKey(
                        name: "FK_ExtractedLineItems_TaxReturns_TaxReturnId",
                        column: x => x.TaxReturnId,
                        principalTable: "TaxReturns",
                        principalColumn: "TaxReturnId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtractedLineItems_PdfDocumentId",
                table: "ExtractedLineItems",
                column: "PdfDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtractedLineItems_TaxCategoryId",
                table: "ExtractedLineItems",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtractedLineItems_TaxReturnId",
                table: "ExtractedLineItems",
                column: "TaxReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfDocuments_TaxReturnId",
                table: "PdfDocuments",
                column: "TaxReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireAnswers_QuestionnaireQuestionId",
                table: "QuestionnaireAnswers",
                column: "QuestionnaireQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireAnswers_TaxReturnId",
                table: "QuestionnaireAnswers",
                column: "TaxReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReturns_CorporateClientId",
                table: "TaxReturns",
                column: "CorporateClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxReturns_TaxpayerId",
                table: "TaxReturns",
                column: "TaxpayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtractedLineItems");

            migrationBuilder.DropTable(
                name: "QuestionnaireAnswers");

            migrationBuilder.DropTable(
                name: "TaxRules");

            migrationBuilder.DropTable(
                name: "PdfDocuments");

            migrationBuilder.DropTable(
                name: "TaxCategories");

            migrationBuilder.DropTable(
                name: "QuestionnaireQuestions");

            migrationBuilder.DropTable(
                name: "TaxReturns");

            migrationBuilder.DropTable(
                name: "CorporateClients");

            migrationBuilder.DropTable(
                name: "Taxpayers");
        }
    }
}
