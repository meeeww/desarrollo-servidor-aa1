#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the project files for all three projects
COPY ["BankApi/BankApi.csproj", "BankApi/"]
COPY ["BankApi.Data/BankApi.Data.csproj", "BankApi.Data/"]
COPY ["BankApi.Model/BankApi.Model.csproj", "BankApi.Model/"]

# Restore dependencies for all three projects
RUN dotnet restore "BankApi/BankApi.csproj"
RUN dotnet restore "BankApi.Data/BankApi.Data.csproj"
RUN dotnet restore "BankApi.Model/BankApi.Model.csproj"

# Copy the entire solution
COPY . .

# Set working directory to BankApi project
WORKDIR "/src/BankApi"

# Build and publish the BankApi project
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Set working directory to BankApi.Data project
WORKDIR "/src/BankApi.Data"

# Build and publish the BankApi.Data project
RUN dotnet build -c Release -o /app/build-data
RUN dotnet publish -c Release -o /app/publish-data /p:UseAppHost=false

# Set working directory to BankApi.Model project
WORKDIR "/src/BankApi.Model"

# Build and publish the BankApi.Model project
RUN dotnet build -c Release -o /app/build-model
RUN dotnet publish -c Release -o /app/publish-model /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published files from the build stage for all three projects
COPY --from=build /app/publish .
COPY --from=build /app/publish-data ./data
COPY --from=build /app/publish-model ./model

# Set the entry point for the application
ENTRYPOINT ["dotnet", "BankApi.dll"]
