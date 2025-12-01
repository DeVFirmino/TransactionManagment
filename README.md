💰 Financial Goal & Transaction Management API

📖 Project Overview

A robust RESTful API built with .NET 9 designed to manage financial goals (similar to "Banking Sub-accounts") and process atomic monetary transactions.

This project was developed with a focus on Financial Data Integrity, implementing strict patterns required in the Fintech and iGaming industries, such as Decimal Precision handling, Atomic Transactions, and Domain Validations.

🚀 Key Features

Financial Goals Management: Create, Update, and Soft-Delete financial goals.

Transaction Processing: Secure Deposit and Withdrawal operations.

Balance Validation: Logic to prevent negative balances (Overdraft protection).

Data Integrity: Strict usage of decimal types for monetary calculations to avoid floating-point errors.

Audit Trail: Implementation of Soft Delete to preserve historical data.

🏗️ Architecture & Patterns

The solution follows clean coding principles and separates concerns into distinct layers:

Repository Pattern: Decouples the Data Access Layer (EF Core) from Business Logic, facilitating testing and maintenance.

Service Layer: Centralizes all business rules (e.g., verifying funds before withdrawal).

DTOs (Data Transfer Objects): Protects the internal database schema and strictly defines API contracts.

Fluent Validation: Implements "Fail Fast" validations for incoming data (e.g., ensuring amounts are positive and strictly formatted).

Dependency Injection: Fully managed via ASP.NET Core DI container.

🛠️ Tech Stack

Framework: ASP.NET Core Web API (.NET 9)

Database: SQL Server (Dockerized)

ORM: Entity Framework Core (Code-First)

Validation: FluentValidation

Documentation: Swagger UI / OpenAPI

💡 Technical Highlights (iGaming Focus)

1. Financial Precision

The database schema explicitly configures decimal(18,2) using EF Core's HasPrecision to ensure no cent is lost due to truncation, a critical requirement for financial systems.

modelBuilder.Entity<GoalModel>()
    .Property(g => g.CurrentBalance)
    .HasPrecision(18, 2);


2. Transaction Atomicity

Transactions update the Goal's balance and insert the transaction record in a single Unit of Work. If one operation fails, the entire transaction is rolled back, preventing data inconsistency.

3. Custom Validation Logic

Implemented custom logic within FluentValidation to strictly enforce decimal places using mathematical truncation (Math.Truncate), ensuring the API rejects invalid monetary formats before they reach the domain layer.

🔌 API Endpoints

Financial Goals

POST /api/FinancialGoal - Create a new Goal.

GET /api/FinancialGoal - List all active Goals.

GET /api/FinancialGoal/{id} - Get details and balance.

PUT /api/FinancialGoal/{id} - Update Goal details.

DELETE /api/FinancialGoal/{id} - Soft delete a Goal.

Transactions

POST /api/Transaction - Process a Deposit (Type 1) or Withdrawal (Type 2).

⚙️ How to Run

Clone the repository:

git clone [https://github.com/DeVFirmino/TransactionManagement.git](https://github.com/YOUR-USERNAME/TransactionManagement.git)


Configure Database:
Update the ConnectionStrings in appsettings.json with your SQL Server instance.

Apply Migrations:

dotnet ef database update


Run the Application:

dotnet run


Access Swagger UI at: http://localhost:5000/swagger

This project was developed as part of a technical portfolio focusing on Backend Engineering best practices.
