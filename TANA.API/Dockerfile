# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only csproj files first (for caching and faster builds)
COPY ["TANA.API/TANA.API.csproj", "TANA.API/"]
COPY ["TANA.Application/TANA.Application.csproj", "TANA.Application/"]
COPY ["TANA.Domain/TANA.Domain.csproj", "TANA.Domain/"]
COPY ["TANA.Infrastructure/TANA.Infrastructure.csproj", "TANA.Infrastructure/"]
COPY ["TANA.Persistence/TANA.Persistence.csproj", "TANA.Persistence/"]

RUN dotnet restore "TANA.API/TANA.API.csproj"

# Copy the source code for just the projects the API needs (not TANA.Web!)
COPY TANA.API/. ./TANA.API/
COPY TANA.Application/. ./TANA.Application/
COPY TANA.Domain/. ./TANA.Domain/
COPY TANA.Infrastructure/. ./TANA.Infrastructure/
COPY TANA.Persistence/. ./TANA.Persistence/

WORKDIR "/src/TANA.API"
RUN dotnet build "TANA.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TANA.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TANA.API.dll"]
