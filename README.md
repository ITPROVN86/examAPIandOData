# Product Management System

This is a Product Management System built using ASP.NET Core Web API. The system provides functionalities for managing products, including CRUD operations, and integrates with OData for flexible querying. The solution consists of multiple layers for data access, business logic, and presentation.

## Project Structure

- **BusinessObjects**: Contains the core business objects and models used throughout the application.
- **DataAccess**: Manages database context and entities. Implements data access logic using Entity Framework.
- **ProductManagementAPI**: ASP.NET Core Web API project that exposes endpoints for managing products. This is the main API layer of the system.
- **ProductManagementWebClient**: A web client that interacts with the ProductManagementAPI to display and manage products. Could be a frontend web application.
- **ProductOData**: Contains OData configuration for flexible querying of product data.
- **Repositories**: Defines and implements repository patterns for data access, helping to isolate business logic from data access logic.
- **Services**: Contains business logic and service implementations that work with repositories to execute CRUD operations and other business-related functions.
- **ShopDTO**: Contains Data Transfer Objects (DTOs) for the product data, used to separate data presentation from the internal models.
- **Lab01_ASP.NETCoreWebAPI.sln**: The solution file that contains all the projects.
