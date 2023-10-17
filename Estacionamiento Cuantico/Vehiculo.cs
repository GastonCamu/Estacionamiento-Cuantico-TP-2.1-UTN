using Estacionamiento_Cuantico;

public class Vehiculo
{
    Random randy = new Random();

    public string modelo { get; set; }
    public Dueño dueño { get; set; }
    public string matricula { get; set; }
    public double ancho { get; set; }
    public double largo { get; set; }

    public Vehiculo()
    {
        GenerarValoresAleatoriosPorDefecto();
    }

    public void GenerarValoresAleatoriosPorDefecto()
    {
        GenerarModeloAleatoriamente();
        GenerarDueñoAleatoriamente();
        GenerarMatriculaAleatoriamente();
        GenerarAnchoAleatoriamente();
        GenerarLargoAleatoriamente();
    }
    public void GenerarModeloAleatoriamente()
    {
        modelo = randy.Next(1000, 9999).ToString();
    }
    public void GenerarDueñoAleatoriamente()
    {
        dueño = new Dueño
        {
            nombre = "NombreAleatorio",
            DNI = randy.Next(30000000, 99999999).ToString(),
            VIP = randy.Next(1, 3) == 1
        };
    }
    public void GenerarMatriculaAleatoriamente()
    {
        matricula = randy.Next(10000, 99999).ToString();
    }
    public void GenerarAnchoAleatoriamente()
    {
        ancho = randy.NextDouble() * 10;
    }
    public void GenerarLargoAleatoriamente()
    {
        largo = randy.NextDouble() * 20;
    }
    public void DeterminarTamaño()
    {
        if (this.largo < 4 && this.ancho < 1.5)
        {
            // mini
        }
        else if (this.largo > 4 && this.largo < 5 && this.ancho > 1.5 && this.ancho < 2)
        {
            // standard
        }
        else
        {
            // max
        }
    }
}
