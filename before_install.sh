wget -q https://packages.microsoft.com/config/ubuntu/14.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-hosting-2.0.9