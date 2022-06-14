using api_crud.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_crud.Repository
{

    public interface IClienteRepository
    {
        Cliente Selecionar(int id);
        IEnumerable<Cliente> Listar();
        void Persistir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int id);
    }


    public class ClienteRepository : IClienteRepository
    {
        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("mysqldb"); } }

        public ClienteRepository(IConfiguration config)
        {
            _configuracoes = config;
        }

        public Cliente Selecionar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> Listar()
        {
            throw new NotImplementedException();
        }

        public void Persistir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
