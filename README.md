# MojeAlza API

## Overview
MojeAlza API is a RESTful service providing access to product data. It allows users to retrieve product details, list all products with pagination, and update product descriptions.

## Technologies Used
- .NET Core (latest LTS version)
- C#
- Entity Framework Core
- MSSQL (LocalDB)
- NUnit (for unit testing)
- Swagger (for API documentation)

## Prerequisites
- Install [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- (Optional) Install [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) for a better development experience (code editing, debugging, etc.)

## Configuration

The **application** supports different **configurations** for data access:

- **Test** configuration is using a mock database for unit testing and local development without requiring a SQL database.
- **Debug** and *Release* configurations are using an SQL database as defined in the `ConnectionStrings` section of `appsettings.json`.

To configure the **SQL database connection**, update the `appsettings.json` file in the `Api` project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MojeAlzaDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

To configure the **application hosting**, you can customize the URL and port by modifying the `appsettings.json` file. The default configuration is `http://localhost:5001`.

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5001"  // Change the port here as needed
      }
    }
  }
}
```

## Running the Application

1. Clone the repository:
   ```sh
   git clone https://github.com/Jan-Spilka/MojeAlza.git
   ```
2. Set up the database:
   ```sh
   dotnet ef database update --project Api
   ```
   This step can be skipped if the Test configuration will be used (see point number 3).
3. Run the API:
   ```sh
   dotnet run --project Api
   ```
   
   You can also use Test configuration, to run project with mock database instead of a real SQL database.
   
   ```sh
   dotnet run --project Api --configuration Test
   ```

## Api Documentation

The application provides an interactive API documentation using **Swagger**. Swagger is automatically integrated into the project to make it easier to explore and test the API endpoints.

To access the API documentation, open your web browser and navigate to `http://localhost:5001/swagger` (or the appropriate URL/port you have configured).

Swagger UI will display all available API endpoints, their descriptions, and provide an interface to test requests directly from the browser.

## Running Unit Tests

The solution uses NUnit for unit testing. Unit tests are located in the Test project.

Run the tests:
From the root folder or the directory containing the test project, run:
   ```sh
   dotnet test
   ```

## API Endpoints

### Get all products
```
GET /api/v2/products?page={page}&pageSize={size}
```
Returns a paginated list of products.

### Get a product by ID
```
GET /api/products/{id}
```
Returns details of a single product.

### Update product description
```
PATCH /api/products/{id}
```
Allows updating the product description.