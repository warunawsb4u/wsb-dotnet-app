# .NET 8 Build, Test & Deploy to Azure with GitHub Actions

This directory contains a complete, beginner-friendly .NET 8 "Hello World" minimal Web API with unit tests and a production-grade GitHub Actions CI/CD pipeline.

---

## 📁 Project Structure

```text
├── .github/
│   └── workflows/
│       └── dotnet-azure-deploy.yml   # The GitHub Actions CI/CD pipeline
├── .gitignore                        # Standard .NET gitignore
├── MyHelloWorldApp.sln               # Visual Studio / .NET Solution
├── README.md                         # Project documentation
├── src/
│   └── MyHelloWorldApp/
│       ├── MyHelloWorldApp.csproj    # Web project config (.NET 8)
│       └── Program.cs                # Hello World minimal API endpoints
└── tests/
    └── MyHelloWorldApp.Tests/
        ├── MyHelloWorldApp.Tests.csproj # xUnit test project config
        └── UnitTest1.cs              # Automated test cases
```

---

## 🚀 How the Pipeline Works

The workflow is split into two distinct jobs:

```
[ Push to main / Manual Dispatch ]
                 │
                 ▼
     ┌───────────────────────┐
     │  Job 1: Build & Test  │
     │  - Setup .NET 8 SDK   │
     │  - dotnet restore     │
     │  - dotnet build       │
     │  - dotnet test        │
     │  - dotnet publish     │
     │  - Upload Artifact    │
     └───────────┬───────────┘
                 │ (Only if all tests PASS)
                 ▼
     ┌───────────────────────┐
     │     Job 2: Deploy     │
     │  - Download Artifact  │
     │  - Deploy to Azure    │
     │    App Service        │
     └───────────────────────┘
```

1. **`build-and-test`**: Compiles code, runs unit tests, produces release binaries, and uploads the bundle as a temporary artifact.
2. **`deploy`**: Depends on `build-and-test`. If any test fails, deployment is automatically cancelled. It downloads the bundle and pushes it to Azure Web App.

---

## ☁️ Step-by-Step Azure Setup Guide

### Step 1: Create an Azure Web App (Free or Basic tier)
1. Log in to the [Azure Portal](https://portal.azure.com/).
2. In the search bar at the top, type **App Services** and click on it.
3. Click **+ Create** -> **Web App**.
4. Fill in the basics:
   - **Subscription**: Select your subscription.
   - **Resource Group**: Create new (e.g. `rg-dotnet-demo`).
   - **Name**: Choose a unique name (e.g. `my-dotnet-hello-123`). *This will be your `AZURE_WEBAPP_NAME`*.
   - **Publish**: `Code`
   - **Runtime stack**: `.NET 8 (LTS)`
   - **Operating System**: `Linux` (or `Windows`)
   - **Pricing Plan**: `Free F1` or `Basic B1`.
5. Click **Review + Create**, then **Create**.

---

### Step 2: Download the Publish Profile
1. Once deployment finishes, go to your new Web App resource in Azure Portal.
2. In the top toolbar of the **Overview** page, click **Get publish profile** (or **Manage publish profile**).
3. A `.PublishSettings` file (XML format) will download to your computer.
4. Open this file in any text editor and copy all of its contents.

---

### Step 3: Add Secret to Your GitHub Repository
1. On GitHub, navigate to your repository.
2. Click **Settings** -> **Secrets and variables** -> **Actions**.
3. Under **Repository secrets**, click **New repository secret**.
4. Enter:
   - **Name**: `AZURE_WEBAPP_PUBLISH_PROFILE`
   - **Secret**: Paste the XML content copied from the publish settings file.
5. Click **Add secret**.

---

### Step 4: Update the App Name in the Workflow
Open [`.github/workflows/dotnet-azure-deploy.yml`](.github/workflows/dotnet-azure-deploy.yml) and update line 12:
```yaml
env:
  AZURE_WEBAPP_NAME: 'my-dotnet-hello-123' # Put your exact Azure Web App name here
```

---

### Step 5: Test the Workflow
1. Commit and push changes to `main`:
   ```bash
   git add .
   git commit -m "feat: setup .NET hello world with Azure deployment"
   git push origin main
   ```
2. In GitHub, go to the **Actions** tab.
3. You will see **Build, Test, and Deploy .NET App to Azure** running.
4. Once completed, visit `https://<your-app-name>.azurewebsites.net/` to see your live API response:
   ```json
   {
     "message": "Hello World from .NET running on Azure App Service!",
     "status": "Healthy",
     "timestamp": "2026-09-28T05:22:24.0000000Z"
   }
   ```
