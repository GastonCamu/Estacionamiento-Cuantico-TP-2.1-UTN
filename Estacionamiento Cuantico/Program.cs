using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

Random randy = new Random();
Vehiculo[] estacionamientoFinito = new Vehiculo[12];
List<EstacionamientoInfinito> estacionamientosInfinitos = new List<EstacionamientoInfinito>();

Menu();

void Menu() {
    bool salir = false;

    while (!salir) {
        Console.WriteLine("MENU");
        Console.WriteLine("1: Listar todos los vehiculos");
        Console.WriteLine("2: Agregar un nuevo vehiculo");
        Console.WriteLine("3: Agregar n vehiculos");
        Console.WriteLine("4: Remover un vehiculo segun su matricula");
        Console.WriteLine("5: Remover un vehiculo segun el dni del dueño");
        Console.WriteLine("6: Remover una cantidad aleatoria de vehiculos");
        Console.WriteLine("7: Optimizar el espacio");
        Console.WriteLine("8: Salir");
        string op = Console.ReadLine();

        switch (op) {
            case "1":
                ListarVehiculos(estacionamientoFinito, estacionamientosInfinitos);
                break;
            case "2":
                AgregarVehiculo();
                break;
            case "3":
                GenerarNVehiculos();
                break;
            case "8":
                salir = true;
                break;

            default:
                Console.WriteLine("Opcion invalida");
                break;
        }
    }
}

void GenerarNVehiculos() {
    for (int i = 0; i < randy.Next(10,50); i ++) {
        Vehiculo vehiculo = new Vehiculo();
        vehiculo.GenerarValoresAleatoriosPorDefecto();
        GuardarVehiculosEstacionamientos(vehiculo);
    }

}

EstacionamientoInfinito GeneradorEstacionamiento(double vAncho, double vLargo) {
    bool cargado = false;
    EstacionamientoInfinito estacionamientoInfinito = new EstacionamientoInfinito();
    while (!cargado)
    {
        estacionamientoInfinito.GenerarAnchoAleatoriamente();
        estacionamientoInfinito.GenerarLargoAleatoriamente();
        if (vAncho <= estacionamientoInfinito.ancho && vLargo <= estacionamientoInfinito.largo)
        {
            cargado = true;
        }
    }
    return estacionamientoInfinito;
}
void ListarVehiculos(Vehiculo[] estacionamientoFinito, List<EstacionamientoInfinito> estacionamientosInfinitos) {
    Console.WriteLine("*****************************************");
    Console.WriteLine("   -----ESTACIONAMIENTO FINITO-----   ");
    Console.WriteLine("*****************************************");
    for (int i = 0; i < estacionamientoFinito.Length; i++) {
        Console.WriteLine($" ----Posicion: {i} ----");
        Vehiculo vehiculo = estacionamientoFinito[i];
        MostrarDatos(vehiculo);
        Console.WriteLine("------------------------------------------");
    }
    Console.WriteLine("*****************************************");
    Console.WriteLine("   -----ESTACIONAMIENTO INFINITO-----   ");
    Console.WriteLine("*****************************************");

    int e = 0;
    foreach (EstacionamientoInfinito estacionamiento in estacionamientosInfinitos) {
        Console.WriteLine($"Estacionamiento {e}");
        Vehiculo vehiculo = estacionamiento.vehiculo;
        Console.WriteLine($"eancho {estacionamiento.ancho} elargo {estacionamiento.largo}");
        MostrarDatos(vehiculo);
        Console.WriteLine("------------------------------------------");
        e++;
    }
}

