ProductAPI - API web de ASP.NET Core - Laura Testa
Api rest usando .net 8, para gestionar productos y categorias. Incluye Dto, Validaciones,AutoMapper y Swagger.

Tecnologías
.NET 8
SqlServer (Code First)
AutoMapper
En appsettings.json, ajusta la cadena de conexión.
Ejecuta los siguientes comandos:
# Restaurar paquetes
dotnet restore

# Aplicar migraciones (crear DB)
dotnet ef migrations add "Nombre de la Migracion"
dotnet ef database update

# Ejecutar la API
dotnet run
