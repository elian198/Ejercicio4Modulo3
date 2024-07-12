
using Ejercicio4Modulo3.Models.Entity;

namespace Ejercicio4Modulo3.Service.interfaces;
public interface ILogsService
{
    public Task<bool> save(Logs logs);
}