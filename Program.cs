using EspacioEmpleado;

internal class Program
{
    private static void Main(string[] args)
    {
        const int personal  = 3;
        String str, nombre, apellido;
        char civil, genero;
        DateTime fechanac, fechaing;
        double basico, montoTotal = 0;
        Cargos cargo;
        int proximoJub = 0;

        Empleados[] Empleado = new Empleados[personal];
        
        for (int i = 0; i<personal; i++)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine($"Empleado: {i+1}");
            Console.WriteLine("-----------------");

            Console.WriteLine("Nombre: ");
            str = Console.ReadLine();

            if (str != "")
            {
                nombre = str;
            } else nombre = "john";

            Console.WriteLine("\nApellido: ");
            str = Console.ReadLine();

            if (str != "")
            {
                apellido = str;
            } else apellido = "doe";

            Console.WriteLine("\nFecha de nacimiento: (DD/MM/AAAA)");//
            
            str = Console.ReadLine();

            if (DateTime.TryParse(str, out fechanac))
            {
                Console.WriteLine($"Fecha de nacimiento: {fechanac.ToShortDateString()}");
            } else
                {
                    Console.WriteLine("Error en el formato de fecha, asignando default.");
                    fechanac = new DateTime(1980, 1, 1);
                }
            
            Console.WriteLine("\nEstado civil: Soltero/a (s), Casado/a (c)");

            str = Console.ReadLine();

            if (str == "s")
            {
                civil = 's';
            } else if (str == "c")
                {
                    civil = 'c';
                } else
                    {
                        Console.WriteLine("Era s o n! asignando default.");
                        civil = 's';
                    }

            Console.WriteLine("\nGenero: (h), (m)");

            str = Console.ReadLine();

            if (str == "h")
            {
                genero = 'h';
            } else if (str == "m")
                {
                    genero = 'm';
                } else
                    {
                        Console.WriteLine("Otra vez... asignando default.");
                        genero = 'h';
                    }
            
            Console.WriteLine("\nFecha de ingreso: (DD/MM/AAAA)");
            
            str = Console.ReadLine();

            if (DateTime.TryParse(str, out fechaing))
            {
                Console.WriteLine($"Fecha de ingreso: {fechaing.ToShortDateString()}");
            } else
                {
                    Console.WriteLine("Error en el formato de fecha, asignando default.");
                    fechaing = new DateTime(2010, 1, 1);
                }

            Console.WriteLine("\nCargo:\n1. Auxiliar, 2. Administrativo, 3. Ingeniero, 4. Especialista, 5. Investigador");

            str = Console.ReadLine();

            if (Cargos.TryParse(str, out cargo))
            {
                Console.WriteLine($"Cargo: {cargo}");
            } else {
                Console.WriteLine("Asignando default.");
                cargo = Cargos.Auxiliar;
            }

            Console.WriteLine("\nSueldo basico: ");

            str = Console.ReadLine();

            if (double.TryParse(str, out basico))
            {
                Console.WriteLine("Todo ok.\n");
            } else {
                Console.WriteLine("Asignando default.");
                basico = 65000;
            }

                Empleado[i] = new Empleados(nombre, apellido, fechanac, civil, genero, fechaing, basico, cargo);

        }        

        for (int i=0; i<personal; i++)
        {
            montoTotal += Empleado[i].salario();
        }

        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Monto total en concepto de salarios: {montoTotal}");
        Console.WriteLine("---------------------------------------------------");

        for (int i=0; i<personal; i++)
        {
            if (Empleado[i].jubilarse() < Empleado[proximoJub].jubilarse())
                proximoJub = i;
        }

        Console.WriteLine("\n Empleado que está más proximo a jubilarse:");
        Empleado[proximoJub].mostrarDatos();
    }
       
}