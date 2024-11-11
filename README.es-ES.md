<!-- todo: translate the README.md file: https://github.com/jonatasemidio/multilanguage-readme-pattern?tab=readme-ov-file -->

<h1 align=center>PFP</h1>
<p align=center><b>P</b>ersonal <b>F</b>inancial <b>P</b>roject (<b>dotnet</b> version)</p>

[![Static Badge](https://img.shields.io/badge/lang-en-blue)](README.md) [![Static Badge](https://img.shields.io/badge/lang-es-red)](README.es-ES.md)

## Descripción
Proyecto para gestionar gastos e ingresos y llevar un control sencillo de las finanzas personales.

## Sobre el Proyecto

### Tecnologías
- **ASP.NET Core 8**
- **PostgreSQL 16.1**
- **Docker**

### Arquitectura
La arquitectura de este proyecto está inspirada en **Arquitectura Hexagonal** y **Domain-Driven Design (DDD)**.

Con el avance del desarrollo, algunas prácticas recomendadas han sido adaptadas o temporalmente flexibilizadas para optimizar la velocidad de implementación. No obstante, se prevé un proceso de refactorización posterior para alinear el código con los principios arquitectónicos originales.

Por ahora, el enfoque se mantiene en completar una versión funcional inicial, tras lo cual podría realizarse dicha refactorización.

### Levantar el Proyecto
Para levantar el proyecto puede usarse el Docker Compose.

### Documentación
- La documentación general se encuentra en este README.
- A medida que el proyecto crezca, la documentación detallada se ubicará en la carpeta [doc](doc).

#### Base de datos
- La carpeta **database** es donde se encuentra la carpeta **data** cuando se utiliza Docker Compose para los volúmenes.
- Más documentación sobre la base de datos se puede encontrar [aquí](doc/database/).

## Funcionalidades
Las funcionalidades del proyecto y su estado pueden verse [aquí](doc/functionality/README.es-ES.md).
