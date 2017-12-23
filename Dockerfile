# Build runtime image, set global variable for heroku's port
#FROM microsoft/aspnetcore-build:2.0 AS build-env
#WORKDIR /app

#COPY */*.csproj ./
#RUN dotnet restore IMuaythai.Api.csproj

#COPY . ./
#RUN dotnet publish -c Release -o out
#FROM microsoft/aspnetcore:2.0

#FROM microsoft/aspnetcore:2.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "IMuaythai.Api.dll"]

#CMD ASPNETCORE_URLS=http://*:$PORT dotnet IMuaythai.Api.dll
FROM microsoft/aspnetcore-build:2.0 AS build-env

COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]

ENTRYPOINT ["dotnet", "/app/IMuaythai.Api/bin/Release/netcoreapp2.0/MuaythaiSportManagementSystemApi.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet "/app/IMuaythai.Api/bin/Release/netcoreapp2.0/MuaythaiSportManagementSystemApi.dll"