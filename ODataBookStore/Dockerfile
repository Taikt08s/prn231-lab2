# Use the ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080  # Expose port for the BookStore API

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["ODataBookStore/ODataBookStore.csproj", "ODataBookStore/"]
RUN dotnet restore "./ODataBookStore/ODataBookStore.csproj"

# Copy all files and build the application
COPY . .
WORKDIR "/src/ODataBookStore"
RUN dotnet build "./ODataBookStore.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "./ODataBookStore.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ODataBookStore.dll"]
