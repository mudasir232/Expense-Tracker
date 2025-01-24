# 💰 WalletWise - Expense Tracker Web App 🚀

![WalletWise Banner](https://via.placeholder.com/1200x400.png?text=WalletWise+-+Smart+Expense+Tracking+Made+Easy)

A powerful expense tracking web application built with ASP.NET Core MVC and Syncfusion components that helps you manage your finances like a pro! 💸📊

## 🌟 Features

- 🧾 Create custom expense/income categories
- 💰 Record transactions with amounts and descriptions
- 📈 Visualize spending patterns with Syncfusion charts
- 📅 Date-filtered transaction history
- 🏷️ Category-based financial insights
- 🔐 Secure user authentication
- 📱 Responsive mobile-friendly design
- 🎨 Modern UI with Syncfusion components

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core MVC
- **Frontend**: Razor Pages, Syncfusion UI Components
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Charting**: Syncfusion Charts
- **Styling**: Bootstrap 5 + Custom CSS

## ⚙️ Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or VS Code
- [Syncfusion License Key](https://www.syncfusion.com/account/downloads)

## 🚀 Installation Guide

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/WalletWise.git
cd WalletWise




2. Database Setup 🗄️
Update connection string in appsettings.json:

json
Copy
"ConnectionStrings": {
  "DefaultConnection": "Your_SQL_Server_Connection_String"
}
Run EF Core migrations:

bash
Copy
dotnet ef database update
3. Syncfusion Configuration 🔑
Get your free license key from Syncfusion

Add license key in Program.cs:

csharp
Copy
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR_LICENSE_KEY");
4. Run the Application 🖥️
bash
Copy
dotnet run
Visit https://localhost:5001 in your browser




🎮 Usage
Create Categories 🏷️

Navigate to Categories section

Add custom categories (e.g., "Groceries", "Salary")

Record Transactions 💸

Click "Add Transaction"

Select category, amount, and type (Income/Expense)

Analyze Finances 📊

View interactive charts

Filter by date ranges

Export reports

🤝 Contributing
We welcome contributions! Please follow these steps:

Fork the project

Create your feature branch (git checkout -b feature/AmazingFeature)

Commit your changes (git commit -m 'Add some AmazingFeature')

Push to the branch (git push origin feature/AmazingFeature)

Open a Pull Request

📄 License
Distributed under the MIT License. See LICENSE for more information.
```
