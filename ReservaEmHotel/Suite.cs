using System;

class Suite
{
    private int capacidade { get; }
    private double valorDiaria { get; }

    public Suite(int capacidade, double valorDiaria)
    {
        this.capacidade = capacidade;
        this.valorDiaria = valorDiaria;
    }

    public int GetCapacidade()
    {
        return capacidade;
    }

    public double GetValorDiaria()
    {
        return valorDiaria;
    }


    public void ListarInformações()
    {
        Console.WriteLine($"Capacidade :{capacidade} - Valor: R${valorDiaria}");
    }
}