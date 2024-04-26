using Barcoder.Code128;
using Barcoder.Qr;
using Barcoder.Renderer.Svg;
using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;

namespace reporte.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }

    [HttpGet("generate")]
    public IActionResult Generate()
    {
        var dest = "output.pdf";
        var html = "<body style=\"max-width: 705px; margin: 0 auto;\"><table style=\"width: 100%; font-family: Helvetica; letter-spacing: 1px; line-height: 2;\"><tr>";
        html += "<td style=\"width: 25%; text-align: left;\">" + GetCode128("E06000012828368") + "<br>&nbsp;&nbsp;E06000012828368</td>";
        html += "<td style=\"width: 50%; text-align: center;\"><img width=\"200px\" src=\"logo.jpg\"></td>";
        html += "<td style=\"width: 25%; text-align: right;\">" + GetQRCode("https://mv.mpba.gov.ar/web/IndiceDigitalTexto/E06000012828368") + "</td>";
        html += "</tr>";
        html += "<tr><td colspan=\"3\" style=\"text-align: center; font-size: 20px;\">" + "Oficio" + "</td></tr>";
        html += "<tr><td colspan=\"3\" style=\"padding-left: 50px; text-align: left; font-size: 16px;\">" + "PP-06-00-009292-24/00 s/Hallazgo" + "</td></tr>";
        html += "<tr><td colspan=\"3\" style=\"text-align: left; font-size: 16px; height: 30px; width: 100%\">" + " " + "</td></tr>";

        html += "</table>";

        html += "<table style=\"padding-left: 50px; padding-right: 50px; width: 100%; font-family: Helvetica; letter-spacing: 1px; line-height: 2; border-left: solid 1px black; border-right: solid 1px black;\"><tr>";


        html += "<tr><td colspan=\"3\" style=\"text-align: right; font-size: 16px; border-bottom: 1px solid black;\">" + "La Plata, 09 de abril de 2024" + "</td></tr>";

        html += "<tr><td colspan=\"3\" style=\"text-align: left; font-family: Courier; font-size: 16px; font-weight: bold; width: 100%\">" + "Al Sr. Titular de la" + "</td></tr>";
        html += "<tr><td colspan=\"3\" style=\"text-align: left; font-family: Courier; font-size: 16px; font-weight: bold; width: 100%\">" + "Seccional La Plata 8°" + "</td></tr>";
        html += "<tr><td colspan=\"3\" style=\"text-align: left; font-family: Courier; font-size: 16px; font-weight: bold; width: 100%\">" + "Su Despacho.-" + "</td></tr>";

        html += "<tr><td colspan=\"3\" style=\"text-indent: 150px; text-align: justify; font-family: Courier; font-size: 14px; width: 100%\">" 
        + "Tengo el agrado de dirigirme a Ud., en mi carácter de Secretario de la Unidad Funcional de Instrucción n° 9 Departamental, en a fin de hacerle saber que en la presente IPP nº 9292/24, se ha dispuesto la entrega del cuatriciclo marca Yongkang, modelo FY200ST, motor MARCA Z0NGJHEN N ° 163ML87800113, Cuadro Nro.LEAADM60371000335 a favor de FERNANDEZ, GABRIEL FABIAN con DNI n° 16.948.660, con los mismos derechos y obligaciones que poseía antes del hecho aquí investigado, por la Seccional que corresponda."        
        + "</td></tr>";

        html += "<tr><td colspan=\"3\" style=\"text-indent: 150px; text-align: justify; font-family: Courier; font-size: 14px; width: 100%\">" 
        + "Queda autorizado a diligenciar el presente oficio en mano Sr. Fernandez, Gabriel Fabián con DNI n° 16.948.660."
        + "</td></tr>";

        html += "<tr><td colspan=\"3\" style=\"text-indent: 150px; text-align: justify; font-family: Courier; font-size: 14px; width: 100%\">" 
        + "Sin mas lo saludo con atenta consideración.-"
        + "</td></tr>";

/*
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
        html += "<tr><td colspan=\"3\">" + "Prueba" + "</td></tr>";
*/



        html += "</table>";
        html += "<table style=\"width: 100%; min-height: 1000px; border-left: solid 1px black; border-right: solid 1px black; \"><tr><td>&nbsp;</td></tr></table></body>";


        // Grabo a disco el archivo html para poder visualizarlo
        using (StreamWriter writer = new StreamWriter("index.html"))
        {
            writer.Write(html);
        }


        ConverterProperties converterProperties = new ConverterProperties();
        using PdfDocument temp = new PdfDocument(new PdfWriter(new FileStream(dest, FileMode.Create)));
        temp.SetDefaultPageSize(PageSize.A4);

        //HtmlConverter.ConvertToPdf(html, new FileStream(dest, FileMode.Create));
        HtmlConverter.ConvertToPdf(html, temp, converterProperties);

        return Ok("ok");
    }

    private string GetCode128(string code)
    {
        var barcode = Code128Encoder.Encode(code);
        var renderer = new SvgRenderer();

        using var stream = new MemoryStream();
        using var reader = new StreamReader(stream);
        
        renderer.Render(barcode, stream);
        stream.Position = 0;

        var svg =  reader.ReadToEnd();

        //svg = svg.Replace("<svg","<svg width=\"100px\" height=\"40px\" preserveAspectRatio=\"none\"");

        return svg;
    }

    private string GetQRCode(string texto) {
        
        var barcode = QrEncoder.Encode(texto, ErrorCorrectionLevel.H, Encoding.Unicode);

        

        var options = new SvgRendererOptions();
        options.CustomMargin = 10;
        var renderer = new SvgRenderer(options);

        using var stream = new MemoryStream();
        using var reader = new StreamReader(stream);
        
        renderer.Render(barcode, stream);
        stream.Position = 0;

        var svg =  reader.ReadToEnd();

        svg = svg.Replace("<svg","<svg width=\"120px\" height=\"120px\"");

        return svg;

    }
}
