# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BarberTech.Api/BarberTech.Api.csproj", "BarberTech.Api/"]
COPY ["BarberTech.Application/BarberTech.Application.csproj", "BarberTech.Application/"]
COPY ["BarberTech.Infrastructure/BarberTech.Infrastructure.csproj", "BarberTech.Infrastructure/"]
COPY ["BarberTech.Domain/BarberTech.Domain.csproj", "BarberTech.Domain/"]

RUN dotnet restore "BarberTech.Api/BarberTech.Api.csproj"
COPY . .
WORKDIR "/src/BarberTech.Api"
RUN dotnet build "BarberTech.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BarberTech.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BarberTech.Api.dll"]