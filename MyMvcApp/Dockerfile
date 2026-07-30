# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY MyMvcApp.csproj ./
RUN dotnet restore MyMvcApp.csproj

# Copy the rest of the app and publish
COPY . ./
RUN dotnet publish MyMvcApp.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Set environment variables for ASP.NET Core
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 80

ENTRYPOINT ["dotnet", "MyMvcApp.dll"]
