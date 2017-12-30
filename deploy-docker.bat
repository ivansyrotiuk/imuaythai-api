dotnet publish -c Release
copy ./Docker ./IMuaythai.Api/bin/release/netcoreapp2.0/publish
docker build -t imuaythai-api ./IMuaythai.Api/bin/release/netcoreapp2.0/publish
docker tag imuaythai-api imuaythai
docker tag imuaythai-api:imuaythai  waserdx/imuaythai:imuaythai
docker push waserdx/imuaythai:imuaythai