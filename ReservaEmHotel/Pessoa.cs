using System;

public class Pessoa
{
    private string nome { get; }
    private int idade { get; }
    private string genero { get; }
    private string profissao { get; }

    public Pessoa(string nome, int idade, string genero, string profissao)
    {
        this.nome = nome;
        this.idade = idade;
        this.genero = genero;
        this.profissao = profissao;
    }

    public string GetNome()
    {
        return nome;
    }
    public void ListarInformações()
    {
       Console.WriteLine( $"{nome},{idade} anos, {genero},{profissao}");
    }

    
}
