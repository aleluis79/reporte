namespace reporte.Services;

public interface IReporteService {
    byte[] Generate(string textoNumero);

    public byte[] GenerateWithAsymmetricalMargins(string textoNumero);
}