# Reporte - WebApi en .Net8

Esta aplicación permite generar un pdf en base a un template html

# Probar la aplicación

    dotnet restore
    dotnet run

Abrir en el browser:

    http://localhost:5000/swagger/

# Correr con Docker

    docker build -t reporte .
    docker run --name reporte -d --rm -p 8080:5000 reporte

Abrir en el browser:

    http://localhost:8080/swagger/

Detener el contenedor:

    docker stop reporte

# Dependencias

- [Barcoder](https://github.com/huysentruitw/barcoder)
- Barcoder.Renderer.Image
- Barcoder.Renderer.Svg
- [itext.pdfhtml](https://kb.itextpdf.com/itext/chapter-1-hello-html-to-pdf)
- itext.bouncy-castle-adapter
- Swashbuckle.AspNetCore
