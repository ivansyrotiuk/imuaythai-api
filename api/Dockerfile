FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj, nudget sources  and restore as distinct layers
COPY *.csproj ./
COPY NuGet.Config ./
RUN dotnet restore

# Copy everything else and build production version
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image, set global variable for heroku's port
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MuaythaiSportManagementSystemApi.dll