FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Konfiguracja tylko HTTP (bez HTTPS) - rozwiązanie problemu z certyfikatem
ENV ASPNETCORE_URLS="http://+:80"
ENV ASPNETCORE_ENVIRONMENT="Development"

# Wyłączenie przekierowania HTTPS i certyfikatów
ENV DOTNET_SYSTEM_CONSOLE_ALLOW_ANSI_COLOR_REDIRECTION=1
ENV COMPlus_EnableDiagnostics=0

# Ekspozycja portu HTTP
EXPOSE 80

ENTRYPOINT ["dotnet", "ProductsApi.dll"]