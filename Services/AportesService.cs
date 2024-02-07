using Microsoft.EntityFrameworkCore;
using RegistroAportes.DAL;
using RegistroAportes.Models;
using System.Linq.Expressions;

namespace RegistroAportes.Services;

public class AportesService
{
	private readonly Contexto _contexto;

    public AportesService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Crear(Aportes aporte)
    {
        if (!await Existe(aporte.AporteId))
            return await Insertar(aporte);
        else
            return await Modificar(aporte);
    }
	public async Task<bool> Existe(int id)
	{
        return await _contexto.Aportes.AnyAsync(a => a.AporteId == id);
	}
	public async Task<bool> Insertar(Aportes aporte)
	{
		_contexto.Aportes.Add(aporte);
        return await _contexto.SaveChangesAsync() > 0;
	}
	public async Task<bool> Modificar(Aportes aporte)
	{
		_contexto.Aportes.Update(aporte);
		var modificar = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(aporte).State = EntityState.Detached;
		return modificar;
	}
	public async Task<bool> Eliminar(Aportes aporte)
	{
		var eliminar = await _contexto.Aportes
			.Where(a => a.AporteId == aporte.AporteId)
			.ExecuteDeleteAsync();
		return eliminar > 0;
	}
	public async Task<Aportes?> Buscar(Aportes aporte)
	{
		return await _contexto.Aportes
			.AsNoTracking()
			.FirstOrDefaultAsync(a => a.AporteId == aporte.AporteId);
	}
	public async Task<List<Aportes>> Listar(Expression<Func<Aportes,bool>> criterio)
	{
		return await _contexto.Aportes
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
