# \# Jerarquía de Empleados — Frontend

# 

# Aplicación web en ASP.NET Core MVC (.NET 8) que consume la API REST del backend para mostrar el árbol de jerarquía de empleados y gestionar operaciones CRUD.

# 

# \## Tecnologías

# 

# \- .NET 8 / ASP.NET Core MVC

# \- Bootstrap

# \- HttpClientFactory para consumo de API REST

# 

# \## Requisitos previos

# 

# \- .NET 8 SDK

# \- El proyecto Backend corriendo (repositorio: https://github.com/ICEZACK1028/arbol-jerarquia-api/tree/main)

# 

# \## Configuración

# 

# En `appsettings.json`, ajusta la URL base del backend:

# 

# \\`\\`\\`json

# "ApiSettings": {

# &#x20; "BaseUrl": "https://localhost:7272/"

# }

# \\`\\`\\`

# 

# \## Ejecución

# 

# \\`\\`\\`bash

# dotnet restore

# dotnet run

# \\`\\`\\`

# 

# La aplicación queda disponible en `https://localhost:7084`. Al abrir el sitio, se muestra directamente el árbol de jerarquía.

# 

# \## Funcionalidades

# 

# \- Visualización del árbol de jerarquía de empleados.

# \- Crear nuevo empleado, asignando opcionalmente un jefe.

# \- Editar empleado existente.

# \- Eliminar empleado.



