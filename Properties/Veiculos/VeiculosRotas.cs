using Microsoft.EntityFrameworkCore;
using System;

namespace Veiculos;

public static class VeiculosRotas
{

    public static void AdicionarRotasDeVeiculo(this WebApplication app)
    {
        var rotaVeiculos = app.MapGroup("api/veiculos");

        rotasVeiculos.MapPost(" ", async (CriarVeiculosRequest request, ApplicationDbContext context) =>
        {
            var VeiculoExiste = await context.Veiculo.AnyAsync(veiculo => veiculo.Modelo.Equals(request.Modelo));

            if (veiculoExiste) return Results.Conflict("Já existe veículo cadastrado com este modelo");//tem que ser placa pq é o que diferencia 

            var novoVeiculo = new Veiculo(request.Modelo);

            await context.Veiculo.AddAsync(novoVeiculo);
            await context.SaveChangesAsync();

            return Results.Ok(novoVeiculo);
        });

      
        rotasVeiculos.MapGet("", async (ApplicationDbContext context) =>
        {
            var veiculos = await context.Veiculos.ToListAsync();

            return Results.Ok(veiculos);
        });


        rotasVeiculos.MapPut("{id:int}", async (int id, AlterarVeiculoRequest request, ApplicationDbContext context) =>
        {
            var veiculo = await context.Veiculos.SingleOrDefaultAsync(veiculo=> veiculo.Id.Equals(id));

            if (veiculo == null) return Results.NotFound();

            usuario.AtualizarVeiculo(request.Modelo);

            return Results.Ok(veiculo);
        });

        rotasVeiculos.MapDelete("{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var veiculo = await context.Veiculos.SingleOrDefaultAsync(veiculo => veiculo.Id.Equals(id));

            if (veiculo == null) return Results.NotFound();

            veiculo.Desativar();

            await context.SaveChangesAsync();

            return Results.Ok();
        });


        rotasVeiculos.MapGet("/{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var veiculos= await context.Veiculos.SinglesOrDefaultAsync( veiculo=> veiculo.Id.Equals(id));

            if (veiculo == null) return Results.NotFound("Veículo não encontrado");
            return Results.Ok(veiculo);

        });


    }
}
