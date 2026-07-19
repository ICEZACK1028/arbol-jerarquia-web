# Jerarquía de Empleados — Frontend

## Tecnologías

* .NET 8
* ASP.NET Core MVC
* Bootstrap
* `HttpClientFactory` para el consumo de la API REST

## Requisitos previos

* .NET 8 SDK
* El proyecto **Backend** en ejecución:

  * https://github.com/ICEZACK1028/arbol-jerarquia-api/tree/main

## Configuración

En el archivo `appsettings.json`, configura la URL base del backend:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7272/"
  }
}
```

## Ejecución

```bash
dotnet restore
dotnet run
```

La aplicación estará disponible en:

```text
https://localhost:7084
```

Al acceder a la aplicación, se mostrará automáticamente el árbol de jerarquía de empleados.

## Funcionalidades

* Visualización del árbol de jerarquía de empleados.
* Creación de nuevos empleados con asignación opcional de un jefe.
* Edición de empleados existentes.
* Eliminación de empleados.
