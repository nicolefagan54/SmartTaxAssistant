🚀 Features
Step‑by‑step tax questionnaire

Organized workflows for personal and financial information

Data validation and error handling

SQL Server database integration

MVC architecture with clean separation of concerns

Responsive UI using Razor views and Bootstrap

Service layer for business logic

Migration‑based database setup

🛠️ Tech Stack
Frontend:

Razor Views

HTML, CSS, Bootstrap

Backend:

C#

ASP.NET Core MVC

Service Layer Architecture

Database:

SQL Server

Entity Framework Core

Code‑First Migrations

📁 Project Structure
Code
Controllers/        # Handles user requests and workflows
Models/             # Data models and validation
Views/              # Razor pages for UI
Services/           # Business logic and workflow handling
Data/               # Database context
Migrations/         # EF Core migrations
wwwroot/            # Static files (CSS, JS, images)
docs/               # Project documentation
⚙️ How to Run the Project
Clone the repository:

Code
git clone https://github.com/nicolefagan54/SmartTaxAssistant
Open the solution in Visual Studio.

Update the connection string in appsettings.json:

json
"ConnectionStrings": {
  "DefaultConnection": "Your SQL Server connection string"
}
Apply migrations:

Code
Update-Database
Run the project:

Code
dotnet run
📌 Future Enhancements
Add user authentication

Add PDF export of tax summary

Add dashboard for reviewing completed entries

Add CRA‑specific modules

Add multi‑province support

👩‍💻 Author
Nicole Fagan  
Junior Software Developer
GitHub: github.com/nicolefagan54
