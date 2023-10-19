using Estacionamiento_Cuantico;

public class EstacionamientoInfinito {

    Random randy = new Random();

    public double ancho { get; set; }
    public double largo { get; set; }
    public Vehiculo vehiculo { get; set; }

    public void GenerarAnchoAleatoriamente() {
        this.ancho = randy.NextDouble() * (3 - 1) + 1;
    }
    public void GenerarLargoAleatoriamente() { 
        this.largo = randy.NextDouble() * (6 - 3) + 3;
    }
}
