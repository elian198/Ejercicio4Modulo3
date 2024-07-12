

namespace Ejercicio4Modulo3.Service.interfaces;
using Ejercicio4Modulo3.Models.Entity;

public interface IProveedorService
{ 
    public Task<List<Proveedor>> getAll();
    public Task<bool> save(Proveedor proveedor);
}