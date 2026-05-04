To keep this accurate, I have based the setup steps on your **Clean Architecture** structure and the dependencies we've used (EF Core, JWT, Blazor WASM). 

Here is the **setup-guide.md**.

# Setup & Installation Guide

This guide provides the necessary steps to get the FinanceTracker development environment running locally.

---

## **Prerequisites**
* **.NET 10.0 SDK** (or newer)
* **SQL Server** (LocalDB or Express)
* **Visual Studio 2026** (or VS Code with C# Dev Kit)

---

## **1. Database Configuration**
The application uses **Entity Framework Core** with SQL Server. 

1.  Navigate to the **Api** project.
2.  Open `appsettings.json`.
3.  Update the `ConnectionStrings:DefaultConnection` to point to your local SQL instance.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FinanceTrackerDb;Trusted_Connection=True;"
    }
  ```

---

## **2. Apply Migrations**
Before running the app, you must create the database schema. Run the following command from the **Solution Root** using the terminal:

```bash
dotnet ef database update --project Infrastructure --startup-project Api
```
*Note: If you are using Visual Studio, you can use the Package Manager Console:*
`Update-Database -Project Infrastructure -StartupProject Api`

---

## **3. JWT Configuration**
The API requires JWT settings for authentication. Ensure your `appsettings.json` contains a valid configuration:

```json
"JwtSettings": {
  "Secret": "your-super-secret-key-at-least-32-characters-long",
  "Issuer": "FinanceTracker",
  "Audience": "FinanceTrackerUsers",
  "ExpiryMinutes": 60
}
```

---

## **4. Running the Application**

### **Option A: Visual Studio (Recommended)**
1.  Right-click the Solution -> **Configure Startup Projects...**
2.  Select **Multiple startup projects**.
3.  Set both **Api** and **UI** to **Start**.
4.  Press **F5**.

### **Option B: Command Line**
You will need two terminal windows:

**Terminal 1 (API):**
```bash
cd Api
dotnet run
```

**Terminal 2 (UI):**
```bash
cd UI
dotnet run
```

---

## **5. Verification**
1.  Once both projects are running, the Blazor UI will open (usually `localhost:7000` or similar).
2.  Navigate to the **Register** page to create your first user.
3.  Upon successful login, you will be redirected to the **Dashboard**.

---

## **Troubleshooting**
* **CORS Errors:** If the UI cannot talk to the API, verify the `appsettings.json` in the **Api** project has the correct `AllowedOrigins` for the UI URL.
* **401 Unauthorized:** Ensure the `Secret` in `appsettings.json` hasn't changed between sessions, as this will invalidate existing tokens.

---
*Last Updated: 2026-05-04*