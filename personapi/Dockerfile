# Usa la imagen base de ASP.NET para la fase de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Usa la imagen del SDK de .NET para la fase de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY ["personapi/personapi.csproj", "personapi/"]
RUN dotnet restore "personapi/personapi.csproj"

# Copia el resto del código fuente y compílalo
COPY . .
WORKDIR "/src/personapi"
RUN dotnet build "personapi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica el proyecto en la carpeta /app/publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "personapi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usa la imagen base de ASP.NET para la fase final de ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Configuración del entorno para que la aplicación escuche en el puerto 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

# Comando para iniciar la aplicación
ENTRYPOINT ["dotnet", "personapi.dll"]