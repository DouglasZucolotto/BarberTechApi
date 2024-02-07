# Use a imagem base do SDK do .NET para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY ../BarberTech.Api/*.csproj ./
RUN dotnet restore

COPY ../BarberTech.Api/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "BarberTech.dll"]