# STAGE 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy only the .csproj files first to restore dependencies (faster builds)
COPY ["Api/Api.csproj", "Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Domain/Domain.csproj", "Domain/"]

RUN dotnet restore "Api/Api.csproj"

# Now copy everything else and build
COPY . .
RUN dotnet build "Api/Api.csproj" -c Release -o /app/build

# STAGE 2: Publish the app
FROM build AS publish
RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish

# STAGE 3: Final "Slim" Image (The "Shipping Container")
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]