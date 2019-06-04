# `Prueba t�cnica`

## Configurar sitio
Luego de descargar los archivos fuentes de la prueba,presionar las teclas ctrl+shitf+B para compilar el proyecto y que autom�ticamente se descarguen los nugets necesarios. luego  ejecutar el proyecto, este proyecto ya est� configurado para lanzar localmente los servicios API Rest
Una vez se ejecute el proyecto

## Configurar base de datos
En los appsettings.json de cada servicio api, se encuentra la configuraci�n de la cadena de conexi�n.  `src/services/`

    - "ConnectionStrings":{
        "SMDatabase": "Server=.\\SQLEXPRESS;Database=MariaDB;Trusted_Connection=True;"
        }
Colocar en esta secci�n la conexi�n de base de datos que tengas local y hacerlo para cada servicio.
Una vez finalizado este proceso vamos a la base de datos  **Maria_DB** y ejecutamos el script que se encuentra en los fuentes:  `src/data/scripts/structura.sql`


### Ejecutar proyecto
Una vez hayamos configurado la cadena de conexi�n y hayamos ejecutado el script, corremos el proyecto web, este proyecto ya est� configurado para que levante los 7 servicios que se necesitan.

### Configurar Postman:
Para  realizar las pruebas a los servicios se debe tener una cuenta en postman con el fin de adicionar el proyecto a la aplicaci�n consola.  Para acceder una vez tengas una cuenta con postman es a trav�s del soguiente link:  `https://www.getpostman.com/collections/4339329309f17ba6bd51`, o tambien vamos a dejar en el sitio del proyecto un archivo para que se pueda importar directamente a postman en el siguiente path: `src/documentation/Test Apis Finacialo.postman_collection.json`

### Microservicios: 
Se realiz� una arquitectura orientada a microservicios, el cual cada servicio es independiente.

**Muchas gracias...**