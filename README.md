# 📚 Library Management System

> A console-based Library Management System built with **C#** using **Repository** and **Service** patterns.

![C#](https://img.shields.io/badge/C%23-.NET-purple?style=for-the-badge)
![Platform](https://img.shields.io/badge/Platform-Windows-blue?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

---

## 📖 About

Library Management System is a console application designed to simulate the work of a real library.

The project was created for practicing object-oriented programming, layered architecture, dependency injection principles, repository and service patterns, and working with collections in C#.

---

## ✨ Features

### 📚 Book Management

- Add new books
- Remove books
- Edit book information
- Search books by ID
- Search books by title
- Search books by author
- View available books
- View books by genre
- Sort books by pages

---

### 👤 Reader Management

- Register new readers
- Remove readers
- Edit reader information
- Find reader by ID
- Display all readers

---

### 🔄 Borrowing System

- Borrow books
- Return books
- Automatic availability tracking
- Borrow history
- Due date calculation
- Late return detection
- Fine calculation

---

### 📊 Statistics

- Most popular books
- Books grouped by genre
- Active borrowings
- Total number of books
- Total number of readers

---

### 📝 Logging

Every important action is automatically written into a log file.

Example:

```text
[INFO] [2026-07-09 23:49:12] Book Harry Potter added.
[INFO] [2026-07-09 23:49:34] Reader Arsen added.
[INFO] [2026-07-09 23:49:59] Book borrowed.
```

Logs are stored in:

```
Data/logs.txt
```

---

# 🏗 Project Structure

```
Library Management System
│
├── Enums/
├── Interfaces/
├── Library.Models/
├── Menus/
├── Repositories/
├── Services/
├── Utils/
├── Data/
│
├── Program.cs
└── Library Management System.csproj
```

---

## 🧩 Architecture

```
Console Menu
      │
      ▼
Services
      │
      ▼
Repositories
      │
      ▼
Collections
```

### Models

Contains all business entities:

- Book
- Reader
- BorrowRecord
- Person
- Employee
- Librarian

---

### Repository Layer

Responsible for data storage and CRUD operations.

Generic repository:

```csharp
Repositories<T>
```

Implemented operations:

- Add
- Remove
- Update
- FindById
- GetAll

---

### Service Layer

Contains business logic.

Services:

- BookService
- ReaderService
- BorrowService
- StatisticsService
- FileLogger

---

### Utilities

Contains helper classes.

Current:

- ValidationHelper

---

## 🛠 Technologies

- C#
- .NET
- Object-Oriented Programming
- Repository Pattern
- Service Pattern
- Dependency Injection
- Generic Collections
- LINQ
- File IO
- Exception Handling

---

## 🚀 Getting Started

Clone the repository

```bash
git clone https://github.com/ArsenBo1chuk/Library-Management-System.git
```

Open the solution

```bash
dotnet build
```

Run

```bash
dotnet run
```

---

## 🎯 Learning Goals

This project was created to practice:

- SOLID principles
- Generic programming
- Dependency Injection
- Interfaces
- Exception handling
- LINQ
- File handling
- Clean architecture
- Repository pattern
- Service layer architecture

---

## 📷 Preview

```
========== LIBRARY ==========
1. Books
2. Readers
3. Borrow books
4. Statistics
5. Exit
=============================
```

---

## 📈 Future Improvements

- JSON persistence
- Database support (SQLite/PostgreSQL)
- Authentication
- Roles & permissions
- Unit testing
- ASP.NET Core Web API
- WPF/WinUI graphical interface

---

## 👨‍💻 Author

**Arsen Boichuk**

Software Engineering Student

Backend Developer (C++ / C#)


[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/ArsenBo1chuk)
[![Telegram](https://img.shields.io/badge/Telegram-26A5E4?style=for-the-badge&logo=telegram&logoColor=white)](https://t.me/Arsen_Bo1chuk)

---

⭐ If you like this project, consider giving it a star!