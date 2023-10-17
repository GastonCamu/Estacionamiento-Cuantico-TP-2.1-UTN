using Estacionamiento_Cuantico;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

Random randy = new Random();
List<Vehiculo> vehiculos = new List<Vehiculo>();

Menu();

void Menu() {
    bool salir = false;

    while (!salir) {
        Console.WriteLine("MENU");
        Console.WriteLine("1: Listar todos los vehiculos");
        Console.WriteLine("2: Agregar un nuevo vehiculo");
        Console.WriteLine("3: Remover un vehiculo segun su matricula");
        Console.WriteLine("4: Remover un vehiculo segun el dni del dueño");
        Console.WriteLine("5: Remover una cantidad aleatoria de vehiculos");
        Console.WriteLine("6: Optimizar el espacio");
        Console.WriteLine("7: Salir");
        string op = Console.ReadLine();

        switch (op) {
            case "1":
                ListarVehiculos(vehiculos);
                break;
            case "2":
                AgregarVehiculo();
                break;
            case "7":
                salir = true;
                break;

            default:
                Console.WriteLine("Opcion invalida");
                break;
        }
    }
}

void ListarVehiculos(List<Vehiculo> vehiculos) {
    foreach (Vehiculo vehiculo in vehiculos) {
        Console.WriteLine($"Modelo: {vehiculo.modelo}");
        Console.WriteLine($"Matricula: {vehiculo.matricula}");
        Console.WriteLine($"ancho: {vehiculo.ancho}");
        Console.WriteLine($"largo: {vehiculo.largo}");
        Console.WriteLine($"---- Dueño ----");
        Console.WriteLine($"Nombre: {vehiculo.dueño.nombre}");
        Console.WriteLine($"DNI: {vehiculo.dueño.DNI}");
        Console.WriteLine($"VIP: {vehiculo.dueño.VIP}");
        Console.WriteLine("------------------------------------------");

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

    vehiculos.Add(vehiculo);
}

