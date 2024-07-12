

using Ejercicio4Modulo3.Models.Entity;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Service.interfaces;

public class LogsService : ILogsService
{
    private Ejercicio4Modulo3Context _context;

    public LogsService(Ejercicio4Modulo3Context context) { _context = context; }

    public async Task<bool> save(Logs logs)
    {
        await _context.Logs.AddAsync(logs);
        _context.SaveChanges();
        return true;
    }
}