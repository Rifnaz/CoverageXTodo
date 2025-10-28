# CoverageXTodo

CoverageXTodo is a simple task management app built using **ASP.NET Core + React(vite, typescript tailwindcss) + MSSQL**.  
It’s designed to show how to connect a .NET API with a React frontend using clean folder structure and reusable components. And Backend with N-tier architecture.

## Tech Stack

- **Frontend:** React (Vite) + TypeScript + Tailwind CSS
- **Backend:** ASP.NET Core Web API (.NET 9)
- **Database:** Microsoft SQL Server
- **Tesing:** XUnit
- **Architecture:** N-Tier (Presentation, API, Business Logic, Database Access Test)
- **ORM:** Entity Framework Core
- **Containerzation:** Docker

---

## Project Overview

- Add, Delete and Update Status of the tasks.
- Filter tasks by operational status (Pending / Completed).
- Display Rcently added 5 tasks and expandable to view all.
- Store and fetch the data from Microsoft Sql Server using EfF Core.
- Use a clean reusable UI made with React components.

---

## How It's built

1. **Backend (ASP.NET Core API)**
   - Created Seperate layers to manage each logics (WebAPI, ServiceLayer(Business Logics), DbLayer(Data Access), Test)
   - APIs are developed in Api Controllers
   - Created unit tests in Test project using Xunit
   - Connected to MSSQL using Entity framework core (Used LINQ to handle data)

2. **Frontend (React + Typescript)**
   - Created reusable components (`TaskCard`, `TaskForm`, `OsButton`, etc).
   - Used Axios libraries to call .NET Api
   - Used Tailwind css for UI looks.
  
3. **Integration**
   - Frontend, backend and databse runs on same Docker network.
   - Configured `Dockerfile` for API, and React project
   - Configured `docker-compose.yml` for one-line setup.

---

## Run the Project with a Single Command

Make sure you have **Docker Desktop** installed with **WSL(Windows Sub System for Linux)** then open your terminal inside the project folder and run:
```bash
docker compose up -d --build
```

**Steps**

1. Clone the Project from Github the Repository CoverageXTodo => https://github.com/Rifnaz/CoverageXTodo.git
2. Redirect to prject folder CoverageXTodo `cd CoverageXTodo`
3. Run the command `docker compose up -d --build` and wait for download all dependencies and start all 3 images
4. Open the browser and run http://localhost:3000/
5. That's all You can see **CoverageXTodo** App.

**Quick Access**
- **Redirect Folder:** `cd CoverageXTodo`
- **Access React App:** http://localhost:3000/
- **Access .NET API (Optional):** http://localhost:5000/
- **API Test (Optional):** Postman
- **Git Repository:** https://github.com/Rifnaz/CoverageXTodo.git

---


**Thanks for checking it out! 🙌**

**By Rifnaz**
