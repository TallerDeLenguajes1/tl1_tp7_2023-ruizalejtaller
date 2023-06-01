namespace EspacioCalculadora;

public class Calculadora
{
    private double dato;

    public double Resultado { get => dato; }

    public void Sumar(double num)
    {
        dato = dato + num;
    }
    public void Restar(double num)
    {
        dato = dato - num;
    }

    public void Multiplicar(double num)
    {
        dato = dato * num;
    }
    public void Dividir(double num)
    {
        dato = dato / num;
    }

    public void Limpiar()
    {
        dato = 0;
    }
}