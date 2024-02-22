using System;

using System;
using System.Collections.Generic;

class Reserva
{
    private List<Pessoa> cliente;
    private Suite suite;
    private DateTime dataInicio;
    private DateTime dataFim;
    private int diarias;
    private double valor;


    public Reserva(List<Pessoa> cliente, Suite suite, DateTime dataInicio, DateTime dataFim)
    {
        if (cliente.Count <= suite.GetCapacidade())
        {
            this.cliente = cliente;
            this.suite = suite;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            TimeSpan duracao = dataFim - dataInicio;
            this.diarias = duracao.Days;
            this.valor = diarias * suite.GetValorDiaria();
            if (diarias > 9) valor *= 0.9;
            

        }
        else
        {
            throw new ArgumentException("Capacidade inferior a hóspedes, procure outra suíte.");
        }

    }
   

    public void ListarInformações()
    {
        Console.WriteLine($"{suite},{diarias} dias : {dataInicio.Day} - {dataFim.Day} - R$ {valor:F2}");
        for (int i = 0; i < cliente.Count; i++)
        {
            Console.WriteLine($"Hospede {i+1}:");
            cliente[i].ListarInformações();
        }
       
    }

}

