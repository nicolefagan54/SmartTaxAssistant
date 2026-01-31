# SmartTaxAssistant (Ontario Edition)

![Status](https://img.shields.io/badge/Status-Active-brightgreen)
![Framework](https://img.shields.io/badge/ASP.NET%20Core%20MVC-10.0-blue)
![Language](https://img.shields.io/badge/C%23-Backend-purple)
![Database](https://img.shields.io/badge/SQL%20Server-Database-orange)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

SmartTaxAssistant is a workflow‑driven tax organizer web application built with **ASP.NET Core MVC**, **C#**, and **SQL Server**.  
It guides users through structured tax‑related questions and stores their responses for easy review and preparation.

---

## 📸 Application Preview

![Application Preview](docs/screenshots/preview.png)

> **Note**: Place your screenshot at `docs/screenshots/preview.png`.

---

## 🚀 Features

- Step‑by‑step tax questionnaire  
- Clean MVC architecture  
- SQL Server database integration  
- Data validation and error handling  
- Responsive UI with Razor + Bootstrap  
- Service layer for business logic  
- Code‑first migrations  

---

## 🛠️ Tech Stack

**Frontend:**

- Razor Views  
- HTML, CSS, Bootstrap  

**Backend:**

- C#  
- ASP.NET Core MVC  

**Database:**

- SQL Server  
- Entity Framework Core  

---

## 📁 Project Structure

```text
SmartTaxAssistant.Web/
├── Controllers/
│   ├── HomeController.cs
│   ├── QuestionnaireController.cs
│   ├── TaxSummaryController.cs
│   └── UploadController.cs
├── Data/
│   ├── SeedData.cs
│   └── SmartTaxContext.cs
├── Migrations/
├── Models/
│   ├── CorporateClient.cs
│   ├── ErrorViewModel.cs
│   ├── ExtractedLineItem.cs
│   ├── PdfDocument.cs
│   ├── QuestionnaireAnswer.cs
│   ├── QuestionnaireQuestion.cs
│   ├── TaxCategory.cs
│   ├── Taxpayer.cs
│   ├── TaxReturn.cs
│   └── TaxRule.cs
├── Services/
│   ├── ClassificationService.cs
│   ├── IClassificationService.cs
│   ├── IPdfParser.cs
│   ├── IQuestionnaireService.cs
│   ├── ITaxComputationService.cs
│   ├── PdfParserService.cs
│   ├── QuestionnaireService.cs
│   └── TaxComputationService.cs
├── Views/
│   ├── Home/
│   ├── Questionnaire/
│   ├── Shared/
│   ├── TaxSummary/
│   └── Upload/
├── wwwroot/
├── appsettings.json
└── Program.cs
```

## ⚙️ How to Run the Project

1. **Clone the repository:**
   ```bash
   git clone https://github.com/nicolefagan54/SmartTaxAssistant.git
   ```

2. **Navigate to the web project:**
   ```bash
   cd SmartTaxAssistant.Web
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```
   > **Note**: The application will automatically apply database migrations on startup.

4. **Open your browser** to `http://localhost:5039`.

---

## 📌 Future Enhancements

- Add user authentication
- Add PDF export of tax summary
- Add dashboard for reviewing completed entries
- Add CRA‑specific modules
- Add multi‑province support

---

## 👩‍💻 Author

**Nicole Fagan**  
Junior Software Developer  
GitHub: [nicolefagan54](https://github.com/nicolefagan54)
