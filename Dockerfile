FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ./BarberTech.Api/*.csproj ./BarberTech.Api/
RUN dotnet restore ./BarberTech.Api/BarberTech.Api.csproj

COPY ./BarberTech.Application/*.csproj ./BarberTech.Application/
RUN dotnet restore ./BarberTech.Application/BarberTech.Application.csproj

COPY ./BarberTech.Domain/*.csproj ./BarberTech.Domain/
RUN dotnet restore ./BarberTech.Domain/BarberTech.Domain.csproj

COPY ./BarberTech.Infraestructure/*.csproj ./BarberTech.Infraestructure/
RUN dotnet restore ./BarberTech.Infraestructure/BarberTech.Infraestructure.csproj

COPY . ./

RUN dotnet publish -c Release -o out/BarberTech.Api ./BarberTech.Api/BarberTech.Api.csproj
RUN dotnet publish -c Release -o out/BarberTech.Application ./BarberTech.Application/BarberTech.Application.csproj
RUN dotnet publish -c Release -o out/BarberTech.Domain ./BarberTech.Domain/BarberTech.Domain.csproj
RUN dotnet publish -c Release -o out/BarberTech.Infraestructure ./BarberTech.Infraestructure/BarberTech.Infraestructure.csproj

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out/BarberTech.Api ./
COPY --from=build /app/out/BarberTech.Application ./
COPY --from=build /app/out/BarberTech.Domain ./
COPY --from=build /app/out/BarberTech.Infraestructure ./
ENTRYPOINT ["dotnet", "app/BarberTech.Api/BarberTech.Api.dll"]

