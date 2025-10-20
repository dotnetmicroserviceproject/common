# Play.Common
Common libraries used by my Microservice .

## Create and publish package
```powershell
$version="1.1.9"
$owner="dotnetmicroserviceproject"
$gh_pat="[PAT HERE]"

dotnet pack src\common\ --configuration Release -p:PackageVersion=$version -p:RepositoryUrl=https://github.com/$owner/common -o ..\packages

dotnet nuget push ..\packages\common.$version.nupkg --api-key $gh_pat --source "github"

```