# GitHub Actions Workflow Documentation

## Overview

The `main_math-lib.yml` workflow provides comprehensive CI/CD for the MathLib project with the following capabilities:

- **Continuous Integration**: Automated testing and building
- **Package Publishing**: Automatic NuGet package creation and publishing to GitHub Packages
- **Azure Deployment**: Automated deployment to Azure Web App
- **Multi-trigger Support**: Responds to different events with appropriate actions

## Workflow Jobs

### 1. Test Job (`test`)
- **Platform**: Ubuntu (for speed and cost efficiency)
- **Purpose**: Run unit tests with code coverage
- **Triggers**: All pushes and pull requests
- **Steps**:
  - Checkout code
  - Setup .NET 8.x
  - Restore dependencies  
  - Build in Release mode
  - Run tests with coverage collection
  - Upload test results as artifacts

### 2. Build Job (`build`)
- **Platform**: Windows (required for Azure deployment)
- **Purpose**: Build and prepare application for deployment
- **Dependencies**: Requires `test` job to succeed
- **Triggers**: All pushes and pull requests
- **Steps**:
  - Checkout code
  - Setup .NET 8.x
  - Build in Release mode
  - Publish application
  - Upload build artifacts

### 3. Package Job (`package`)
- **Platform**: Ubuntu (for package creation)
- **Purpose**: Create and publish NuGet packages
- **Dependencies**: Requires `test` job to succeed
- **Triggers**: Only on pushes to `main` branch or version tags
- **Conditional**: Only runs for main branch pushes or version tags
- **Features**:
  - Smart version detection (tag-based or preview)
  - GitHub Packages authentication
  - Automatic package upload
  - Symbols package (.snupkg) generation

### 4. Deploy Job (`deploy`)
- **Platform**: Windows (Azure requirements)
- **Purpose**: Deploy to Azure Web App
- **Dependencies**: Requires both `build` and `package` jobs
- **Triggers**: Only on pushes to `main` branch
- **Environment**: Uses `production` environment for protection
- **Security**: Uses Azure publish profile from secrets

## Trigger Events

### Push to Main Branch
```yaml
on:
  push:
    branches: [main]
```
- Runs all jobs: test → build/package → deploy
- Creates preview NuGet packages
- Deploys to Azure production environment

### Version Tags
```yaml
on:
  push:
    tags: ['v*.*.*']
```
- Runs all jobs: test → build/package → deploy
- Creates release NuGet packages with tag version
- Publishes to GitHub Packages with official version

### Pull Requests
```yaml
on:
  pull_request:
    branches: [main]
```
- Runs only test and build jobs
- No deployment or package publishing
- Provides PR validation

### Manual Dispatch
```yaml
on:
  workflow_dispatch:
```
- Allows manual workflow execution
- Runs all jobs based on current branch/context

## Package Versioning Strategy

### Release Versions (Tags)
- **Format**: `v1.2.3` (semantic versioning)
- **Package Version**: `1.2.3`
- **Trigger**: Push to tag matching `v*.*.*`
- **Usage**: Production releases

### Preview Versions (Main Branch)
- **Format**: `1.0.0-preview.YYYYMMDDHHMMSS`
- **Package Version**: Includes timestamp for uniqueness
- **Trigger**: Push to main branch (not tags)
- **Usage**: Development/testing releases

## GitHub Packages Configuration

### Authentication
The workflow automatically configures GitHub Packages using:
- **Source**: `https://nuget.pkg.github.com/{owner}/index.json`
- **Username**: Repository owner
- **Token**: `GITHUB_TOKEN` (automatically provided)

### Package Features
- **Symbols**: Includes .snupkg for debugging
- **README**: Includes project README in package
- **Metadata**: Comprehensive package information
- **License**: MIT license included

## Required Secrets

### Azure Deployment
- `AZUREAPPSERVICE_PUBLISHPROFILE_*`: Azure Web App publish profile

### GitHub Packages
- `GITHUB_TOKEN`: Automatically provided by GitHub Actions (no setup required)

## Package Installation

### For Consumers
```bash
# Configure GitHub Packages source
dotnet nuget add source https://nuget.pkg.github.com/OWNER/index.json \\
  --name "github" \\
  --username "OWNER" \\
  --password "YOUR_TOKEN"

# Install the package
dotnet add package MathLib
```

### Helper Scripts
Use the provided setup scripts:
- **Windows**: `scripts/setup-github-packages.bat`
- **Linux/Mac**: `scripts/setup-github-packages.sh`

## Workflow Security

### Permissions
- **contents: read**: For repository checkout
- **packages: write**: For GitHub Packages publishing
- **Environment protection**: Production environment for deployment

### Best Practices
- Secrets are never exposed in logs
- Tokens have minimal required permissions
- Environment-based deployment protection
- Conditional job execution prevents unnecessary runs

## Troubleshooting

### Common Issues

#### Package Authentication
- Ensure GitHub token has `packages:read` scope
- Verify repository name in source URL
- Check username matches GitHub account

#### Build Failures
- Check .NET version compatibility
- Verify project references
- Review build warnings that might cause issues

#### Deployment Issues
- Validate Azure publish profile
- Check Azure Web App configuration
- Verify environment protection rules

### Monitoring
- Check the Actions tab for workflow runs
- Review job logs for detailed information
- Monitor package publishing in repository Packages tab
- Verify deployments in Azure portal

## Customization

### Adding New Jobs
Add jobs to the workflow by following the existing pattern:
```yaml
new-job:
  runs-on: ubuntu-latest
  needs: [test]  # Dependencies
  if: condition  # Conditional execution
  steps:
    # Job steps
```

### Modifying Triggers
Update the `on:` section to change trigger behavior:
```yaml
on:
  push:
    branches: [main, develop]  # Multiple branches
    paths: ['src/**']          # Path-based filtering
```

### Environment Variables
Add environment variables for configuration:
```yaml
env:
  DOTNET_VERSION: '8.x'
  BUILD_CONFIGURATION: 'Release'
```

This workflow provides a production-ready CI/CD pipeline with comprehensive testing, packaging, and deployment capabilities for the MathLib project.
