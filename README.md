# Trivio
### Gives you trivial information
## Running
$docker pull dexton/trivio:latest
$docker run dexton/trivio
## Building
In the trivio folder
$docker build . -t trivio:latest
## Requirements
.Net Core SDK 3.1.9
## Running tests
$dotnet test
## Running on a local machine
$dotnet restore
$dotnet run