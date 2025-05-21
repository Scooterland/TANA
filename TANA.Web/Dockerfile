# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY TANA.Web/*.csproj ./TANA.Web/
COPY TANA.Application/*.csproj ./TANA.Application/
COPY TANA.Domain/*.csproj ./TANA.Domain/
COPY TANA.Infrastructure/*.csproj ./TANA.Infrastructure/
COPY TANA.Persistence/*.csproj ./TANA.Persistence/

RUN dotnet restore ./TANA.Web/TANA.Web.csproj

# Copy all files and publish
COPY . .
WORKDIR /app/TANA.Web
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Expose port 80
EXPOSE 80

ENTRYPOINT ["dotnet", "TANA.Web.dll"]
