# Etapa base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["AnimeHub.API/AnimeHub.API.csproj", "AnimeHub.API/"]
COPY ["AnimeHub.Application/AnimeHub.Application.csproj", "AnimeHub.Application/"]
COPY ["AnimeHub.CrossCuting/AnimeHub.CrossCuting.csproj", "AnimeHub.CrossCuting/"]
COPY ["AnimeHub.Domain/AnimeHub.Domain.csproj", "AnimeHub.Domain/"]
COPY ["AnimeHub.Infrastructure/AnimeHub.Infrastructure.csproj", "AnimeHub.Infrastructure/"]

RUN dotnet restore "AnimeHub.API/AnimeHub.API.csproj"

COPY . .

RUN dotnet build "AnimeHub.API/AnimeHub.API.csproj" -c Release -o /app/build


# Etapa de publicação
FROM build AS publish
WORKDIR "/src/AnimeHub.API"
RUN dotnet publish "AnimeHub.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final do runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnimeHub.API.dll"]
