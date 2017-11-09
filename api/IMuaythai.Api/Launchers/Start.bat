dotnet IMuaythai.Api.dll local
dotnet ef database drop -f --no-build  
dotnet ef database update --no-build  
dotnet IMuaythai.Api.dll
start http://localhost:3000