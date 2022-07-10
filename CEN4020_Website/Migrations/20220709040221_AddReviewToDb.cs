using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEN4020_Website.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaperID = table.Column<int>(type: "int", nullable: false),
                    ReviewerID = table.Column<int>(type: "int", nullable: false),
                    AppropriatenessOfTopic = table.Column<int>(type: "int", nullable: false),
                    TimelinessOfTopic = table.Column<int>(type: "int", nullable: false),
                    SupportiveEvidence = table.Column<int>(type: "int", nullable: false),
                    TechnicalQuality = table.Column<int>(type: "int", nullable: false),
                    ScopeOfCoverage = table.Column<int>(type: "int", nullable: false),
                    CitationOfPreviousWork = table.Column<int>(type: "int", nullable: false),
                    Originality = table.Column<int>(type: "int", nullable: false),
                    ContentComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationOfPaper = table.Column<int>(type: "int", nullable: false),
                    ClarityOfMainMessage = table.Column<int>(type: "int", nullable: false),
                    Mechanics = table.Column<int>(type: "int", nullable: false),
                    WrittenDocumentComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuitabilityForPresentation = table.Column<int>(type: "int", nullable: false),
                    PotentialInterestInTopic = table.Column<int>(type: "int", nullable: false),
                    PotentialForOralPresentationComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverallRating = table.Column<int>(type: "int", nullable: false),
                    OverallRatingComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComfortLevelTopic = table.Column<int>(type: "int", nullable: false),
                    ComfortLevelAcceptability = table.Column<int>(type: "int", nullable: false),
                    Complete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
