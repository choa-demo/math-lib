@echo off
REM GitHub Packages Setup Script for MathLib (Windows)
REM This script helps configure your environment to install MathLib from GitHub Packages

echo 🔧 Setting up GitHub Packages for MathLib
echo.

REM Check if .NET is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ .NET is not installed. Please install .NET 8.0 or later.
    pause
    exit /b 1
)

for /f "tokens=*" %%i in ('dotnet --version') do set DOTNET_VERSION=%%i
echo ✅ .NET is installed: %DOTNET_VERSION%

REM Prompt for GitHub username
set /p GITHUB_USERNAME=📝 Enter your GitHub username: 

REM Prompt for GitHub Personal Access Token
echo 📝 Enter your GitHub Personal Access Token (with packages:read scope):
echo    You can create one at: https://github.com/settings/tokens
set /p GITHUB_TOKEN=Token: 

if "%GITHUB_USERNAME%"=="" (
    echo ❌ Username is required
    pause
    exit /b 1
)

if "%GITHUB_TOKEN%"=="" (
    echo ❌ Token is required
    pause
    exit /b 1
)

REM Add GitHub Packages source
echo.
echo 🔧 Configuring NuGet source for GitHub Packages...

dotnet nuget add source "https://nuget.pkg.github.com/%GITHUB_USERNAME%/index.json" --name "github" --username "%GITHUB_USERNAME%" --password "%GITHUB_TOKEN%" --store-password-in-clear-text

if %errorlevel% equ 0 (
    echo ✅ GitHub Packages source configured successfully!
    echo.
    echo 📦 You can now install MathLib with:
    echo    dotnet add package MathLib
    echo.
    echo 🔍 To verify available versions:
    echo    dotnet list package --include-prerelease --source github
) else (
    echo ❌ Failed to configure GitHub Packages source
    pause
    exit /b 1
)

echo.
echo 🎉 Setup complete! You're ready to use MathLib from GitHub Packages.
pause
