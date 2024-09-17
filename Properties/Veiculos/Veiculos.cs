using System;
using System.ComponentModel.DataAnnotations;
namespace Veiculos;

public class Veiculos
{
    [Key]
    public int Id { get; set; }
    public string Modelo { get; private set; }; 
    public string Placa { get; private set; }
    public int AnoFabricacao {  get; private set; }


    public Veiculos(string modelo)
    {
        Modelo = modelo;
        Ativo = true;
    }

    public void AtualizarAModelo(string modelo)
    {
        Modelo = modelo; }
}
    public void Desativar()
    {
        Ativo = false;
    }

}
