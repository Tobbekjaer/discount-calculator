# Discount Calculator

A C# project demonstrating a practical testing strategy for a discount calculation system. Built as part of a Software Quality exam, the project covers **Design for Testability**, **Black Box Testing** (Equivalence Class, Boundary Value, and Decision Table Testing), and **BDD with Cucumber**.

## Project Structure

```
DiscountCalculator/
├── src/
│   └── DiscountCalculator.Core/
│       ├── Enums/           # CustomerType, Season
│       ├── Interfaces/      # IDateService
│       ├── Services/        # DiscountCalculator
│       └── Infrastructure/  # SystemDateService
└── tests/
    └── DiscountCalculator.Tests/
        ├── Fakes/           # FakeDateService
        ├── BddTests/        # Gherkin feature files and step definitions
        └── UnitTests/       # xUnit unit tests
```

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Getting Started

Clone the repository and restore dependencies:

```bash
git clone https://github.com/Tobbekjaer/discount-calculator.git
cd discount-calculator
dotnet restore
```

## Running the Tests

```bash
dotnet test
```

This runs all 24 tests - 12 BDD scenarios and 12 unit tests.

## Tech Stack

- **C# / .NET 10**
- **xUnit** - unit testing framework
- **Reqnroll** - .NET implementation of Cucumber for BDD
