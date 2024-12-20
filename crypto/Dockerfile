FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["crypto.csproj", "."]
RUN dotnet restore "crypto.csproj"  
COPY . .
WORKDIR /src
RUN dotnet build "crypto.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "crypto.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/build .
ENTRYPOINT ["dotnet", "crypto.dll"]


# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# # Use root user directly instead of switching later
# USER root

# WORKDIR /app
# EXPOSE 8080
# EXPOSE 8081
# COPY . .

# RUN chmod -R 755 /app  # Ensure correct permissions

# RUN dotnet restore
# RUN dotnet build "crypto.csproj" -c Release -o /app/build

# FROM mcr.microsoft.com/dotnet/aspnet:8.0

# USER app

# WORKDIR /app
# COPY --from=build-env /app/build .
# ENTRYPOINT ["dotnet", "crypto.dll"]