void MostrarDatos(Vehiculo vehiculo)
{
    if (vehiculo != null)
    {
        Console.WriteLine("Modelo: " + vehiculo.modelo);
        Console.WriteLine("Matrícula: " + vehiculo.matricula);
        Console.WriteLine("Ancho: " + vehiculo.ancho);
        Console.WriteLine("Largo: " + vehiculo.largo);
        Console.WriteLine("---- Dueño ----");

        if (vehiculo.dueño != null)
        {
            Console.WriteLine("Nombre: " + vehiculo.dueño.nombre);
            Console.WriteLine("DNI: " + vehiculo.dueño.DNI);
            Console.WriteLine("VIP: " + vehiculo.dueño.VIP);
        }
    }
}
void AgregarVehiculo() {
    Vehiculo vehiculo = new Vehiculo();

    Console.WriteLine("Ingrese el modelo del vehiculo (o presione Enter para aleatorio):");
    string modelo = Console.ReadLine();
    if (string.IsNullOrEmpty(modelo)) { vehiculo.GenerarModeloAleatoriamente(); }
    else { vehiculo.modelo = modelo; }

    Console.WriteLine("Ingrese la matricula (o presione Enter para aleatorio):");
    string matricula = Console.ReadLine();
    if (string.IsNullOrEmpty(matricula)) { vehiculo.GenerarMatriculaAleatoriamente(); }
    else { vehiculo.matricula = matricula; }

    Console.WriteLine("Ingrese el ancho del vehiculo (o presione Enter para aleatorio):");
    string ancho = Console.ReadLine();
    if (string.IsNullOrEmpty(ancho)) { vehiculo.GenerarAnchoAleatoriamente(); }
    else { vehiculo.ancho = Convert.ToDouble(ancho); }

    Console.WriteLine("Ingrese el largo del vehiculo (o presione Enter para aleatorio):");
    string largo = Console.ReadLine();
    if (string.IsNullOrEmpty(largo)) { vehiculo.GenerarLargoAleatoriamente(); }
    else { vehiculo.largo = Convert.ToDouble(largo); }

    Console.WriteLine("¿Tiene la informacion del dueño?");
    Console.WriteLine("1:SI, 2:Generar Aleatoriamente");
    string opDueño = Console.ReadLine();
    if (opDueño == "1") {
        Console.WriteLine("Ingrese el nombre del dueño");
        string nombre = Console.ReadLine();
        vehiculo.dueño.nombre = nombre;
        Console.WriteLine("Ingrese el DNI del dueño");
        string DNI = Console.ReadLine();
        vehiculo.dueño.DNI = DNI;
        Console.WriteLine("¿Es un usuario VIP? 1:SI, 2:NO");
        string opVIP = Console.ReadLine();
        if (opVIP == "1") { vehiculo.dueño.VIP = true; }
        else { vehiculo.dueño.VIP = false; }
    }
    else { vehiculo.GenerarDueñoAleatoriamente(); }
    GuardarVehiculosEstacionamientos(vehiculo);
}

bool EstacionamientoFinitoVacio()
{
    bool vacio = true;
    for (int i = 0; i < estacionamientoFinito.Length; i++)
    {
        if (estacionamientoFinito[i] != null)
        {
            vacio = false;
            break; // Deja de buscar si encuentra un espacio no vacío.
        }
    }
    return vacio;
}

bool EstacionamientoVIPVacio()
{
    bool vacio = false;
    if (estacionamientoFinito[2] == null || estacionamientoFinito[6] == null || estacionamientoFinito[11] == null)
    {
    vacio = true;
    }
    return vacio;
}

void GuardarVehiculosEstacionamientos(Vehiculo vehiculo)
{
    bool seEstaciono = false;
    while (EstacionamientoFinitoVacio()) {
        seEstaciono = GuardarVehiculosEFinito(vehiculo);
    }
    if (!seEstaciono)
    {
        GuardarVehiculosEInfinito(vehiculo);
    }
}

bool GuardarVehiculosEFinito(Vehiculo vehiculo)
{
    bool seEstaciono = false;
    for (int i = 0; i < estacionamientoFinito.Length;i++)
    {
        if (vehiculo.dueño.VIP == true && EstacionamientoVIPVacio())
        {
            GuardarEVIP(vehiculo);
            seEstaciono = true;
        }
        else { GuardarENoVIP(vehiculo); seEstaciono = true; }
    }
    return seEstaciono;
}

void GuardarVehiculosEInfinito(Vehiculo vehiculo)
{
    EstacionamientoInfinito estacionamientoInfinito = GeneradorEstacionamiento(vehiculo.ancho, vehiculo.largo);
    estacionamientoInfinito.vehiculo = vehiculo;
    estacionamientosInfinitos.Add(estacionamientoInfinito);
}

void GuardarEVIP(Vehiculo vehiculo)
{
    if (estacionamientoFinito[2] == null)
    {
        estacionamientoFinito[2] = vehiculo;
    }
    else if (estacionamientoFinito[6] == null)
    {
        estacionamientoFinito[6] = vehiculo;
    }
    else if (estacionamientoFinito[11] == null)
    {
        estacionamientoFinito[11] = vehiculo;
    }
}

void GuardarENoVIP(Vehiculo vehiculo)
{
    for (int i = 0; i < estacionamientoFinito.Length;i++)
    {
        if (i != 2 && i != 6 && i != 11)
        {
            estacionamientoFinito[i] = vehiculo;
            break;
        }
    }
}
