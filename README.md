# Test-MusiscApp

Test-MusiscApp es una aplicación de prueba para gestionar álbumes y canciones. Este proyecto es parte de un ejercicio para aprender a desarrollar aplicaciones web utilizando ASP.NET Core.

## Configuración

1. **Clonar el repositorio**: 
   ```
   git clone https://github.com/tu-usuario/Test-MusiscApp.git
   ```

2. **Instalar dependencias**: 
   - Asegúrate de tener .NET Core SDK instalado en tu máquina.
   - Abre una terminal en la carpeta raíz del proyecto y ejecuta:
     ```
     dotnet restore
     ```

3. **Configuración de la base de datos**:
   - Abre el archivo `appsettings.json` y ajusta la cadena de conexión para tu base de datos.

4. **Migraciones de la base de datos**:
   - En la terminal, ejecuta:
     ```
     Add-Migration nombredelamigracion
     ```
     ```
     Update-Database
     ```

5. **Ejecutar la aplicación**:
   - En la terminal, ejecuta:
     ```
     dotnet run
     ```

## Características

- **Gestión de álbumes**: Agregar, editar y eliminar álbumes.
- **Gestión de canciones**: Agregar y eliminar canciones asociadas a un álbum.
- **Registro de clientes**: Funcionalidad básica para registrar nuevos clientes.
