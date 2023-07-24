#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["gamesManagement.API/gamesManagement.API.csproj", "gamesManagement.API/"]
COPY ["gamesManagement.Application/gamesManagement.Application.csproj", "gamesManagement.Application/"]
COPY ["gamesManagement.Domain/gamesManagement.Domain.csproj", "gamesManagement.Domain/"]
COPY ["gamesManagement.Infrastructure/gamesManagement.Infrastructure.csproj", "gamesManagement.Infrastructure/"]
RUN dotnet restore "gamesManagement.API/gamesManagement.API.csproj"
COPY . .
WORKDIR "/src/gamesManagement.API"
RUN dotnet build "gamesManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gamesManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gamesManagement.API.dll"]