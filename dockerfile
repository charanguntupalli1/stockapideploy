# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "dotnet-stocks-api.dll"]


# aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 739275458883.dkr.ecr.us-east-1.amazonaws.com
