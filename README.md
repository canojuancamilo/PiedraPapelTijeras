# Piedra, Papel o Tijeras - Juego Prueba tecnica

Este proyecto implementa el clásico juego de Piedra, Papel o Tijeras con una arquitectura de cliente-servidor utilizando .NET Core.

## Backend (API REST) - .NET Core Web API 8.0

### Requisitos Previos

- [ ] [SDK de .NET Core 8.0](https://dotnet.microsoft.com/download)

### Configuración

1. Clona el repositorio:

    ```bash
    git clone https://github.com/canojuancamilo/PiedraPapelTijeras.git
    ```

2. Navega al directorio del backend:

    ```bash
    cd BackendPiendraPapelTijeras
    ```

3. Configura las variables de entorno en `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "ConexionSql": "tu_cadena_de_conexion_a_la_base_de_datos"
      }
    }
    ```
4. Clonar la base de datos, el query lo podrás encontrar en la raíz del repositorio como 'QueryBDJuego.sql'

### Ejecución

1. Restaura las dependencias y compila el proyecto:

    ```bash
    dotnet restore
    dotnet build
    ```

2. Ejecuta la aplicación:

    ```bash
    dotnet run
    ```

## Frontend - .NET Core MVC 8.0

### Requisitos Previos

- [ ] [SDK de .NET Core 8.0](https://dotnet.microsoft.com/download)

### Configuración

1. Abre el proyecto en Visual Studio o tu editor de código preferido.

2. Ajusta la configuración del backend en `appsettings.json` o mediante variables de entorno:

    ```json
    {
      "BackendApiUrl": "https://localhost:5001"
    }
    ```

### Ejecución

1. Restaura las dependencias y compila el proyecto.

2. Inicia la aplicación desde Visual Studio o mediante la línea de comandos.

## Contribución

¡Te invito a contribuir a este proyecto! Si encuentras errores o tienes sugerencias, por favor abre un issue o envía un pull request, muchas gracias de antemano.
