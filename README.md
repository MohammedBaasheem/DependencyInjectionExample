# Dependency Injection Example in .NET API

This project demonstrates the Dependency Injection (DI) pattern in a .NET API.  DI is a crucial technique for building maintainable, testable, and loosely coupled applications.  It promotes separation of concerns by decoupling dependencies between objects.

## What is Dependency Injection?

Dependency Injection is a design pattern where dependencies are provided to a class instead of the class creating them itself.  This is achieved by injecting the dependencies through the constructor, method parameters, or properties.  This inversion of control allows for greater flexibility, testability, and reusability of code.

## Project Overview

This API project showcases the different lifetimes of injected services: Transient, Scoped, and Singleton.  It uses an `Operation` class that implements interfaces for each lifetime, and a `FirstService` that depends on these interfaces.  The `ServicesController` then uses both the `Operation` interfaces directly and the `FirstService`.

### Key Components

*   **Interfaces (ITransient, IScoped, ISingleton):** Define contracts for the different service lifetimes.  The `IOperation` interface provides a common `OperationID` property.
*   **Operation:** Implements the lifetime interfaces.  Each instance generates a unique `OperationID`.
*   **FirstService:** Demonstrates how to inject multiple services with different lifetimes.
*   **ServicesController:** Exposes an endpoint (`/operationids`) that triggers the logging of the operation IDs to demonstrate the different service lifetimes.
*   **Program.cs:** Configures the dependency injection container and registers the services with their respective lifetimes.

### Service Lifetimes

*   **Transient:** A new instance is created each time the service is requested.  `builder.Services.AddTransient<ITransient, Operation>();`
*   **Scoped:** A single instance is created per request scope.  In a web application, this typically means one instance per HTTP request. `builder.Services.AddScoped<IScoped, Operation>();`
*   **Singleton:** A single instance is created for the entire application lifetime. `builder.Services.AddSingleton<ISingleton, Operation>();`

### How the Project Works

1.  The `Program.cs` file registers the services with the dependency injection container, specifying their lifetimes.
2.  The `ServicesController` and `FirstService` classes receive the required services through their constructors.  The container automatically resolves these dependencies and injects the appropriate instances.
3.  When the `/operationids` endpoint is called, the controller logs the `OperationID` of each injected service.  The logs will demonstrate the different lifetimes:
    *   Transient: Each request will have a different `OperationID`.
    *   Scoped: Within a single request, the `OperationID` will be the same, but different requests will have different IDs.
    *   Singleton: The `OperationID` will be the same for all requests throughout the application's lifetime.
4.  The `FirstService` also logs the OperationIDs, further illustrating the service lifetimes within a different class that also uses dependency injection.

## Running the Project

1.  Clone the repository.
2.  Navigate to the project directory in your terminal.
3.  Run `dotnet run`.
4.  Access the API endpoint at `https://localhost:{port}/operationids` (the port number will be displayed in the console).

## Expected Output

The console logs will show the different `OperationID` values for each service, demonstrating the different lifetimes.  By observing the changes in the OperationIDs across requests, you'll see how Transient, Scoped, and Singleton services behave.

## Benefits of Dependency Injection

*   **Improved Testability:**  Dependencies can be easily mocked or stubbed during testing.
*   **Increased Reusability:**  Components become more independent and can be reused in different contexts.
*   **Loose Coupling:** Reduces dependencies between classes, making the code more flexible and easier to maintain.
*   **Better Code Organization:** Promotes a more modular and structured codebase.

This example provides a clear illustration of how Dependency Injection works in .NET API and highlights the importance of understanding service lifetimes.  By using DI effectively, you can build more robust and maintainable applications.
