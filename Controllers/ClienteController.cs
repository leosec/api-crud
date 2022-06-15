using api_crud.Models;
using api_crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IClienteRepository _clienteRepository;

        public IEnumerable<Cliente> Clientes { get; set; }

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult ListaClientes()
        {
            try
            {
                var data = _clienteRepository.Listar();
                Clientes = data;
                return Ok(data);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        
        [HttpDelete]
        public IActionResult DeleteCliente(int id)
        {
            try
            {
                _clienteRepository.Excluir(id);
                return Ok("Excluido objeto id:" + id);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult InsertCliente(Cliente cliente)
        {
            try
            {
                _clienteRepository.Persistir(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusCodeResult(500);
            }
        }


    }
}
