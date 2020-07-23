FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /sln

# Restore solution
COPY ./CloudTrader.Mines.sln ./
COPY ./src/CloudTrader.Mines.Api/CloudTrader.Mines.Api.csproj  ./src/CloudTrader.Mines.Api/CloudTrader.Mines.Api.csproj
COPY ./src/CloudTrader.Mines.Data/CloudTrader.Mines.Data.csproj  ./src/CloudTrader.Mines.Data/CloudTrader.Mines.Data.csproj
COPY ./src/CloudTrader.Mines.Models/CloudTrader.Mines.Models.csproj  ./src/CloudTrader.Mines.Models/CloudTrader.Mines.Models.csproj
COPY ./src/CloudTrader.Mines.Service/CloudTrader.Mines.Service.csproj  ./src/CloudTrader.Mines.Service/CloudTrader.Mines.Service.csproj

COPY ./test/CloudTrader.Mines.Models.Tests/CloudTrader.Mines.Models.Tests.csproj ./test/CloudTrader.Mines.Models.Tests/CloudTrader.Mines.Models.Tests.csproj
COPY ./test/CloudTrader.Mines.Service.Tests/CloudTrader.Mines.Service.Tests.csproj ./test/CloudTrader.Mines.Service.Tests/CloudTrader.Mines.Service.Tests.csproj

RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /sln
COPY --from=build-env /sln/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "CloudTrader.Mines.Api.dll"]
