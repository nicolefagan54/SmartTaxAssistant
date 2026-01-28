# SmartTaxAssistant Implementation Walkthrough

I have successfully implemented the core logic and flow for the **SmartTaxAssistant** application.

## Accomplishments

### 1. Scaffolding & Database
- **Solution Structure**: ASP.NET Core MVC project with Entity Framework Core and SQL Server support.
- **Data Models**: Implemented full schema (`TaxReturn`, `PdfDocument`, `ExtractedLineItem`, `TaxCategory`, `Questionnaire` items).
- **Seeding**: Created `SeedData` to populate:
  - **Questionnaire**: T1 (Personal) and T2 (Corporate) questions.
  - **Tax Categories**: 'EMP_INCOME', 'BUS_EXP_RENT', etc.
- **Legal Disclaimer**: Added to the global footer layout.

### 2. Integrated Flow (`UploadController` & `Home`)
- **First Page**: The Home page now redirects immediately to the "Start New Return" page.
- **Combined View**: Displays the File Upload and the Questionnaire side-by-side.
- **Dynamic Questions**: Toggling "Personal" vs "Corporate" instantly switches the visible questions.
- **Submission**: Handles creating the return, uploading the PDF, saving answers, and parsing in one action.

### 3. PDF Parsing (`PdfParserService`)
- **Current State**: Returns **mock data** (Employment Income, CPP, etc.) to demonstrate the full application flow without needing a real PDF parser configuration.
- **Reference**: `PdfParserService.cs`

### 4. Questionnaire Flow (`QuestionnaireController` & `QuestionnaireService`)
- **Service**: Fetches questions from DB based on `ReturnType` (Personal/Corporate). saves answers.
- **Controller**:
  - `Start (GET)`: Loads the tax return and appropriate questions.
  - `Start (POST)`: Saves user answers and redirects to the Tax Summary.

### 5. Classification (`ClassificationService`)
- Implemented rule-based classification:
  - "T4" or "EMPLOYMENT INCOME" -> **EMP_INCOME**
  - "RENT" -> **BUS_EXP_RENT**
- Can be extended with more complex rules or ML in the future.

### 6. Seeding (`SeedData`)
- Populates specific questions for Personal (T1) and Corporate (T2) returns.
- Initializes Tax Categories.

## Verification
- **Build Status**: `Build succeeded.`
- **Dependencies**: All NuGet packages (`PdfPig`, `EF Core`) installed and resolved.

## How to Run
1. **Database**: Ensure you have a local SQL Server instance (or `LocalDB`). The connection string is pre-configured in `appsettings.json`.
2. **Migration (Optional but recommended)**:
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
3. **Run**:
   ```bash
   dotnet run
   ```
   **Note**: The application is configured to automatically apply any pending Entity Framework migrations on startup (`context.Database.Migrate()`), ensuring the schema is always "wired up".

   The application will start on `http://localhost:5039` (or similar port displayed in your terminal).

4. **Test**:
   - Navigate to **[http://localhost:5039](http://localhost:5039)**.
   - Go to "Upload Documents".
   - Select "Personal", Year "2025", and upload a sample PDF.
   - Verify redirection to Questionnaire and database population.
