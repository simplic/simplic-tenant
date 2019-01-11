del *.nupkg
nuget pack Simplic.Studio.Tenant.UI.csproj -properties Configuration=Debug
nuget push *.nupkg -Source http://simplic.biz:10380/nuget