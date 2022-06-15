using api_crud.Models;
using api_crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger _logger;

        private readonly IClienteRepository _clienteRepository;

        public IEnumerable<Cliente> Clientes { get; set; }

        public ClienteController(IClienteRepository clienteRepository, ILogger<ClienteController> logger)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult ListaClientes()
        {
            try
            {
                var data = _clienteRepository.Listar();
                Clientes = data;
                _logger.LogInformation(1002,"Retornado " + data.Count() + " objetos na consulta GET.");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Encontrado problemas: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }
        
        [HttpDelete]
        public IActionResult DeleteCliente(int id)
        {
            try
            {
                _clienteRepository.Excluir(id);
                _logger.LogInformation(1002,"Deletado ID " + id + " no banco de dados.");
                return Ok("Excluido objeto id:" + id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Encontrado problemas: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult InsertCliente(Cliente cliente)
        {
            try
            {
                
                _clienteRepository.Persistir(cliente);
                _logger.LogInformation(1002,"Inserido objetos na tabela Cliente do banco de dados");
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("Encontrado problemas: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }


    }
}
