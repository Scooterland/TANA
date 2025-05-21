# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Install wkhtmltox dependencies and place the shared object into /usr/lib
FROM base AS wkhtmltox
RUN apt-get update && apt-get install -y \
    libxrender1 libfontconfig1 libxext6 libjpeg62-turbo libx11-6 wget && \
    rm -rf /var/lib/apt/lists/*
COPY TANA.Web/libwkhtmltox/libwkhtmltox.so /usr/lib/libwkhtmltox.so
RUN ln -s /usr/lib/libwkhtmltox.so /usr/lib/libwkhtmltox.so.0

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["TANA.Web/TANA.Web.csproj", "TANA.Web/"]
COPY ["TANA.Application/TANA.Application.csproj", "TANA.Application/"]
COPY ["TANA.Domain/TANA.Domain.csproj", "TANA.Domain/"]
COPY ["TANA.Infrastructure/TANA.Infrastructure.csproj", "TANA.Infrastructure/"]
COPY ["TANA.Persistence/TANA.Persistence.csproj", "TANA.Persistence/"]

RUN dotnet restore "TANA.Web/TANA.Web.csproj"

COPY TANA.Web/ TANA.Web/
COPY TANA.Application/ TANA.Application/
COPY TANA.Domain/ TANA.Domain/
COPY TANA.Infrastructure/ TANA.Infrastructure/
COPY TANA.Persistence/ TANA.Persistence/

WORKDIR /src/TANA.Web
RUN dotnet build "TANA.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TANA.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM wkhtmltox AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TANA.Web.dll"]
