# Cinema Management System Documentation

## 1. Project Overview
This represents a Console-based Cinema Management System built in C#. It allows for managing films, customers, bookings, and employees. The system demonstrates key Object-Oriented Programming (OOP) principles and follows a clean architecture by separating logic into different classes and interfaces.

## 2. Project Structure
The project is organized into the following directories:
- **Root**: Contains the main entry point (`cinema_main_program.cs`).
- **Classes**: Contains all the entity classes and menu logic.
- **Interfaces**: Contains the contracts (interfaces) that classes must implement.

### File Manifest
- `cinema_main_program.cs`: Entry point. Initializes the database and launches the Main Menu.
- `classes/`:
  - `Database.cs`: A Singleton class acting as an in-memory database.
  - `Person.cs`, `Customer.cs`, `Employee.cs`: User management entities.
  - `Seat.cs`, `RegularSeat.cs`, `VIPSeat.cs`, `PremiumSeat.cs`: Seat management with inheritance.
  - `Film.cs`, `Hall.cs`, `Ticket.cs`: Core cinema entities.
  - `*_menu.cs`: Classes handling the UI and logic for different menus (Main, Customer, Employee).
- `interfaces/`:
  - `IBookable.cs`: Interface for things that can be booked (like Seats).
  - `IDisplayable.cs`: Interface for things that can display info.

---

## 3. Key Components & Logic

### 3.1. Database (Singleton Pattern)
The system uses a **Singleton Pattern** for the `Database` class.
- **Why?** To ensure there is only *one* instance of the data throughout the application's lifecycle, so all menus access the same lists of customers, films, etc.
- **Storage**: Data is stored in `List<T>` properties (e.g., `List<Customer>`, `List<Film>`) which act as in-memory tables.

### 3.2. User Hierarchy (Inheritance & Abstraction)
- **`Person` (Abstract Class)**: Defines common properties like `Name`, `Id`, `Phone`, `Email`, and `Password`. It cannot be instantiated directly.
- **`Customer`**: Inherits from `Person`. Represents end-users who book tickets.
- **`Employee`**: Inherits from `Person`. Represents staff who manage films and view stats.

### 3.3. Seat Management (Polymorphism)
- **`Seat` (Abstract Class)**: Defines the base properties (`Booked`, `Price`) and implements `IBookable`.
- **Derived Classes**: `RegularSeat`, `VIPSeat`, and `PremiumSeat` inherit from `Seat`.
  - They can have different prices or behaviors, demonstrating **Polymorphism**.

### 3.4. Menus
The UI is broken down into specific menu classes to keep the code organized:
- **`MainMenu`**: The starting point. Asks user to Login or Register.
- **`CustomerMenu`**: Handles booking, viewing films, and cancelling reservations.
- **`EmployeeMenu`**: Handles adding/removing films and viewing system data.
- **`SystemStatisticsMenu`**: A dedicated section to view reports.

---

## 4. OOP Principles Demonstrated

### Encapsulation
Data is protected within classes. For example, in `Person.cs`, fields like `personCount` are protected, and public access is controlled via methods or properties.
```csharp
// Example from Person.cs
protected string Password { get; set; } // Only accessible by derived classes
```

### Abstraction
Complex logic is hidden behind simpler interfaces.
- The `Person` class is **abstract**, forcing developers to create specific types of people (`Customer`, `Employee`) rather than a generic "Person".
- The `Seat` class is **abstract** because a generic seat doesn't exist; it must be a specific type.

### Inheritance
- `Customer` **is a** `Person`.
- `VIPSeat` **is a** `Seat`.
This reduces code duplication by sharing common logic in the base classes.

### Polymorphism
- The `Book()` method in the `Seat` class can be overridden by derived seat types if they require special booking logic.
- The `DisplayInfo()` method is virtual, allowing `Customer` and `Employee` to display their information differently while sharing the same method signature.

### Interfaces
- `IBookable`: Ensures that any class implementing it (like `Seat`) *must* have `Book()` and `CancelBooking()` methods. This allows the system to treat different objects as "bookable" without knowing their exact type.

---

## 5. How to Run
1. Open a terminal in the project directory.
2. Run the command:
   ```bash
   dotnet run
   ```
3. Follow the on-screen prompts to navigate the menus.
