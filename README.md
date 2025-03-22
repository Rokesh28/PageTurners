# 📚 PageTurners - E-Commerce Web Application

PageTurners is a full-stack e-commerce web app designed for a smooth and secure book shopping experience. Built using **ASP.NET Core MVC (.NET 8)** and hosted on **Azure**, it integrates modern tools like **Stripe** for payments, **SendGrid** for emails, and **Entity Framework** for database operations.

---

## 🚀 Live Demo

🟢 [Try PageTurners Live](https://pageturners.azurewebsites.net/)  
⚠️ *Note: The Azure App Service is hosted on a free tier. If the app appears idle, please refresh it **2–3 times** at 5–10 second intervals — it just needs a little nudge to wake up from its nap!* 😴

---

## 🔧 Tech Stack

- **Frontend:** ASP.NET Core MVC, Razor Pages, Bootstrap v5
- **Backend:** .NET 8, Entity Framework Core
- **Database:** Microsoft SQL Server (deployed via Azure SQL Database for production)
- **Payments:** Stripe Integration
- **Email:** SendGrid (Order Confirmation Emails)
- **Hosting:** Azure Web Apps

---

## 🧱 Key Features

- 🛒 User registration/login with **Identity Framework**
- 🧾 Full shopping experience: **Products, Cart, Orders, Checkout**
- 💳 **Stripe Payment Gateway** integration
- 📧 Email confirmation via **SendGrid**
- 👑 Admin panel: CRUD operations, order management, role-based access
- 📦 Built using a **Layered Architecture**:
  - `PageTurners.Models` – Data models
  - `PageTurners.DataAccess` – Repositories, DbInitializer, Migrations
  - `PageTurners.Utility` – Constants & helper classes
  - `PageTurners` – MVC logic (Controllers, Views)

---


## 🧪 How to Run Locally

1. Clone the repository  
2. Set up your local SQL Server instance  
3. Configure connection string in `appsettings.json`  
4. Run `update-database` in Package Manager Console  
5. Build & run the app!

---

## 📫 Contact

Feel free to reach out with questions or suggestions:  
🔗 [rokesh28.github.io](https://rokesh28.github.io)  
💼 [LinkedIn](https://linkedin.com/in/rokeshprakash)

---

> Built with ❤️ and Entity Framework by [Rokesh Prakash](https://github.com/Rokesh28)


