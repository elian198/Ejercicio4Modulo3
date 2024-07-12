
using Ejercicio4Modulo3.Service.interfaces;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Models.Entity;
using Microsoft.EntityFrameworkCore;

public class ProveedorService : IProveedorService
{
    private Ejercicio4Modulo3Context _context;

    public ProveedorService(Ejercicio4Modulo3Context context) { _context = context; }


   async Task<List<Proveedor>> IProveedorService.getAll()
    {
        return await _context.Proveedor.ToListAsync();
    }

    async Task<bool> IProveedorService.save(Proveedor proveedor)
    {
        if (proveedor.RazonSocial.Length == 0  || proveedor.CodProveedor.Length == 0 || proveedor.Id != 0 )
            throw new Exception("Las campos no pueden estar vacios, no puede carga el id!!!");

            await _context.Proveedor.AddAsync(proveedor);
            _context.SaveChanges();
        
        return true;
    }
}
