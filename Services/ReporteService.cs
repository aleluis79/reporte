using Barcoder.Code128;
using Barcoder.Qr;
using Barcoder.Renderer.Svg;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;

namespace reporte.Services;

public class ReporteService : IReporteService {

    public byte[] Generate(string textoNumero) {
        
        using var streamReader = new StreamReader("Templates/requerimientos.html");
        using var pdf = new MemoryStream();
        using PdfDocument pdfDoc = new PdfDocument(new PdfWriter(pdf));
        pdfDoc.SetDefaultPageSize(PageSize.A4);
        
        // Armo el contenido del reporte
        var contenido = new List<string>() {
            "Tengo el agrado de dirigirme a Ud., en mi carácter de Secretario de la Unidad Funcional de Instrucción n° 9 Departamental, en a fin de hacerle saber que en la presente IPP nº 9292/24, se ha dispuesto la entrega del cuatriciclo marca Yongkang, modelo FY200ST, motor MARCA Z0NGJHEN N ° 163ML87800113, Cuadro Nro.LEAADM60371000335 a favor de FERNANDEZ, GABRIEL FABIAN con DNI n° 16.948.660, con los mismos derechos y obligaciones que poseía antes del hecho aquí investigado, por la Seccional que corresponda.",
            "Queda autorizado a diligenciar el presente oficio en mano Sr. Fernandez, Gabriel Fabián con DNI n° 16.948.660.",
            "Sin mas lo saludo con atenta consideración.-"
        };

        // Leo el template completo
        var html = streamReader.ReadToEnd();

        // Reemplazo las variables
        html = html.Replace("@@CODE128", GetCode128(textoNumero));
        html = html.Replace("@@TEXTOCODE128", textoNumero);
        html = html.Replace("@@QRCODE", GetQRCode($"https://mv.mpba.gov.ar/web/IndiceDigitalTexto/{textoNumero}"));
        html = html.Replace("@@TIPO", "Oficio");
        html = html.Replace("@@TITULO", "PP-06-00-009292-24/00 s/Hallazgo");
        html = html.Replace("@@FECHA", "La Plata, 09 de abril de 2024");
        html = html.Replace("@@DESTINATARIO_RENGLON1", "Al Sr. Titular de la");
        html = html.Replace("@@DESTINATARIO_RENGLON2", "Seccional La Plata 8°");
        html = html.Replace("@@DESTINATARIO_RENGLON3", "Su Despacho.-");
        html = html.Replace("@@CONTENIDO", AddTexto(contenido));
        
        // Grabo a disco el archivo html para poder visualizarlo
        //using var writer = new StreamWriter("index.html");
        //writer.Write(html);

        // Convierto el html a pdf
        HtmlConverter.ConvertToPdf(html, pdfDoc, new ConverterProperties());

        return pdf.ToArray();

    }

    private string AddTexto(List<string> contenido) {
        var html = "";
        foreach (var item in contenido) {
            html += "<tr><td colspan=\"3\" style=\"text-indent: 150px; text-align: justify; font-family: Courier; font-size: 14px; width: 100%\">" + item + "</td></tr>";
        }
        return html;
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