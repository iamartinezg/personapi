# Usar la imagen base de .NET SDK para compilar la aplicaci贸n
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar el archivo de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de la aplicaci贸n y compilarla
COPY . .
RUN dotnet publish -c Release -o out

# Usar la imagen base de .NET runtime para ejecutar la aplicaci贸n
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto por defecto del contenedor
EXPOSE 80

# Comando para ejecutar la aplicaci贸n
ENTRYPOINT ["dotnet", "personapi-dotnet.dll"]