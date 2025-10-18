# Play.Common
Common libraries used by my Microservice .

## Create and publish package
```powershell
$version="1.1.8"
$owner="dotnetmicroserviceproject"

dotnet pack src\common\ --configuration Release -p:PackageVersion=$version -p:RepositoryUrl=https://github.com/$owner/common -o ..\packages

```