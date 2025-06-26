#!/bin/bash

# GitHub Packages Setup Script for MathLib
# This script helps configure your environment to install MathLib from GitHub Packages

echo "🔧 Setting up GitHub Packages for MathLib"
echo ""

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET is not installed. Please install .NET 8.0 or later."
    exit 1
fi

echo "✅ .NET is installed: $(dotnet --version)"

# Prompt for GitHub username
read -p "📝 Enter your GitHub username: " GITHUB_USERNAME

# Prompt for GitHub Personal Access Token
echo "📝 Enter your GitHub Personal Access Token (with packages:read scope):"
echo "   You can create one at: https://github.com/settings/tokens"
read -s GITHUB_TOKEN

if [ -z "$GITHUB_USERNAME" ] || [ -z "$GITHUB_TOKEN" ]; then
    echo "❌ Username and token are required"
    exit 1
fi

# Add GitHub Packages source
echo ""
echo "🔧 Configuring NuGet source for GitHub Packages..."

dotnet nuget add source \
    "https://nuget.pkg.github.com/$GITHUB_USERNAME/index.json" \
    --name "github" \
    --username "$GITHUB_USERNAME" \
    --password "$GITHUB_TOKEN" \
    --store-password-in-clear-text

if [ $? -eq 0 ]; then
    echo "✅ GitHub Packages source configured successfully!"
    echo ""
    echo "📦 You can now install MathLib with:"
    echo "   dotnet add package MathLib"
    echo ""
    echo "🔍 To verify available versions:"
    echo "   dotnet list package --include-prerelease --source github"
else
    echo "❌ Failed to configure GitHub Packages source"
    exit 1
fi

echo ""
echo "🎉 Setup complete! You're ready to use MathLib from GitHub Packages."
