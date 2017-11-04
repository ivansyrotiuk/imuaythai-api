dotnet MuaythaiSportManagementSystemApi.dll local
dotnet ef database drop -f --no-build  
dotnet ef database update --no-build  
dotnet MuaythaiSportManagementSystemApi.dll
start http://localhost:3000