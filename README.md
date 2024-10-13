# PersonAPI-DotNet

## Descripción

**PersonAPI-DotNet** es una API RESTful desarrollada en ASP.NET Core que implementa el patrón MVC (Modelo-Vista-Controlador) y el patrón DAO (Objeto de Acceso a Datos). Esta API gestiona entidades relacionadas con **personas**, **profesiones**, **estudios** y **teléfonos**, utilizando una base de datos SQL Server.

## Características

- **CRUD completo** para las entidades: Persona, Profesión, Estudio, Teléfono.
- **Entity Framework Core** para acceso a la base de datos.
- **ASP.NET Core** para la lógica de la aplicación.
- **Swagger** para la documentación interactiva de la API.
- Diseño basado en **patrones de arquitectura** como MVC y DAO.

## Tecnologías

- .NET 7
- ASP.NET Core
- Entity Framework Core
- SQL Server 2022
- Swagger 3

## Requisitos previos

Para ejecutar este proyecto en tu máquina local, necesitarás tener instalados los siguientes componentes:

- **.NET 7 SDK**
- **SQL Server 2019 Express o superior**
- **SQL Server Management Studio (SSMS)**
- **Visual Studio 2022** con los siguientes complementos:
  - Desarrollo de ASP.NET y web
  - Almacenamiento y procesamiento de datos
  - Plantillas de proyecto y elementos de .NET Framework
  - Características avanzadas de ASP.NET
- **Postman** (para probar los endpoints de la API)

## Instalación y configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu_usuario/personapi-dotnet.git
cd personapi-dotnet
```

### 2. Configurar la base de datos
Asegúrate de que SQL Server esté ejecutándose en tu máquina local.
Abre SQL Server Management Studio (SSMS).
Crea la base de datos ejecutando el siguiente comando SQL:
```bash
CREATE DATABASE persona_db;
```
Asegúrate de que el usuario sa tenga los permisos necesarios en la base de datos persona_db.
Crea las tablas ejecutando el SQL correspondiente al modelo que se encuentra en la carpeta Scripts (si lo tienes exportado) o usa el scaffolding para crear las entidades.

### 3. Configuración de la cadena de conexión
En el archivo appsettings.json, actualiza la cadena de conexión para que apunte a tu servidor local de SQL Server:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=persona_db;Trusted_Connection=True;TrustServerCertificate=true"
}
```
### 5. Ejecutar el proyecto
Abre el proyecto en Visual Studio 2022.
Ejecuta el proyecto presionando Ctrl+F5 o el botón de Ejecutar en Visual Studio.
La API debería estar disponible en http://localhost:5000.
### 6. Probar la API con Swagger
Swagger está habilitado para documentar y probar la API. Una vez que la aplicación esté ejecutándose, navega a:
```bash
http://localhost:5000/swagger/index.html
```
Aquí podrás ver la documentación de la API y probar los diferentes endpoints.

#### Endpoints disponibles
##### Personas
- GET /api/persona - Obtiene todas las personas.
- GET /api/persona/{cc} - Obtiene una persona por cédula.
- POST /api/persona - Crea una nueva persona.
- PUT /api/persona/{cc} - Actualiza una persona.
- DELETE /api/persona/{cc} - Elimina una persona.
##### Profesiones
- GET /api/profesion - Obtiene todas las profesiones.
- GET /api/profesion/{id} - Obtiene una profesión por ID.
- POST /api/profesion - Crea una nueva profesión.
- PUT /api/profesion/{id} - Actualiza una profesión.
- DELETE /api/profesion/{id} - Elimina una profesión.
##### Estudios
- GET /api/estudios - Obtiene todos los estudios.
- GET /api/estudios/{id_prof}/{cc_per} - Obtiene un estudio por profesión y persona.
- POST /api/estudios - Crea un nuevo estudio.
- PUT /api/estudios/{id_prof}/{cc_per} - Actualiza un estudio.
- DELETE /api/estudios/{id_prof}/{cc_per} - Elimina un estudio.
##### Teléfonos
- GET /api/telefono - Obtiene todos los teléfonos.
- GET /api/telefono/{num} - Obtiene un teléfono por número.
- POST /api/telefono - Crea un nuevo teléfono.
- PUT /api/telefono/{num} - Actualiza un teléfono.
- DELETE /api/telefono/{num} - Elimina un teléfono.
#### Pruebas de la API
Puedes probar los endpoints utilizando Postman o Swagger.

Ejemplo de una solicitud POST para crear una persona en Postman:
Método: POST
URL: http://localhost:5000/api/persona
```bash
Cuerpo (Body):
{
    "cc": 12345678,
    "nombre": "Juan",
    "apellido": "Pérez",
    "genero": "M",
    "edad": 30
}
```
Ejemplo de una solicitud DELETE para eliminar un teléfono:
Método: DELETE
URL: http://localhost:5000/api/telefono/{num}
Reemplaza {num} con el número del teléfono que deseas eliminar.
