FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["GestionITM.API/GestionITM.API.csproj", "GestionITM.API/"]
COPY ["GestionITM.Infrastructure/GestionITM.Infrastructure.csproj", "GestionITM.Infrastructure/"]
COPY ["GestionITM.Domain/GestionITM.Domain.csproj", "GestionITM.Domain/"]
RUN dotnet restore "GestionITM.API/GestionITM.API.csproj"

COPY . .
WORKDIR "/src/GestionITM.API"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GestionITM.API.dll"]
