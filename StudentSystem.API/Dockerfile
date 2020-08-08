FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /source
COPY . .

RUN dotnet publish StudentSystem.API.csproj --output /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=builder /app .
CMD dotnet StudentSystem.API.dll
