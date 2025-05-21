# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY TANA.API/*.csproj ./TANA.API/
COPY TANA.Application/*.csproj ./TANA.Application/
COPY TANA.Domain/*.csproj ./TANA.Domain/
COPY TANA.Infrastructure/*.csproj ./TANA.Infrastructure/
COPY TANA.Persistence/*.csproj ./TANA.Persistence/
COPY TANA.Web/*.csproj ./TANA.Web/

RUN dotnet restore ./TANA.API/TANA.API.csproj

# Copy full source
COPY TANA.API/ ./TANA.API/
COPY TANA.Web/ ./TANA.Web/
COPY TANA.Application/ ./TANA.Application/
COPY TANA.Domain/ ./TANA.Domain/
COPY TANA.Infrastructure/ ./TANA.Infrastructure/
COPY TANA.Persistence/ ./TANA.Persistence/

# Build
RUN dotnet build ./TANA.API/TANA.API.csproj -c Release -o /build

# Copy everything and publish
RUN dotnet publish ./TANA.API/TANA.API.csproj -c Release -o /out

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
        libfontconfig1 \
        libfreetype6 \
        libharfbuzz0b \
        libpng16-16 \
        libx11-6 && \
    rm -rf /var/lib/apt/lists/*
COPY --from=build /out .

# Expose port 80 for the API
EXPOSE 80

ENTRYPOINT ["dotnet", "TANA.API.dll"]
