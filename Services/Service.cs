using Microsoft.EntityFrameworkCore;
using Ronalfy_Jimenez_P1_Ap1.Models;
using Ronalfy_Jimenez_P1_Ap1.DAL;
using System.Linq.Expressions;

namespace Ronalfy_Jimenez_P1_Ap1.Services;

public class Service(IDbContextFactory<Contexto> DbFactory)
{

    private async Task<bool> Insertar(Modelo Modelos) 
    { 
     await using var contexto = DbFactory.CreateDbContext();
        contexto.Modelos.Add(Modelos);
        return await contexto.SaveChangesAsync() > 0;
    }
    
    private async Task<bool> Modificar(Modelo Modelos) 
    { 
     await using var contexto = DbFactory.CreateDbContext();
        contexto.Modelos.Update(Modelos);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = DbFactory.CreateDbContext();
        var EliminarModelo =  await contexto.Modelos.Where(m => m.AporteId == id).
            ExecuteDeleteAsync();
       
        return EliminarModelo >0;
    }

    public async Task<bool> Existe(int aporteId)
    {
        await using var contexto = DbFactory.CreateDbContext();
        return await contexto.Modelos.AnyAsync(m => m.AporteId == aporteId);
    }

    public async Task<bool> Guardar(Modelo Modelos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        if (!await Existe(Modelos.AporteId))
        {
            return await Insertar(Modelos);
        }
        else
        {
            return await Modificar(Modelos);
        }
    }

    public async Task<Modelo?> Buscar(int id = 0, string? persona = null)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        if (id > 0)
        {
            return await contexto.Modelos.AsNoTracking()
                .FirstOrDefaultAsync(s => s.AporteId == id);
        }

        else if (!string.IsNullOrEmpty(persona))
        {
            return await contexto.Modelos.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Persona == persona);

        }
        return null;

    }

    public async Task<List<Modelo>> Listar(Expression<Func<Modelo, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Modelos.AsNoTracking().Where(criterio).ToListAsync();
    }

    public async Task<List<Modelo>> ListarModelo()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Modelos.AsNoTracking().ToListAsync();
    }

    public async Task<bool> ExisteModelo(int id, string? persona)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Modelos.AnyAsync(s => s.AporteId == id || s.Persona == persona);
    }

}