wget -q https://packages.microsoft.com/config/ubuntu/14.04/packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
apt-get install apt-transport-https
apt-get update
apt-get install dotnet-hosting-2.0.9