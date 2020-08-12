FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /source
COPY . .

RUN dotnet publish StudentSystem.WebAPI.sln --output /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=builder /app .

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80
CMD dotnet StudentSystem.WebAPI.dll

EXPOSE 80
