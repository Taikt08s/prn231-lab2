# Use the ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081  # Expose port for the WebClient

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["ODataBookStoreWebClient/ODataBookStoreWebClient.csproj", "ODataBookStoreWebClient/"]
COPY ["ODataBookStore/ODataBookStore.csproj", "ODataBookStore/"]
RUN dotnet restore "./ODataBookStoreWebClient/ODataBookStoreWebClient.csproj"

# Copy all files and build the application
COPY . .
WORKDIR "/src/ODataBookStoreWebClient"
RUN dotnet build "./ODataBookStoreWebClient.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "./ODataBookStoreWebClient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ODataBookStoreWebClient.dll"]
