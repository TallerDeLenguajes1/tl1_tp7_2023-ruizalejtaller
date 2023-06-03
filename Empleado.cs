namespace EspacioEmpleado;

class Empleados
{
    private String Nombre;
    private String Apellido;
    private DateTime FechaNac;
    private char EstadoCivil;
    private char Genero;
    private DateTime FechaIngreso;
    private double Basico;
    private Cargos Cargo;

    public Empleados(string nombre, string apellido, DateTime fechaNac, char estadoCivil, char genero, DateTime fechaIngreso, double basico, Cargos cargo)
    {
        Nombre = nombre;
        Apellido = apellido;
        FechaNac = fechaNac;
        EstadoCivil = estadoCivil;
        Genero = genero;
        FechaIngreso = fechaIngreso;
        Basico = basico;
        Cargo = cargo;
    }

    public string nombre { get => Nombre; }
    public string apellido { get => Apellido; }
    public DateTime fechanac { get => FechaNac; }
    public char estadocivil { get => EstadoCivil; }
    public char genero { get => Genero; }
    public DateTime fechaingreso { get => FechaIngreso; }
    public double basico { get => Basico; }
    public Cargos cargo { get => Cargo; }



    public int antiguedad()
    {
        return DateTime.Now.Year - FechaIngreso.Year;
    }

    public int edad()
    {
        if (DateTime.Now.Month >= FechaNac.Month && DateTime.Now.Day >= FechaNac.Day)
        {
            return DateTime.Now.Year - FechaNac.Year;
        } else return DateTime.Now.Year - FechaNac.Year - 1;
    }

    public int jubilarse()
    {

        if (Genero == 'h')
        {
            return 65 - edad();
        } else return 60 - edad();
    }

    public double salario()
    {
        double Adicional;
        if (antiguedad() < 20)
        {
            Adicional = Basico*((double)antiguedad()/100);
        } else Adicional = Basico*0.25;

        if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
        {
            Adicional = Adicional*1.5;
        }

        if (EstadoCivil == 'c')
        {
            Adicional += 15000;
        }

        return Basico+Adicional;
    }

    public void mostrarDatos()
    {
        Console.WriteLine("\n-----------------------------------------");
        Console.WriteLine($"Apellido y Nombres: {Apellido}, {Nombre}");
        Console.WriteLine($"Fecha de Nacimiento: {FechaNac.ToShortDateString()}");
        Console.WriteLine($"Edad: {edad()}");
        if (EstadoCivil == 'c')
        {
            if (Genero == 'h') Console.WriteLine("Estado civil: Casado");
                else Console.WriteLine("Estado civil: Casada");
        } else if (Genero == 'h') Console.WriteLine("Estado civil: Soltero");
                else Console.WriteLine("Estado civil: Soltera");
        Console.WriteLine($"Fecha de ingreso: {FechaIngreso.ToShortDateString()}");
        Console.WriteLine($"Cargo: {cargo}");
        Console.WriteLine($"Salario: {salario().ToString("C2")}");
        Console.WriteLine("-----------------------------------------\n");
    }

}
