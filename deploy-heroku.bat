dotnet publish -c Release
copy ./Docker ./IMuaythai.Api/bin/release/netcoreapp2.0/publish
docker build -t imuaythai-api ./IMuaythai.Api/bin/release/netcoreapp2.0/publish
docker tag image-imuaythai-api registry.heroku.com/imuaythai-api/web
docker push registry.heroku.com/imuaythai-api/web