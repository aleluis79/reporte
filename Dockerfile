FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV TZ America/Argentina/Buenos_Aires

ARG ENVIRONMENT=Development
ENV ENVIRONMENT=${ENVIRONMENT}
ENV ASPNETCORE_ENVIRONMENT=${ENVIRONMENT}
ENV ASPNETCORE_URLS http://+:5000

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "reporte.dll"]
