

using Ejercicio4Modulo3.Models.Entity;
using Ejercicio4Modulo3.Service.interfaces;
using Microsoft.Data.SqlClient;
using System.Text.Json;

public class GlobalExceptionHandler : IMiddleware
{

    private readonly ILogsService _logsService;
    private Logs logs = new Logs();

    public GlobalExceptionHandler(ILogsService logsService)
    {
          _logsService = logsService;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            logs.Fecha = DateTime.Now;
            logs.Path = context.Request.Path;
            logs.Method = context.Request.Method;
   
            await next(context);
            logs.Success = true;
            await _logsService.save(logs);

        }
        catch (Exception e)
        {
            await LogExceptionAsync(context, e);
            throw;
        }

    }
    private async Task LogExceptionAsync(HttpContext context, Exception e)
    {
        logs.Success = false;

        await _logsService.save(logs);

        context.Response.StatusCode = 400;
        context.Response.ContentType = "application/json";
        var repuesta = new
        {
            Error = $"Error de validacion en la Api {context.Request.Path.Value} + {context.Request.Method}"
        };
      
        await context.Response.WriteAsJsonAsync(repuesta);
    }
}
