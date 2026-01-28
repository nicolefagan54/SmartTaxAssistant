# SmartTaxAssistant Scaffolding Plan

Reflecting the requested file structure, I will scaffold a new ASP.NET Core MVC solution.

## Proposed Changes

### Project Initialization
- Create a new Solution file `SmartTaxAssistant.sln`
- Create a new ASP.NET Core MVC project `SmartTaxAssistant.Web`
- Add the Web project to the Solution

### Directory Structure & Files

#### SmartTaxAssistant.Web/Controllers
- [NEW] `UploadController.cs`: Controller for handling file uploads.
- [NEW] `QuestionnaireController.cs`: Controller for the questionnaire flow.
- [NEW] `TaxSummaryController.cs`: Controller for displaying tax summaries.
- [MODIFY] `HomeController.cs`: Ensure it exists (default).

#### SmartTaxAssistant.Web/Models
- [NEW] `Taxpayer.cs`: Properties for TaxpayerId, FirstName, LastName, SIN, DateOfBirth, ResidencyProvince, CreatedAt.
- [NEW] `CorporateClient.cs`: Properties for CorporateClientId, LegalName, BusinessNumber, IncorporationProvince, FiscalYearStart, FiscalYearEnd, CreatedAt.
- [NEW] `TaxReturn.cs`: Properties for TaxReturnId, TaxpayerId, CorporateClientId, TaxYear, ReturnType, Status, CreatedAt. Navigation properties to Taxpayer, CorporateClient.
- [NEW] `PdfDocument.cs`: Properties for PdfDocumentId, TaxReturnId, FileName, OriginalPath, UploadedAt. Navigation property to TaxReturn.
- [NEW] `TaxCategory.cs`: Properties for TaxCategoryId, Code, Description, ReturnType.
- [NEW] `ExtractedLineItem.cs`: Properties for ExtractedLineItemId, PdfDocumentId, RawText, Amount, TaxCategoryId, LineNumber. Navigation to PdfDocument, TaxCategory.
- [NEW] `QuestionnaireQuestion.cs`: Properties for QuestionnaireQuestionId, Code, Text, ReturnType, OrderIndex.
- [NEW] `QuestionnaireAnswer.cs`: Properties for QuestionnaireAnswerId, TaxReturnId, QuestionnaireQuestionId, AnswerText. Navigation to TaxReturn, QuestionnaireQuestion.
- [NEW] `TaxRule.cs`: Properties for TaxRuleId, Code, Description, ReturnType, IsActive.

#### SmartTaxAssistant.Web/Data
- [NEW] `SmartTaxContext.cs`: EF Core DbContext with DbSets for all the above models.

#### SmartTaxAssistant.Web/Services
- [NEW] `IPdfParser.cs` / `PdfParserService.cs`: Service for PDF parsing logic.
- [NEW] `IClassificationService.cs` / `ClassificationService.cs`: Service for classifying tax items.
- [NEW] `IQuestionnaireService.cs` / `QuestionnaireService.cs`: Service for managing questionnaires.
- [NEW] `ITaxComputationService.cs` / `TaxComputationService.cs`: Service for tax calculations.

#### SmartTaxAssistant.Web/Views
- Create folders: `Upload`, `Questionnaire`, `TaxSummary`.
- Create placeholder views (Index.cshtml) for each to identify them.

## Verification Plan

### Automated Tests
- Run `dotnet build` to ensure the project compiles with the new files.
- Run `dotnet run` (briefly) to verify the app starts.

### Manual Verification
- Check the file system to ensure the structure matches the user's request.
