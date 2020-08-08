FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /source
COPY . .

RUN dotnet publish Shop.sln \ --output /app/ --configuration Debug

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

CMD dotnet StudentSystem.API

EXPOSE 80