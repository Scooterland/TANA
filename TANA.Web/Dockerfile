# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only required .csproj files
COPY ["TANA.Web/TANA.Web.csproj", "TANA.Web/"]
COPY ["TANA.Application/TANA.Application.csproj", "TANA.Application/"]
COPY ["TANA.Domain/TANA.Domain.csproj", "TANA.Domain/"]
COPY ["TANA.Infrastructure/TANA.Infrastructure.csproj", "TANA.Infrastructure/"]
COPY ["TANA.Persistence/TANA.Persistence.csproj", "TANA.Persistence/"]

# Restore
RUN dotnet restore "TANA.Web/TANA.Web.csproj"

# Copy source (no TANA.API!)
COPY TANA.Web/ TANA.Web/
COPY TANA.Application/ TANA.Application/
COPY TANA.Domain/ TANA.Domain/
COPY TANA.Infrastructure/ TANA.Infrastructure/
COPY TANA.Persistence/ TANA.Persistence/

# Build
WORKDIR /src/TANA.Web
RUN dotnet build "TANA.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TANA.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TANA.Web.dll"]
