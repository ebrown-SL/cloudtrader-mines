#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["src/CloudTrader.Mines.Api/CloudTrader.Mines.Api.csproj", "src/CloudTrader.Mines.Api/"]
COPY ["src/CloudTrader.Mines.Data/CloudTrader.Mines.Data.csproj", "src/CloudTrader.Mines.Data/"]
COPY ["src/CloudTrader.Mines.Service/CloudTrader.Mines.Service.csproj", "src/CloudTrader.Mines.Service/"]
RUN dotnet restore "src/CloudTrader.Mines.Api/CloudTrader.Mines.Api.csproj"
COPY . .
WORKDIR "/src/src/CloudTrader.Mines.Api"
RUN dotnet build "CloudTrader.Mines.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudTrader.Mines.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudTrader.Mines.Api.dll"]