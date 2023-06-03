using EspacioCalculadora;

internal class Program
{
    private static void Main(string[] args)
    {
        String str;
        int op;
        double num;
        bool flag = true;
        var Calc = new Calculadora();

        while (flag)
        {
            Console.WriteLine("\n1. Sumar  ---  2. Restar  ---  3. Multiplicar");
            Console.WriteLine("4. Dividir --- 5. Limpiar ---  6. Salir");

            Console.WriteLine("\nIngrese una opción:");
            str = Console.ReadLine();

            bool ok = int.TryParse(str, out op);

            if (ok)
            {
                if (op > 0 && op <6)
                {
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("\nIngrese la cantidad a sumar: ");
                            str = Console.ReadLine();
                            if (double.TryParse(str, out num))
                            {
                                Calc.Sumar(num);
                            }
                            break;

                        case 2:
                            Console.WriteLine("\nIngrese la cantidad a restar: ");
                            str = Console.ReadLine();
                            if (double.TryParse(str, out num))
                            {
                                Calc.Restar(num);
                            }
                            break; 

                        case 3:
                            Console.WriteLine("\nIngrese la cantidad a multiplicar: ");
                            str = Console.ReadLine();
                            if (double.TryParse(str, out num))
                            {
                                Calc.Multiplicar(num);
                            }
                            break;
                        
                        case 4:
                            Console.WriteLine("\nIngrese la cantidad a dividir: ");
                            str = Console.ReadLine();
                            if (double.TryParse(str, out num))
                            {
                                if (num != 0) Calc.Dividir(num);
                                else Console.WriteLine("La división por 0 no está definida");
                            }
                            break;

                        case 5:
                            Console.WriteLine("\nLimpiando...");
                            Calc.Limpiar();
                            break;
                    }
                } else if (op == 6) { Console.WriteLine("\nSaliendo..."); flag = false; }
            }        
            Console.WriteLine("\n---------------------------");
            Console.WriteLine($"Valor actual del dato: {Calc.Resultado}");
            Console.WriteLine("---------------------------");
        }

    }
}