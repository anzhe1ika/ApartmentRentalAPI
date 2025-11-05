# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["ApartmentRentalAPI.sln", "./"]
COPY ["ApartmentRentalAPI/ApartmentRentalAPI.csproj", "ApartmentRentalAPI/"]
COPY ["ApartmentRental.BLL/ApartmentRental.BLL.csproj", "ApartmentRental.BLL/"]
COPY ["ApartmentRental.Common/ApartmentRental.Common.csproj", "ApartmentRental.Common/"]
COPY ["ApartmentRental.DAL/ApartmentRental.DAL.csproj", "ApartmentRental.DAL/"]

# Restore dependencies
RUN dotnet restore "ApartmentRentalAPI/ApartmentRentalAPI.csproj"

# Copy all source files
COPY . .

# Build the project
WORKDIR "/src/ApartmentRentalAPI"
RUN dotnet build "ApartmentRentalAPI.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "ApartmentRentalAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Expose ports
EXPOSE 8080
EXPOSE 8081

# Copy published files
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Run the application
ENTRYPOINT ["dotnet", "ApartmentRentalAPI.dll"]

