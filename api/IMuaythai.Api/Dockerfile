# Build runtime image, set global variable for heroku's port
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IMuaythai.Api.dll
