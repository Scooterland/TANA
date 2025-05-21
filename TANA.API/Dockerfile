# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY TANA.API/*.csproj ./TANA.API/
COPY Tana.Application/*.csproj ./TANA.Application/
COPY Tana.Domain/*.csproj ./TANA.Domain/
COPY TANA.Infrastructure/*.csproj ./TANA.Infrastructure/
COPY TANA.Persistence/*.csproj ./TANA.Persistence/

RUN dotnet restore ./TANA.API/TANA.API.csproj

# Copy everything and publish
COPY . .
WORKDIR /app/TANA.API
RUN dotnet publish -c Release -o /out

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
