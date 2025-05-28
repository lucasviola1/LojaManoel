using LojaManoel.Models;
using LojaManoel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LojaManoel.Controllers;

[ApiController]
[Route("[controller]")]
public class LojaController : ControllerBase
{
    private readonly ILojaService _lojaService;

    private readonly string _connectionString;
    public LojaController(ILojaService lojaService, IConfiguration configuration)
    {
        _lojaService = lojaService;
        _connectionString = configuration.GetConnectionString("HostConnection");
    }

    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> GetPedido([FromBody] Root root)
    {
        var response = _lojaService.Pedidos(root);

        var historicodb = _lojaService.HistoricoPedidos(response);

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (SqlCommand command = new SqlCommand("INSERT INTO Historico (data, QtdPedidos) VALUES (@data, @qtdPedidos)", connection))
            {
                command.Parameters.AddWithValue("@data", historicodb.data);
                command.Parameters.AddWithValue("@qtdPedidos", historicodb.QtdPedidos);

                command.ExecuteNonQuery();
            }
        }
        
        return Ok(response);
    }
}
