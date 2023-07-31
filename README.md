# CRUD de mascotas .NET CORE + ANGULAR + SQL SERVER

El presente proyecto es un CRUD utilizando de mascotas utilizando las tecnologias  .NET y Angular, mediante el uso de patrones de diseño MVC y Pattern Repository en el Backend y del lado del Frontend utilizando angular se hace uso de Angular Material.

## Requisitos para la ejecucion del proyecto.

[ASP.NET Core SDK](https://dotnet.microsoft.com/download) instalado en la máquina del usuario.

[Node.js](https://nodejs.org/) y [npm](https://www.npmjs.com/) instalados para Angular, mediante el comando de terminal NPM Install.

SQL SERVER instalado en la maquina del usuario. 

## Instalación y Configuración

git clone https://github.com/ManeDM/Crud_FullStack_.NET.git


## Configuracion de la Base de Datos.

Configura la cadena de conexión en el archivo `appsettings.json` para reflejar tu instancia de SQL Server:

"ConnectionStrings":{
    "Link":"Server=[NombreDelServidor]\\[NombreDeLaInstancia];Database=Veterinaria;Trusted_Connection=True"
}

Reemplaza `[NombreDelServidor]` y `[NombreDeLaInstancia]` con los nombres correspondientes.

## Aplicar Migraciones.

Abre una terminal en la carpeta del proyecto.

Ejecuta las migraciones para crear la base de datos:

    dotnet ef database update.


## Compilar y Ejecutar.

Del lado del servidor abre el proyecto en tu  Microdoft Visual Studio y ejecutalo en el modo Debug, puedes interactuar con la API llendo a la siguiente ruta: https://localhost:7134/swagger/index.html.

Del lado del Frontend, abre una terminal, dirijete a la carpeta que contiene el proyecto Angular y ejecuta el comando ng serve, luego nevega hasta la siguiente ruta: http://localhost:4200/petlist
