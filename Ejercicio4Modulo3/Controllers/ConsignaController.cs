using Ejercicio4Modulo3.Models.Entity;
using Ejercicio4Modulo3.Service.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignaController : ControllerBase
    {

        private readonly IProveedorService _proveedorService;

        public ConsignaController(IProveedorService proveedorService) {
            _proveedorService = proveedorService;
        }

        // Correr el script para tener los datos de la BD
        // Se debe crear con la arquitectura en capas( el controller y services) para poder unicamente dar de alta un proveedor y recuperar todos los proveedores
        // Todas las peticiones tienen que ser async
        // Crear un middleware personalizado, que grabe en base de datos en la tabla logs cada interaccion que exista con los endpoints expuestos:
        // Si hay un error en la peticion se debe grabar success = false  sino success = true
        // para completar los datos de path y verbo http deben usar los metodos/propiedades
        // de la variable "context" que se disponibiliza al implementar IMiddleware


        [HttpGet]
         public async Task<ActionResult> getAll( ) 
        {

            return Ok(await _proveedorService.getAll());
        }

        [HttpPost]
        public async Task<ActionResult> save([FromBody] Proveedor proveedor)
        {
                bool save = await _proveedorService.save(proveedor);
            return Ok();
        }

     
    }
}
